using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class somme3 : MonoBehaviour {

	int argent1 = 2000;
	int argent2 = 2000;
	int argent3 = 2000;
	//int argent4 = 2000;
	GUISkin labelskin;



	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void OnGUI(){
		GUI.skin = labelskin;
		GUI.skin.label.fontSize = 25;
		GUI.skin.label.fontStyle = FontStyle.Bold;
		GUI.color = Color.black;
		GUI.Label (new Rect (25, 300, 1000, 1000),"Somme : " + argent1 + "€");
		GUI.Label (new Rect (850, 140, 1000, 1000),"Somme : "+ argent2 + "€");
		GUI.Label (new Rect (860, 500, 1000, 1000),"Somme : "+ argent3 + "€");
		//GUI.Label (new Rect (860, 100, 1000, 1000),"Somme : " + argent4 + "€");



	}
}
