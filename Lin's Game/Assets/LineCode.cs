using UnityEngine;
using System.Collections;

public class LineCode : MonoBehaviour {

    LineRenderer line;

    public Transform EndObject;

	// Use this for initialization
	void Start () {
        line = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        line.SetPosition(0, transform.parent.transform.position);
        line.SetPosition(1, EndObject.position);
	}
}
