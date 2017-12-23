using UnityEngine;
using System.Collections;

public class SetImageHolder : MonoBehaviour {

    Transform[] Sides;


    public float ApsectRation;
    public Vector2 Resolution;

	// Use this for initialization
	void Start () {

        Sides = transform.GetComponentsInChildren<Transform>();

	}
	
}
