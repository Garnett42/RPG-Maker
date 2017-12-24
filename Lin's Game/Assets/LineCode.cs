using UnityEngine;
using System.Collections;

public class LineCode : MonoBehaviour {

    LineRenderer line;

    public Transform EndObject;

    Transform Knob;

	// Use this for initialization
	void Start () {
        line = GetComponent<LineRenderer>();
        Knob = transform.GetChild(0).transform;
	}
	
	// Update is called once per frame
	void Update () {
        line.SetPosition(0, transform.parent.position);
        line.SetPosition(1, EndObject.position);

        Knob.position = transform.parent.position + (EndObject.position - transform.parent.position) * .5f;
	}
}
