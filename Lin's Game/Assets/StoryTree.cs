using UnityEngine;
using System.Collections;

public class node
{
    public node parent;
    //public List<node> children;

    node()
    {
        parent = null;
        //children = new List<node>();
    }

}

public class StoryTree : MonoBehaviour {

    node root;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
