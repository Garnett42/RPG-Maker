using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ExitButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public void ExitToTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void OpenOptions()
    {
        //TODO: CreateOptionsPanel
    }
}
