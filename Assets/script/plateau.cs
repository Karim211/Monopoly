using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class plateau : MonoBehaviour {

    public static Dictionary<int, Vector3> dictionary;
    public int nbPion = 2;
    public int newposition;
    private int tour=0;//une vareable desider du tour 0-> jouer1 || 1->jouer2 ...
    private GameObject realDe1,realDe2,affichage1,affichage2; //les instase des dés et des affichage
    Case[] cases = new Case[40]; //l'ensemble des ceses
    public GameObject[] pion = new GameObject[4]; //les 4 pions NP: il ne serand pas tous instancier 
    public GameObject[] pions; //les pions instancier
    //public UnityEvent tourDeJeux = new UnityEvent(); //creation d'un evenement
    private Banque banque;
    private dé dé;
    public GameObject[] carte = new GameObject[40];
    public static GameObject[] cartes = new GameObject[40];
    public bool occuper = false;
    GUISkin labelskin;


    void Start()
    {
        pions = new GameObject[nbPion];
        dictionary = new Dictionary<int, Vector3>();
        dictionary.Add(0, new Vector3(2.1f, -2.1f, 0));
        dictionary.Add(1, new Vector3(1.66f, -2.1f, 0));
        dictionary.Add(2, new Vector3(1.25f, -2.1f, 0));
        dictionary.Add(3, new Vector3(0.84f, -2.1f, 0));
        dictionary.Add(4, new Vector3(0.43f, -2.1f, 0));
        dictionary.Add(5, new Vector3(0.02f, -2.1f, 0));
        dictionary.Add(6, new Vector3(-0.39f, -2.1f, 0));
        dictionary.Add(7, new Vector3(-0.8f, -2.1f, 0));
        dictionary.Add(8, new Vector3(-1.21f, -2.1f, 0));
        dictionary.Add(9, new Vector3(-1.62f, -2.1f, 0));
        dictionary.Add(10, new Vector3(-2.1f, -2.1f, 0));
        dictionary.Add(11, new Vector3(-2.1f, -1.62f, 0));
        dictionary.Add(12, new Vector3(-2.1f, -1.21f, 0));
        dictionary.Add(13, new Vector3(-2.1f, -0.8f, 0));
        dictionary.Add(14, new Vector3(-2.1f, -0.39f, 0));
        dictionary.Add(15, new Vector3(-2.1f, 0.02f, 0));
        dictionary.Add(16, new Vector3(-2.1f, 0.43f, 0));
        dictionary.Add(17, new Vector3(-2.1f, 0.84f, 0));
        dictionary.Add(18, new Vector3(-2.1f, 1.25f, 0));
        dictionary.Add(19, new Vector3(-2.1f, 1.66f, 0));
        dictionary.Add(20, new Vector3(-2.1f, 2.1f, 0));
        dictionary.Add(21, new Vector3(-1.62f, 2.1f, 0));
        dictionary.Add(22, new Vector3(-1.21f, 2.1f, 0));
        dictionary.Add(23, new Vector3(-0.8f, 2.1f, 0));
        dictionary.Add(24, new Vector3(-0.39f, 2.1f, 0));
        dictionary.Add(25, new Vector3(0.02f, 2.1f, 0));
        dictionary.Add(26, new Vector3(0.43f, 2.1f, 0));
        dictionary.Add(27, new Vector3(0.84f, 2.1f, 0));
        dictionary.Add(28, new Vector3(1.25f, 2.1f, 0));
        dictionary.Add(29, new Vector3(1.66f, 2.1f, 0));
        dictionary.Add(30, new Vector3(2.1f, 2.1f, 0));
        dictionary.Add(31, new Vector3(2.1f, 1.66f, 0));
        dictionary.Add(32, new Vector3(2.1f, 1.25f, 0));
        dictionary.Add(33, new Vector3(2.1f, 0.84f, 0));
        dictionary.Add(34, new Vector3(2.1f, 0.43f, 0));
        dictionary.Add(35, new Vector3(2.1f, 0.02f, 0));
        dictionary.Add(36, new Vector3(2.1f, -0.39f, 0));
        dictionary.Add(37, new Vector3(2.1f, -0.8f, 0));
        dictionary.Add(38, new Vector3(2.1f, -1.21f, 0));
        dictionary.Add(39, new Vector3(2.1f, -1.62f, 0));
        banque = new Banque();
        dé = new dé();
        cases = new Case[40];

        cases[0] = new CaseDépart(0, CaseType.Depart);
        cases[7] = new CaseChance(7, CaseType.Chanse);
        cases[22] =  new CaseChance(22, CaseType.Chanse);
        cases[36] = new CaseChance(36, CaseType.Chanse);
        cases[2] = new CaseCommunauté(2, CaseType.Cmmunaute);
        cases[17] = new CaseCommunauté(17, CaseType.Cmmunaute);
        cases[33] = new CaseCommunauté(33, CaseType.Cmmunaute);
        cases[30] = new caseAllezEnPrison(30, CaseType.AllezPrison);
        cases[20] = new CaseParcGratuit(20, CaseType.ParcGratuit);
        cases[10] = new casePrison(10, CaseType.Prison);
        cases[12] = new CaseCompagnie(12, CaseType.compagnie, typeProprieté.libre, 140, null, 4, 750);
        cases[28] = new CaseCompagnie(28, CaseType.compagnie, typeProprieté.libre, 150, null, 4, 750);
        cases[25] = new CaseGare(25, CaseType.Gare, typeProprieté.libre, 200, null, 25, 100);
        cases[5] = new CaseGare(5, CaseType.Gare, typeProprieté.libre, 200, null, 25, 100);
        cases[15] = new CaseGare(15, CaseType.Gare, typeProprieté.libre, 200, null, 25, 100);
        cases[35] = new CaseGare(35, CaseType.Gare, typeProprieté.libre, 200, null, 25, 100);
        cases[4] = new CaseImpot(4, CaseType.Impot);
        cases[38] = new CaseTaxeLux(38, CaseType.Taxe);
        cases[1] = new CaseTerrain(1, CaseType.Proprieté, "Boulevard De Belleville", typeProprieté.libre, 60, null, 20, couleur.mauve, 30, 50, 50);
        cases[3] = new CaseTerrain(3, CaseType.Proprieté, "Rue Le Courbe", typeProprieté.libre, 60, null, 40, couleur.mauve, 30, 50, 50);
        cases[37] = new CaseTerrain(37, CaseType.Proprieté, "Avenue Des Champs Elysées", typeProprieté.libre, 350, null, 350, couleur.bleu, 175, 200, 200);
        cases[39] = new CaseTerrain(39, CaseType.Proprieté, "Rue De La Paix", typeProprieté.libre, 400, null, 350, couleur.bleu, 200, 200, 200);
        cases[6] = new CaseTerrain(6, CaseType.Proprieté, "Rue De Vaugirard", typeProprieté.libre, 100, null, 60, couleur.BleuTurquoise, 50, 50, 50);
        cases[9] = new CaseTerrain(9, CaseType.Proprieté, "Avenue De La République", typeProprieté.libre, 120, null, 80, couleur.BleuTurquoise, 60, 50, 50);
        cases[8] = new CaseTerrain(8, CaseType.Proprieté, "Rue  De Courcelles", typeProprieté.libre, 100, null, 60, couleur.BleuTurquoise, 50, 50, 50);
        cases[11] = new CaseTerrain(11, CaseType.Proprieté, "Boulevard De La Villette", typeProprieté.libre, 140, null, 100, couleur.mauve, 70, 100, 100);
        cases[13] = new CaseTerrain(13, CaseType.Proprieté, "Avenue De Neuilly", typeProprieté.libre, 140, null, 100, couleur.mauve, 70, 100, 100);
        cases[14] = new CaseTerrain(14, CaseType.Proprieté, "Rue De Paradis", typeProprieté.libre, 160, null, 120, couleur.mauve, 80, 100, 100);
        cases[16] = new CaseTerrain(16, CaseType.Proprieté, "Avenue Mozart", typeProprieté.libre, 180, null, 140, couleur.orange, 90, 100, 100);
        cases[18] = new CaseTerrain(18, CaseType.Proprieté, "Boulevard Saint Michel", typeProprieté.libre, 180, null, 140, couleur.orange, 90, 100, 100);
        cases[19] = new CaseTerrain(19, CaseType.Proprieté, "Place Pigalle", typeProprieté.libre, 200, null, 160, couleur.orange, 100, 100, 100);
        cases[21] = new CaseTerrain(21, CaseType.Proprieté, "Avenue Matignon", typeProprieté.libre, 220, null, 160, couleur.rouge, 110, 150, 150);
        cases[23] = new CaseTerrain(23, CaseType.Proprieté, "Boulevard Malesherbes", typeProprieté.libre, 220, null, 180, couleur.rouge, 110, 150, 150);
        cases[24] = new CaseTerrain(24, CaseType.Proprieté, "Avenue Henri Martin", typeProprieté.libre, 240, null, 200, couleur.rouge, 120, 150, 150);
        cases[26] = new CaseTerrain(26, CaseType.Proprieté, "Faubourg Saint Honoré", typeProprieté.libre, 260, null, 220, couleur.jeune, 130, 150, 150);
        cases[27] = new CaseTerrain(27, CaseType.Proprieté, "Place De La Bourse", typeProprieté.libre, 260, null, 220, couleur.jeune, 130, 150, 150);
        cases[29] = new CaseTerrain(29, CaseType.Proprieté, "Rue La Fayette", typeProprieté.libre, 280, null, 240, couleur.jeune, 140, 150, 150);
        cases[31] = new CaseTerrain(31, CaseType.Proprieté, "Avenue De Breteuil", typeProprieté.libre, 300, null, 260, couleur.vert, 150, 200, 200);
        cases[32] = new CaseTerrain(32, CaseType.Proprieté, "Avenue Foche", typeProprieté.libre, 300, null, 260, couleur.vert, 150, 200, 200);
        cases[34] = new CaseTerrain(34, CaseType.Proprieté, "Boulevard Des Capucines", typeProprieté.libre, 320, null, 280, couleur.vert, 160, 200, 200);

        for (int i = 0; i < 40; i++) {
            if (carte[i] != null)
            {
                cartes[i] = Instantiate(carte[i], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                cartes[i].transform.SetParent(gameObject.transform, false);
                cartes[i].transform.localScale = new Vector3(0.75f, 0.75f, 0);
                cartes[i].layer = 4;
                cartes[i].SetActive(false);
            }
        }

        //instatiation des pion dans la case 0 
        for (int i = 0; i < nbPion; i++){
            pions[i] = Instantiate(pion[i], cases[0].getNewPionPositionPassage(), Quaternion.identity) as GameObject;
            pions[i].GetComponent<PionScript>().newJoueur();
            cases[0].pions[i] = pions[i];//on indique a la case 0 que le pion[i] est dedans 
            pions[i].transform.SetParent(gameObject.transform, false); //on fix le parand du pion
            pions[i].GetComponent<PionScript>().newJoueur();
        }
        //la meme chose pour les des
        realDe1 = GameObject.Find("des1");
        realDe2 = GameObject.Find("des2");

        Debug.Log("+++++++" + pions[0].GetComponent<PionScript>().getSolde());

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !occuper)
        {
            //invocer l'evenement tour du jouer
            occuper = true;
            //tourDeJeux.Invoke();
            startAnimation();
        }
    }

    public int tranche(int a)
    {
        return (int)a / 10;
    }

    public void startAnimation()
    {
        Debug.Log("pion = " + pions[tour].name);
        StartCoroutine(quandCestVotreTour(pions[tour]));

    }


	public IEnumerator affichercarte(int c){
        if(cartes[c] != null)
        {
            cartes[c].SetActive(true);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            cartes[c].SetActive(false);
        }
	}


    public IEnumerator Goto(GameObject objectPion,int c)
    {
        PionScript pion = objectPion.GetComponent<PionScript>();
        cases[pion.getPosition2()].isGone(objectPion);
        int trancheC = tranche(c);
        Vector3 newPionPosition;
        int tranchePos = tranche(pion.getPosition2());
        

        while (trancheC != tranchePos)
        {
            tranchePos = (tranchePos + 1) % 4;

            pion.seDeplacer(tranchePos * 10 % 40);
		
			// pion.position ==0 ajouter 100

            newPionPosition = cases[pion.getPosition2()].getNewPionPositionPassage();           
			while (objectPion.transform.localPosition != newPionPosition)
            {
                objectPion.transform.localPosition = Vector2.MoveTowards(objectPion.transform.localPosition,
                    newPionPosition, pion.speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
        }

        newPionPosition = cases[c].getNewPionPosition(objectPion);
        while (objectPion.transform.localPosition != newPionPosition)
        {
            objectPion.transform.localPosition = Vector2.MoveTowards(objectPion.transform.localPosition,
                newPionPosition, pion.speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForEndOfFrame();
        yield return affichercarte(c);

    }
    // retourn le nom de l'affichage du jouer suivant
    public void jouerSuivant()
    {
        tour = (tour + 1) % nbPion;
        string suivant =  "afficheJ" + (tour + 1);
        realDe1.transform.SetParent(GameObject.Find(suivant).transform, false);
        realDe2.transform.SetParent(GameObject.Find(suivant).transform, false);
        occuper = false;

    }

    public void addCarte(int joueur,int c)
    {
        int nombreProp = pions[joueur].GetComponent<PionScript>().GetListPropriété().Count;
        cartes[c].SetActive(true);
        cartes[c].transform.SetParent(GameObject.Find("carteJ" + (joueur+1)).transform, false);
        cartes[c].transform.localPosition = new Vector3(2 - (0.79f * (nombreProp % 4)), 1.95f - (0.934f * (nombreProp % 5)), 0);
        cartes[c].transform.localScale = new Vector2(0.2f, 0.15f);
    }

    public GameObject quiJoueEnPremier()
    {
        int max = -1, pos = 0;
        for (int i = 0; i < pions.Length; i++)
        {
            Debug.Log("joeur " + i + " lance le dé:");
            dé.lancerDé();
            Debug.Log("valeur de dé : " + dé.getValeurDé());

            if (dé.getValeurDé() > max)
            {
                max = dé.getValeurDé();
                pos = i;
            }

        }

        Debug.Log("PionScript " + pos + " joue en premier");
        return pions[pos];
    }

    public IEnumerator quandCestVotreTour(GameObject pion)
    {
        PionScript j = pion.GetComponent<PionScript>();
        int cmpt = 0;
        int c;
        bool p = true;
        do
        { 
            
            if (j.getEtat().Equals(etatJoueur.prisonnier))
            {
                sortirDePrison(j);
            }
            if (j.getEtat().Equals(etatJoueur.libre))
            {
                cmpt++;
                realDe1.GetComponent<lancerdes>().startAnimation();
                realDe2.GetComponent<lancerdes>().startAnimation();

                yield return new WaitForSeconds(3);
                dé.lancerDé();

                c = PlayerPrefs.GetInt("des1") + PlayerPrefs.GetInt("des2");
                c = (c + j.getPosition2()) % 40;

                p = dé.isDouble();
                yield return Goto(pion, c);
                j.setPosition2(c);
                Console.WriteLine("cmpt= " + cmpt + " isDouble= " + p + " valeurDe= " + dé.getValeurDé());

                ///////////////////////////////////////////////////////////////
                Console.WriteLine("voulez vous construire ?? (si oui tapez 1)");
                int réponse = 0; //int.Parse(Console.ReadLine());
                if (réponse == 1)
                {
                    Console.WriteLine("ou voulez vous construire??(tapez le nombre)");
                    j.afficherProprieté();
                    int réponse1 = int.Parse(Console.ReadLine());

                    Console.WriteLine("que voulez vous construire ?? (maison tapez 1 hotel tapez 2)");
                    réponse = int.Parse(Console.ReadLine());
                    if (réponse == 1)
                    {
                        CaseTerrain t = (CaseTerrain)cases[réponse1];
                        j.construireMaison(t);
                        Console.WriteLine("loyer : " + t.getPrixLoyer() + " maison: " + t.getNombreDeMaison() + " hotel:" + t.isHotelHere());
                    }
                    else
                    {
                        CaseTerrain t = (CaseTerrain)cases[réponse1];
                        j.construireHotel(t);
                        Console.WriteLine("loyer : " + t.getPrixLoyer() + " maison: " + t.getNombreDeMaison() + " hotel:" + t.isHotelHere());
                    }

                }

                if (cases[j.getPosition2()].getCaseType().Equals(CaseType.Proprieté))
                {
                    Propriété pr = (Propriété)cases[j.getPosition2()];
                    if (pr.getTypeProprieté().Equals(typeProprieté.libre))
                    {
                        proprietéNappartenantAPersonne(j);
                    }
                    else
                    {
                        if (j != pr.getPropriétaire())
                            proprietéAppartenantAUnePersonne(j);
                    }
                }
                else if (cases[j.getPosition2()].getCaseType().Equals(CaseType.Gare))
                {
                    CaseGare pr = (CaseGare)cases[j.getPosition2()];
                    if (pr.getTypeProprieté().Equals(typeProprieté.libre))
                    {
                        proprietéNappartenantAPersonne(j);
                    }
                    else
                    {
                        if (j != pr.getPropriétaire())
                            proprietéAppartenantAUnePersonne(j);
                    }
                }
                else if (cases[j.getPosition2()].getCaseType().Equals(CaseType.compagnie))
                {
                    CaseCompagnie pr = (CaseCompagnie)cases[j.getPosition2()];
                    if (pr.getTypeProprieté().Equals(typeProprieté.libre))
                    {
                        proprietéNappartenantAPersonne(j);
                    }
                    else
                    {
                        if (j != pr.getPropriétaire())
                            proprietéAppartenantAUnePersonne(j);
                    }
                }
                else if (cases[j.getPosition2()].getCaseType().Equals(CaseType.AllezPrison))
                {
                    cases[j.getPosition2()].isGone(pion);
                    pion.transform.localPosition = cases[10].getNewPionPosition(pion);
                    j.allezEnPrison();
                }
                else if (cases[j.getPosition2()].getCaseType().Equals(CaseType.Impot))
                {
                    j.débiter(200);
                }
                else if (cases[j.getPosition2()].getCaseType().Equals(CaseType.Taxe))
                {
                    j.débiter(100);
                }
                else if (cases[j.getPosition2()].getCaseType().Equals(CaseType.Chanse))
                {
                    CaseChance cc = (CaseChance)cases[j.getPosition2()];
                    cc.tirerCarte(j);
                }
                else if (cases[j.getPosition2()].getCaseType().Equals(CaseType.Cmmunaute))
                {
                    CaseCommunauté cc = (CaseCommunauté)cases[j.getPosition2()];
                    cc.tirerCarte(j,pions, cases[7]);
                }
            }

        } while (p == true && cmpt< 3) ;


        if (cmpt == 3)
        {
            cases[j.getPosition2()].isGone(pion);
            pion.transform.localPosition = cases[10].getNewPionPosition(pion);
            j.allezEnPrison();
        }
     
        Debug.Log(j);
        jouerSuivant();
    }

    public void OnGUI()
    {
        GUI.skin = labelskin;
        GUI.skin.label.fontSize = 25;
        GUI.skin.label.fontStyle = FontStyle.Bold;
        GUI.color = Color.black;
        GUI.Label(new Rect(35, 80, 1000, 1000), "Somme : " + pions[1].GetComponent<PionScript>().getSolde() + "€");
        GUI.Label(new Rect(865, 80, 1000, 1000), "Somme : " + pions[0].GetComponent<PionScript>().getSolde() + "€");

    }

    public void proprietéNappartenantAPersonne(PionScript PionScript)
    {

        Propriété pr = null;//= cases[PionScript.getPosition2()]; 
        try
        {
            if (cases[PionScript.getPosition2()].getCaseType().Equals(CaseType.Gare))
            {
                pr = (CaseGare)cases[PionScript.getPosition2()];
                extra(pr, PionScript);
            }
            else if (cases[PionScript.getPosition2()].getCaseType().Equals(CaseType.compagnie))
            {
                pr = (CaseCompagnie)cases[PionScript.getPosition2()];
                extra(pr, PionScript);
            }
            else if (cases[PionScript.getPosition2()].getCaseType().Equals(CaseType.Proprieté))
            {
                try
                {
                    pr = (Propriété)cases[PionScript.getPosition2()];
                    extra(pr, PionScript);
                }
                catch (InvalidCastException)
                {
                    Debug.Log("InvalidCastException 886");
                }

            }
        }
        catch (IndexOutOfRangeException)
        {
            Debug.Log("IndexOutOfRangeException 893");
        }
        //cette partie est dans le extra
    }

    private void extra(Propriété pr, PionScript PionScript)
    {
        int i;

        Debug.Log("voulez vous acheter la proprieté qui coute " + pr.getValeur() + " ? si oui taper 1");
        i = 1;

        if (i == 1)//oui il veut acheter
        {
            PionScript.acheterPropriété(pr);
            Debug.Log("PionScript.getPosition2() = " + PionScript.getPosition2() + " pr.getValeur()= " + pr.getValeur() + " pr.getType =" + pr.GetType());
            Debug.Log(PionScript);

        }

        else
        {
            enchére(pr);
        }
    }

    public void proprietéAppartenantAUnePersonne(PionScript PionScript)
    {
        Propriété pr = null;//= cases[PionScript.getPosition2()]; 

        if (cases[PionScript.getPosition2()].getCaseType().Equals(CaseType.Gare))
        {
            pr = (CaseGare)cases[PionScript.getPosition2()];
            extra2(PionScript, pr);
        }
        else if (cases[PionScript.getPosition2()].getCaseType().Equals(CaseType.compagnie))
        {
            pr = (CaseCompagnie)cases[PionScript.getPosition2()];
            extra2(PionScript, pr);
        }
        else if (cases[PionScript.getPosition2()].getCaseType().Equals(CaseType.Proprieté))
        {
            try
            {
                pr = (Propriété)cases[PionScript.getPosition2()];
                extra2(PionScript, pr);
            }
            catch (InvalidCastException)
            {
                Debug.Log("caste a échouer 236");
            }

        }


        //cette partie est dans le extra2
    }

    public void extra2(PionScript PionScript, Propriété pr)
    {
        bool p = true;
        int pos = -1;
        try
        {
            for (int i = 0; i < pions.Length && p == true; i++)
            {
                Debug.Log("xxx pr.getPropriétaire() = " + pr.getPropriétaire());
                Debug.Log("xxx pions[i] = " + pions[i]);
                if (pr.getPropriétaire() == pions[i].GetComponent<PionScript>())
                {
                    p = false;
                    pos = i;
                }
            }
            PionScript.débiter(pr.getPrixLoyer());
            Debug.Log("xxx position = "+pos);
            pions[pos].GetComponent<PionScript>().crediter(pr.getPrixLoyer());
            Debug.Log("PionScript qui paye le loyer : " + PionScript);
            Debug.Log(" joeur qui reçoit le loyer " + pions[pos]);
        }
        catch (NullReferenceException)
        {
            Debug.Log("NullReferenceException 966");
        }
    }

    private void enchére(Propriété pr)
    {
        long x = 0, max = 0;
        int pos = 0, taille = pions.Length, reponse = 0;

        Debug.Log("bien venue en chére");

        while (taille > 1)
        {
            for (int i = 0; i < pions.Length && taille > 1; i++)
            {
                Debug.Log("PionScript " + i + " voulez vous participez ? si oui taper 1 :");
                reponse = int.Parse(Console.ReadLine());

                if (reponse == 1)
                {
                    Debug.Log("donner votre prix");
                    x = long.Parse(Console.ReadLine());
                    if (x > max)
                    {
                        max = x;
                        pos = i;
                    }
                }
                else
                    taille--;
            }
        }
        pions[pos].GetComponent<PionScript>().acheterPropriété(pr, max);
        Debug.Log("PionScript.getPosition2() = " + pions[pos].GetComponent<PionScript>().getPosition2() + " pr.getValeur()= " + pr.getValeur() + " pr.getType =" + pr.GetType());
        Debug.Log(pions[pos]);
    }

    private void sortirDePrison(PionScript j)
    {
        int réponse = -1;

        if (j.getNombreCarteLibererPrisonChance()+j.getNombreCarteLibererPrisonCommunauté() > 0)
        {
            Debug.Log("voulez vous utilisez la carte sortire de prison ? si oui tapez 1");
            réponse = int.Parse(Console.ReadLine());
            if (réponse == 1)
            {
                if (j.getNombreCarteLibererPrisonChance() > 0)
                {
                    j.utiliserCarteLibererPrisonChance();
                    CaseChance c = (CaseChance)cases[7];
                    c.rendreCarteSortireDePrison();
                }
                else if (j.getNombreCarteLibererPrisonCommunauté() > 0)
                {
                    j.utiliserCarteLibererPrisonCommunauté();
                    CaseCommunauté c = (CaseCommunauté)cases[2];
                    c.rendreCarteSortireDePrison();
                }
            }
        }
        else
        {
            Debug.Log("si voulez faire pour sortir de prison ?");
            Debug.Log("1 : payer 50$ ");
            Debug.Log("2 : attendre 3 tours");
            réponse = 1;
            if (réponse == 1)
            {
                j.débiter(50);
                j.setEtat(etatJoueur.libre);
            }
            else
            {
                j.setNombreTourPourSortirDePrison();

                if (j.getNombreTourPourSortirDePrison() == 3)
                {
                    j.setEtat(etatJoueur.libre);
                    j.setNombreTourPourSortirDePrison(0);
                }
            }
        }
        Debug.Log(j);
    }

    public void essey()
    {

        pions[0].GetComponent<PionScript>().seDeplacer(1);
        proprietéNappartenantAPersonne(pions[0].GetComponent<PionScript>());

        pions[1].GetComponent<PionScript>().setPosition2(1);
        proprietéAppartenantAUnePersonne(pions[1].GetComponent<PionScript>());

    }
}

public class dé
{
    private int valeurDé1;
    private int valeurDé2;
    private System.Random aleatoire;
    public dé() { }
    public void lancerDé()
    {

        valeurDé1 = PlayerPrefs.GetInt("des1");
        valeurDé2 = PlayerPrefs.GetInt("des2");
    }

    public bool isDouble()
    {
        return valeurDé1 == valeurDé2;
    }
    public int getValeurDé()
    {
        return valeurDé1 + valeurDé2;
    }
}


public class Banque
{

    private long fond;
    private int nombreMaison;
    private int nombreHotel;

    public Banque()//il faut l'inétialiser dans le main
    {
        fond = long.MaxValue;
        nombreMaison = 32;
        nombreHotel = 12;
    }

    public long verse(long x)
    {
        if (fond >= x)
        {
            fond -= x;
            return x;
        }

        else
            Debug.Log("banque à chaisse");

        return 0;

    }

    public void reçoit(long x)
    {
        fond += x;
    }

    public void vendreMaison()
    {
        if (nombreMaison > 0)
            nombreMaison--;
        else
            Debug.Log("il ne ya plus de maison");
    }

    public void vendreHotel()
    {
        if (nombreHotel > 0)
            nombreHotel--;
        else
            Debug.Log("il ne ya plus d'hotel");
    }

}
