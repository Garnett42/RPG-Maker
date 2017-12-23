using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject GO;
    public bool Spawning;
	// Use this for initialization
	void Start () {
        Spawning = false;
	}
	
	// Update is called once per frame
	void Update () {
        SpawnImage();
	}

    void SpawnImage()
    {
        if(Input.GetMouseButtonDown(0) && Spawning)
        Instantiate(GO, (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
    }
}
