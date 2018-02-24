using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lancerdes : MonoBehaviour {

	public Animator anim;
	public KeyCode Lancer;
	public KeyCode Stop;
    public int nb;

    public void startAnimation()
    {
        anim.SetTrigger("active");
        int selectnumber = Random.Range(1, 6);
        anim.SetTrigger("des" + selectnumber);
        //PlayerPrefs.SetInt("des" + nb, selectnumber);
        PlayerPrefs.SetInt("des" + nb, 5);
    }

}
