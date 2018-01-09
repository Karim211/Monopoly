using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boucledollars : MonoBehaviour {
	
	public float speed = 0.1f;
	Vector2 pos ;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		pos = transform.position;

		//transform.Translate (new Vector3 (0, 1, 0), 0.2 * Time.deltaTime);	
		transform.Translate(Vector3.down*speed*Time.deltaTime);
		if (pos.y < -24.6){
			pos.y = -0;
			transform.position = pos;
		}

	}

}
