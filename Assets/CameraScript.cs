using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //s'assure que la camera est a ca place 
        GameObject Board = GameObject.Find("Board");
        transform.position = new Vector3(Board.transform.position.x, Board.transform.position.y,-10);
        Debug.Log("Camera "+transform.position);
        Debug.Log("Bord " + Board.transform.position);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
