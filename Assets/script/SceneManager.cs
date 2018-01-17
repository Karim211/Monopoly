using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour {

	public void LoadScene( string nom )
	{
		//SceneManager.LoadScene (nom);
		Application.LoadLevel(1);
	}




















	/*static SceneManager Instance;
	// Use this for initialization
	void Start () {
		if (Instance != null) {

			GameObject.Destroy (gameObject);


		} else {

			GameObject.DontDestroyOnLoad (gameObject);
			Instance = this;

		}
		
	}
	
	// Update is called once per frame
	void Update () {

		if()
		{
			Application.LoadLevel(1);
		}


		
	}*/
}
