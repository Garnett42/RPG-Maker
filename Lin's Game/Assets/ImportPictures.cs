using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class ImportPictures : MonoBehaviour {

    string filepath;
    public GameObject Picture;

	// Use this for initialization
	void Start () {
        filepath = Application.streamingAssetsPath;
        DirectoryInfo d = new DirectoryInfo(filepath);
        int x = 0;
        int y = 0;

        float Width = 0;
        float Height = 0;

        foreach (var file in d.GetFiles("*.png"))
        {
            Debug.Log("Importing" + file.FullName);

            GameObject GO = Instantiate(Picture, transform);
            GO.AddComponent<SpriteRenderer>();
            GO.name = file.Name;
            Texture2D tex = LoadPNG(file.FullName);
            Debug.Log(tex.ToString());
            GO.GetComponent<SpriteRenderer>().sprite = Sprite.Create(tex, 
                                                                     new Rect(0, 0, tex.width, tex.height), 
                                                                     new Vector2(.5f, .5f)
                                                                     );
            GO.tag = "Drag";
            GO.AddComponent<BoxCollider>();


            Vector2 SPoint = new Vector2(1.2f*Width*x, 1.2f*Height*y);
            GO.transform.position = SPoint;
            y++;
            if (y > 3)
            {
                x++;
                y = 0;
            }
            
            Width = GO.GetComponent<BoxCollider>().size.x;
            Height = GO.GetComponent<BoxCollider>().size.y;

            Transform SpawnT = GO.transform.GetChild(0);
            Transform SpawnB = GO.transform.GetChild(1);
            
            SpawnT.position = GO.transform.position + new Vector3(Width / 2 ,Height/2, -1);
            SpawnB.position = GO.transform.position + new Vector3(-Width / 2, Height / 2, -1);

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static Texture2D LoadPNG(string filePath)
    {

        Texture2D tex = null;
        byte[] fileData;

        if (File.Exists(filePath))
        {
            Debug.Log("File Exist");
            fileData = File.ReadAllBytes(filePath);
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
        }
        return tex;
    }
}
