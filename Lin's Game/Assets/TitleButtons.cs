using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	public void Quit()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void LoadStory()
    {
        Debug.Log("Story Loaded");
        SceneManager.LoadScene("Story");
    }

    public void LoadStoryEditor()
    {
        Debug.Log("Story Editor Loaded");
        SceneManager.LoadScene("StoryEditor");
    }
}
