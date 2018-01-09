using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lancerdes : MonoBehaviour {

	public Animator anim;
	public KeyCode Lancer;
	public KeyCode Stop;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (Lancer)) {

		
			anim.SetTrigger ("active");	
			if (Input.GetKeyDown (Stop)) {

				int selectnumber = Random.Range (1, 6);
				if (selectnumber == 1) {
					anim.SetTrigger ("des1");
					PlayerPrefs.SetInt ("des1", 1);
					Debug.Log ("1er des = "+ selectnumber);
				}
				if (selectnumber == 2) {
					anim.SetTrigger ("des2");
					PlayerPrefs.SetInt ("des1", 2);
					Debug.Log ("1er des = "+ selectnumber);
				}
				if (selectnumber == 3) {
					anim.SetTrigger ("des3");
					PlayerPrefs.SetInt ("des1", 3);
					Debug.Log ("1er des = "+ selectnumber);
				}
				if (selectnumber == 4) {
					anim.SetTrigger ("des4");
					PlayerPrefs.SetInt ("des1", 4);
					Debug.Log ("1er des = "+ selectnumber);
				}
				if (selectnumber == 5) {
					anim.SetTrigger ("des5");
					PlayerPrefs.SetInt ("des1", 5);
					Debug.Log ("1er des = "+ selectnumber);
				}
				if (selectnumber == 6) {
					anim.SetTrigger ("des6");
					PlayerPrefs.SetInt ("des1", 6);
					Debug.Log ("1er des = "+ selectnumber);
				}
			}
		}
		
	}
}
