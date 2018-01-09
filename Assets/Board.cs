using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

    public int newPosition1;
    public int newPosition2;
    public int nbPion = 4;
    Case[] cases = new Case[40];
    public GameObject pion;
    private GameObject pion1,pion2;

    public Case[] GetCase()
    {
        return cases;
    }

	void Start () {
        

        cases[0] = new Case(new Vector3(48, -38, 0),0, CaseType.Depart, nbPion);
        cases[1] = new Case(new Vector3(38, -38, 0),1, CaseType.Depart, nbPion);
        cases[2] = new Case(new Vector3(29, -38, 0),2, CaseType.Depart, nbPion);
        cases[3] = new Case(new Vector3(21, -38, 0),3, CaseType.Depart, nbPion);
        cases[4] = new Case(new Vector3(13, -38, 0),4, CaseType.Depart, nbPion);
        cases[5] = new Case(new Vector3(5, -38, 0),5, CaseType.Depart, nbPion);
        cases[6] = new Case(new Vector3(-3, -38, 0),6, CaseType.Depart, nbPion);
        cases[7] = new Case(new Vector3(-11, -38, 0),7, CaseType.Depart, nbPion);
        cases[8] = new Case(new Vector3(-19, -38, 0),8, CaseType.Depart, nbPion);
        cases[9] = new Case(new Vector3(-27, -38, 0),9, CaseType.Depart, nbPion);
        cases[10] = new Case(new Vector3(-38, -38, 0),10, CaseType.Depart, nbPion);
        cases[11] = new Case(new Vector3(-38, -27, 0),11, CaseType.Depart, nbPion);
        cases[12] = new Case(new Vector3(-38, -19, 0),12, CaseType.Depart, nbPion);
        cases[13] = new Case(new Vector3(-38, -11, 0),13, CaseType.Depart, nbPion);
        cases[14] = new Case(new Vector3(-38, -3, 0),14, CaseType.Depart, nbPion);
        cases[15] = new Case(new Vector3(-38, 5, 0),15, CaseType.Depart, nbPion);
        cases[16] = new Case(new Vector3(-38, 13, 0),16, CaseType.Depart, nbPion);
        cases[17] = new Case(new Vector3(-38, 21, 0),17, CaseType.Depart, nbPion);
        cases[18] = new Case(new Vector3(-38, 29, 0),18, CaseType.Depart, nbPion);
        cases[19] = new Case(new Vector3(-38, 38, 0),19, CaseType.Depart, nbPion);
        cases[20] = new Case(new Vector3(-38, 48, 0),20, CaseType.Depart, nbPion);
        cases[21] = new Case(new Vector3(-27, 48, 0),21, CaseType.Depart, nbPion);
        cases[22] = new Case(new Vector3(-19, 48, 0),22, CaseType.Depart, nbPion);
        cases[23] = new Case(new Vector3(-11, 48, 0),23, CaseType.Depart, nbPion);
        cases[24] = new Case(new Vector3(-3, 48, 0),24, CaseType.Depart, nbPion);
        cases[25] = new Case(new Vector3(5, 48, 0),25, CaseType.Depart, nbPion);
        cases[26] = new Case(new Vector3(13, 48, 0),26, CaseType.Depart, nbPion);
        cases[27] = new Case(new Vector3(21, 48, 0),27, CaseType.Depart, nbPion);
        cases[28] = new Case(new Vector3(29, 48, 0),28, CaseType.Depart, nbPion);
        cases[29] = new Case(new Vector3(38, 48, 0),29, CaseType.Depart, nbPion);
        cases[30] = new Case(new Vector3(48, 48, 0),30, CaseType.Depart, nbPion);
        cases[31] = new Case(new Vector3(48, 38, 0),31, CaseType.Depart, nbPion);
        cases[32] = new Case(new Vector3(48, 29, 0),32, CaseType.Depart, nbPion);
        cases[33] = new Case(new Vector3(48, 21, 0),33, CaseType.Depart, nbPion);
        cases[34] = new Case(new Vector3(48, 13, 0),34, CaseType.Depart, nbPion);
        cases[35] = new Case(new Vector3(48, 5, 0),35, CaseType.Depart, nbPion);
        cases[36] = new Case(new Vector3(48, -3, 0),36, CaseType.Depart, nbPion);
        cases[37] = new Case(new Vector3(48, -11, 0),37, CaseType.Depart, nbPion);
        cases[38] = new Case(new Vector3(48, -19, 0),38, CaseType.Depart, nbPion);
        cases[39] = new Case(new Vector3(48, -27, 0),39, CaseType.Depart, nbPion);

        pion1 = Instantiate(pion, cases[0].getNewPionPositionPassage(), Quaternion.identity) as GameObject;
        cases[0].pions[0] = pion1;
        pion2 = Instantiate(pion, cases[0].getNewPionPositionPassage(), Quaternion.identity) as GameObject;
        cases[0].pions[1] = pion2;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Goto(newPosition1 ,pion1));
        }

        if (Input.GetKeyDown(KeyCode.Delete))
        {
            StartCoroutine(Goto(newPosition2, pion2));
        }
    }

    public int tranche(int a)
    {
        return (int)a / 10;
    }

    public IEnumerator Goto(int c ,GameObject objectPion)
    {
        BehaviourScript pion = objectPion.GetComponent<BehaviourScript>();
        cases[pion.position].isGone(objectPion);
        int trancheC = tranche(c);
        Vector3 newPionPosition;
        int tranchePos = tranche(pion.position);
        while (trancheC != tranchePos)
        {
            tranchePos = (tranchePos + 1) % 4;
            
            pion.position = tranchePos * 10 % 40;
            newPionPosition = GetCase()[pion.position].getNewPionPositionPassage();
            while (pion.transform.position != newPionPosition)
            {
                pion.transform.position = Vector2.MoveTowards(pion.transform.position,
                    newPionPosition, pion.speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
        }
        newPionPosition = GetCase()[c].getNewPionPosition(objectPion);
        while (pion.transform.position != newPionPosition)
        {
            pion.transform.position = Vector2.MoveTowards(pion.transform.position,
                newPionPosition, pion.speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForEndOfFrame();
        pion.position = c;

    }

    public IEnumerator transforme(GameObject ob, Vector3 target, float speed)
    {
        while (ob.transform.position != target)
        {
            ob.transform.position = Vector2.MoveTowards(ob.transform.position,
                target, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        
    }

}
