using UnityEngine;
using System.Collections;

public class MouseController : MonoBehaviour {

    Transform CameraPos;
    public GameObject line;
    Vector3[] pos = new Vector3[2];
    bool drawline;

    Vector3 MousePos, LastPosition;

    Material PrevMaterial;
    GameObject PrevGameObject;
    public Material Highlighter;
    Transform Selected;
    RaycastHit hitInfo = new RaycastHit();

    public float PanSensitivity;

    GameObject GO;

	// Use this for initialization
	void Start () {
        CameraPos = Camera.main.transform;
        MousePos = Input.mousePosition;
        LastPosition = Input.mousePosition;
        drawline = false;

    }
	
	// Update is called once per frame
	void Update () {
        PanScreen();

        MouseSelection();
       
        
    }

    void PanScreen()
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 delta = (Input.mousePosition) - LastPosition;
            CameraPos.position = CameraPos.position - PanSensitivity * delta;
        }

        LastPosition = Input.mousePosition;
    }

    void MouseSelection()
    {
        if(Selected != null && Selected.tag == "Drag")
        {
            Selected.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
        }

        if (Input.GetMouseButtonDown(0) && (Selected == null || drawline))
        {
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                if (hitInfo.transform.gameObject.tag == "Drag" && !drawline)
                {
                    Selected = hitInfo.transform;
                }
                else if(hitInfo.transform.gameObject.tag == "Connector")
                {
                    Selected = hitInfo.transform;
                    DrawLine();
                }

            }
        }
        else if(Input.GetMouseButtonDown(0))
        {
            Selected = null;
        }
    }
    
    void DrawLine()
    {
        if(drawline == false)
        {
            drawline = true;
            Debug.Log("Started Drawing" + hitInfo.transform.gameObject.name);
            GO = (GameObject)Instantiate(line, Selected.transform.position, Quaternion.identity);
            GO.GetComponent<LineCode>().EndObject = Selected;
            GO.GetComponent<LineRenderer>().SetWidth(.1f, .1f);
            GO.transform.parent = Selected.transform;
            pos[0] = GO.transform.position;
            pos[1] = GO.transform.position;
        }
        else
        {
            drawline = false;
            Debug.Log("Ended Drawing" + hitInfo.transform.gameObject.name);
            pos[1] = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GO.GetComponent<LineRenderer>().SetPositions(pos);
            GO.GetComponent<LineCode>().EndObject = hitInfo.transform;
            Selected = null;
        }
    }
}
