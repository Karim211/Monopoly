using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musique : MonoBehaviour {


	Object[] mamusique;

	void Awake(){

		mamusique = Resources.LoadAll ("Musique", typeof(AudioClip));
		GetComponent<AudioSource>().clip = mamusique [0] as AudioClip;
	}

	// Use this for initialization
	void Start () {
		GetComponent<AudioSource> ().Play ();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!GetComponent<AudioSource> ().isPlaying) {
		     GetComponent<AudioSource> ().Play ();
		}
		
	}
}
