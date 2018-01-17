using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pionavance : MonoBehaviour {

	public float speed = 0.1f;
	Vector2 pos ;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		pos = transform.position;

		int valeurs = PlayerPrefs.GetInt ("des1");
		int valeurs2 = PlayerPrefs.GetInt ("des2");
		int valeurs3 = valeurs + valeurs2;


		//transform.Translate (new Vector3 (-valeurs3, -1, 0));	
		while (pos.x < (pos.x + (valeurs3 * (-1)))) {
			transform.Translate (Vector3.left * speed * Time.deltaTime);
		}
		//pos.x = pos.x + (valeurs3*(-0.5));
		transform.position = pos;

		
	}
}
