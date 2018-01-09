using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourScript : MonoBehaviour {

    public int position=0;
    public float speed = 30;

    //void Update () {

    //       if (Input.GetKeyUp(KeyCode.LeftArrow))
    //       {

    //           StartCoroutine(transforme(this.gameObject,target, speed));

    //       }
    //}

    //public void Goto(int c)
    //{
    //    int trancheC = tranche(c);
    //    int tranchePos = tranche(postion);
    //    while(trancheC != tranchePos)
    //    {
    //        tranchePos = (tranchePos + 1) % 4;
    //        postion = tranchePos * 10 % 40;
    //        StartCoroutine(transforme(gameObject, b.GetCase()[postion].position, speed));
    //    }

    //    StartCoroutine(transforme(gameObject, b.GetCase()[c].position, speed));
    //    postion = c;

    //}

    //public IEnumerator transforme(GameObject ob, Vector3 target, float speed)
    //{
    //    while(ob.transform.position != target)
    //    {
    //        ob.transform.position = Vector3.MoveTowards(ob.transform.position, target, speed * Time.deltaTime);
    //        yield return new WaitForEndOfFrame();
    //    }
    //}

    //public int tranche(int a)
    //{
    //    return (int)a / 10;
    //}
}
