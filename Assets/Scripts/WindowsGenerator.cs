using UnityEngine;
using System.Collections;

public class WindowsGenerator : MonoBehaviour {
	int i = 0;
	GameObject originalWindow = null;

	// Use this for initialization
	void Start () {
		originalWindow = GameObject.Find("AnimatedSprite_original");
	    for(int m = 0;m < 3;m++)
		{
			for(int n = 0; n < 3;n++)
			{
				GameObject window = Instantiate(originalWindow) as GameObject;
				window.name = "AnimatedSprite" + "_"  + m.ToString() + n.ToString();
			}
		}
	//	GameObject tt = Instantiate(GameObject.Find("AnimatedSprite_00"))as GameObject;

	//	tt.name = "AnimatedSprite_01";
		//Debug.Log(i++.ToString());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
