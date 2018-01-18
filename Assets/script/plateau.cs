using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class plateau : MonoBehaviour {

    public int nbPion = 2;
    public int newposition;
    private int tour=0;//une vareable desider du tour 0-> jouer1 || 1->jouer2 ...
    private GameObject realDe1,realDe2,affichage1,affichage2; //les instase des dés et des affichage
    Case[] cases = new Case[40]; //l'ensemble des ceses
    public GameObject[] pion = new GameObject[4]; //les 4 pions NP: il ne serand pas tous instancier 
    public GameObject[] pions = new GameObject[4]; //les pions instancier
    public UnityEvent tourDeJeux = new UnityEvent(); //creation d'un evenement 

    void Start()
    {

        // initialisation des cases
        cases[0] = new Case(new Vector3(2.1f, -2.1f, 0), 0, CaseType.Depart, nbPion);
        cases[1] = new Case(new Vector3(1.66f, -2.1f, 0), 1, CaseType.Depart, nbPion);
        cases[2] = new Case(new Vector3(1.25f, -2.1f, 0), 2, CaseType.Depart, nbPion);
        cases[3] = new Case(new Vector3(0.84f, -2.1f, 0), 3, CaseType.Depart, nbPion);
        cases[4] = new Case(new Vector3(0.43f, -2.1f, 0), 4, CaseType.Depart, nbPion);
        cases[5] = new Case(new Vector3(0.02f, -2.1f, 0), 5, CaseType.Depart, nbPion);
        cases[6] = new Case(new Vector3(-0.39f, -2.1f, 0), 6, CaseType.Depart, nbPion);
        cases[7] = new Case(new Vector3(-0.8f, -2.1f, 0), 7, CaseType.Depart, nbPion);
        cases[8] = new Case(new Vector3(-1.21f, -2.1f, 0), 8, CaseType.Depart, nbPion);
        cases[9] = new Case(new Vector3(-1.62f, -2.1f, 0), 9, CaseType.Depart, nbPion);
        cases[10] = new Case(new Vector3(-2.1f, -2.1f, 0), 10, CaseType.Depart, nbPion);
        cases[11] = new Case(new Vector3(-2.1f, -1.62f, 0), 11, CaseType.Depart, nbPion);
        cases[12] = new Case(new Vector3(-2.1f, -1.21f, 0), 12, CaseType.Depart, nbPion);
        cases[13] = new Case(new Vector3(-2.1f, -0.8f, 0), 13, CaseType.Depart, nbPion);
        cases[14] = new Case(new Vector3(-2.1f, -0.39f, 0), 14, CaseType.Depart, nbPion);
        cases[15] = new Case(new Vector3(-2.1f, 0.02f, 0), 15, CaseType.Depart, nbPion);
        cases[16] = new Case(new Vector3(-2.1f, 0.43f, 0), 16, CaseType.Depart, nbPion);
        cases[17] = new Case(new Vector3(-2.1f, 0.84f, 0), 17, CaseType.Depart, nbPion);
        cases[18] = new Case(new Vector3(-2.1f, 1.25f, 0), 18, CaseType.Depart, nbPion);
        cases[19] = new Case(new Vector3(-2.1f, 1.66f, 0), 19, CaseType.Depart, nbPion);
        cases[20] = new Case(new Vector3(-2.1f, 2.1f, 0), 20, CaseType.Depart, nbPion);
        cases[21] = new Case(new Vector3(-1.62f, 2.1f, 0), 21, CaseType.Depart, nbPion);
        cases[22] = new Case(new Vector3(-1.21f, 2.1f, 0), 22, CaseType.Depart, nbPion);
        cases[23] = new Case(new Vector3(-0.8f, 2.1f, 0), 23, CaseType.Depart, nbPion);
        cases[24] = new Case(new Vector3(-0.39f, 2.1f, 0), 24, CaseType.Depart, nbPion);
        cases[25] = new Case(new Vector3(0.02f, 2.1f, 0), 25, CaseType.Depart, nbPion);
        cases[26] = new Case(new Vector3(0.43f, 2.1f, 0), 26, CaseType.Depart, nbPion);
        cases[27] = new Case(new Vector3(0.84f, 2.1f, 0), 27, CaseType.Depart, nbPion);
        cases[28] = new Case(new Vector3(1.25f, 2.1f, 0), 28, CaseType.Depart, nbPion);
        cases[29] = new Case(new Vector3(1.66f, 2.1f, 0), 29, CaseType.Depart, nbPion);
        cases[30] = new Case(new Vector3(2.1f, 2.1f, 0), 30, CaseType.Depart, nbPion);
        cases[31] = new Case(new Vector3(2.1f, 1.66f, 0), 31, CaseType.Depart, nbPion);
        cases[32] = new Case(new Vector3(2.1f, 1.25f, 0), 32, CaseType.Depart, nbPion);
        cases[33] = new Case(new Vector3(2.1f, 0.84f, 0), 33, CaseType.Depart, nbPion);
        cases[34] = new Case(new Vector3(2.1f, 0.43f, 0), 34, CaseType.Depart, nbPion);
        cases[35] = new Case(new Vector3(2.1f, 0.02f, 0), 35, CaseType.Depart, nbPion);
        cases[36] = new Case(new Vector3(2.1f, -0.39f, 0), 36, CaseType.Depart, nbPion);
        cases[37] = new Case(new Vector3(2.1f, -0.8f, 0), 37, CaseType.Depart, nbPion);
        cases[38] = new Case(new Vector3(2.1f, -1.21f, 0), 38, CaseType.Depart, nbPion);
        cases[39] = new Case(new Vector3(2.1f, -1.62f, 0), 39, CaseType.Depart, nbPion);
        //instatiation des pion dans la case 0 
        for(int i = 0; i < nbPion; i++){
            pions[i] = Instantiate(pion[i], cases[0].getNewPionPositionPassage(), Quaternion.identity) as GameObject;
            cases[0].pions[i] = pions[i];//on indique a la case 0 que le pion[i] est dedans 
            pions[i].transform.SetParent(gameObject.transform, false); //on fix le parand du pion
        }
        //la meme chose pour les des
        realDe1 = GameObject.Find("des1");
        realDe2 = GameObject.Find("des2");

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //invocer l'evenement tour du jouer
            tourDeJeux.Invoke();
        }
    }

    public int tranche(int a)
    {
        return (int)a / 10;
    }

    public void startAnimation()
    {
        StartCoroutine(Goto(pions[tour]));
    }

    public IEnumerator Goto(GameObject objectPion)
    {
        yield return new WaitForSeconds(3);
        PionScript pion = objectPion.GetComponent<PionScript>();
        int c = PlayerPrefs.GetInt("des1") + PlayerPrefs.GetInt("des2");
        c = (c + pion.position) % 40; 
        cases[pion.position].isGone(objectPion);
        int trancheC = tranche(c);
        Vector3 newPionPosition;
        int tranchePos = tranche(pion.position);
        Debug.Log("c = " + c);
        while (trancheC != tranchePos)
        {
            tranchePos = (tranchePos + 1) % 4;

            pion.position = tranchePos * 10 % 40;
            newPionPosition = cases[pion.position].getNewPionPositionPassage();
            Debug.Log("new pion position = " + newPionPosition);
            Debug.Log("tranche position = " + tranchePos);
            Debug.Log("pion position = " + pion.position);
            while (objectPion.transform.localPosition != newPionPosition)
            {
                objectPion.transform.localPosition = Vector2.MoveTowards(objectPion.transform.localPosition,
                    newPionPosition, pion.speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
        }
        pion.position = c;
        Debug.Log("pion position = " + pion.position);
        newPionPosition = cases[c].getNewPionPosition(objectPion);
        while (objectPion.transform.localPosition != newPionPosition)
        {
            objectPion.transform.localPosition = Vector2.MoveTowards(objectPion.transform.localPosition,
                newPionPosition, pion.speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForEndOfFrame();
        string suivant = jouerSuivant();
        realDe1.transform.SetParent(GameObject.Find(suivant).transform, false);
        realDe2.transform.SetParent(GameObject.Find(suivant).transform, false);

    }
    // retourn le nom de l'affichage du jouer suivant
    public string jouerSuivant()
    {
        tour = (tour + 1) % nbPion;
        return "afficheJ" + (tour + 1);
    }

}