using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lancerdes : MonoBehaviour {

	public Animator anim;
	public KeyCode Lancer;
	public KeyCode Stop;
    public int nb;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (Lancer)) {

			anim.SetTrigger ("active");	
			//if (Input.GetKeyDown (Stop)) {
			//	int selectnumber = Random.Range (1, 6);
			//	anim.SetTrigger ("des"+selectnumber);
			//    PlayerPrefs.SetInt ("des"+nb, selectnumber);
			//}
		}
        if (Input.GetKeyDown(Stop))
        {
            int selectnumber = Random.Range(1, 6);
            anim.SetTrigger("des" + selectnumber);
            PlayerPrefs.SetInt("des" + nb, selectnumber);
        }
    }
}
