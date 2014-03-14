using UnityEngine;
using System.Collections;

public class lightchangeScript : MonoBehaviour {

	// Link to the animated sprite
	private tk2dSpriteAnimator anim;
	private Transform n;

	// State variable to see if the light is on.
//	private bool lightoff = false;

	// Use this for initialization
	void Start () {
		anim = GetComponent<tk2dSpriteAnimator> ();
		n = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.G)) {
			if (!anim.IsPlaying("lighton-off")) {
				anim.Play("lighton-off");
//				lightoff = true;

			}
		}
		if (Input.GetKey (KeyCode.K)) {
			//if (!anim.IsPlaying("lightoff-on")&lightoff == true) {
			if (!anim.IsPlaying("lightoff-on")) {
				anim.Play("lightoff-on");
//				lightoff = false;
				
			}
		}
	}
}