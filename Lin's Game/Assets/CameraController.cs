using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public float ZoomSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        zoom();
	}

    void zoom()
    {
        float y = ZoomSpeed * Input.mouseScrollDelta.y;
        Camera.main.orthographicSize = Camera.main.orthographicSize + y;
    }
}
