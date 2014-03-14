using UnityEngine;
using System.Collections;

public class OnSpriteChange : MonoBehaviour {
	tk2dSprite sprite;
	// Use this for initialization
	void Start () {
		sprite = GetComponent<tk2dSprite>();

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.A))
		{
			int spriteId = sprite.GetSpriteIdByName("lightoff");
			sprite.SetSprite(spriteId);
		}
	}
}
