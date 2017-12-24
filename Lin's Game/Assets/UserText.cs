using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserText : MonoBehaviour {

    public bool typing = false;

    string Text = "";

    TextMesh TM;
	// Use this for initialization
	void Start () {
        TM = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
        if (typing)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Text = Text + "\n";
            }
            else if (Input.GetKeyDown(KeyCode.Backspace))
            {
                Debug.Log(Text.Length);
                Text = Text.Remove(Text.Length - 1, 1);
            }
            else
            {
                foreach (char Letter in Input.inputString)
                {
                    Text = Text + Letter;
                }
            }
            TM.text = Text;
        }
	}
}
//open.file("cock_suckerr)
//    run.file("guzzle")