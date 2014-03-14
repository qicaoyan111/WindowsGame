﻿using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
public class onClickScript : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
				if (hit.collider != null){
					//hit.collider.enabled = false;

					string[] name = Regex.Split(hit.collider.name,"_");
			        Debug.Log("Got it!"+name[1][0]+","+"Got it!"+name[1][1]);

				    

									
	}
	
	}
}
}