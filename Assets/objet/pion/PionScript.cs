using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PionScript : MonoBehaviour {
	public Animator anim;
    public float speed = 5;
    private long solde;
    private int position;
    private List<Propriété> Propriété = new List<Propriété>();
    private int nombreDouble;
    private int nombreCarteLibererPrisonChance;
    private int nombreCarteLibererPrisonCommunauté;
    private etatJoueur etat;
    private int nombreTourPourSortirDePrison;
    private int nombreGare;
    private int nombreCompagnie;

    public void newJoueur()
    {
        solde = 1500;
        position = 0;
        nombreDouble = 0;
        nombreCarteLibererPrisonChance = 0;
        nombreCarteLibererPrisonCommunauté = 0;
        etat = etatJoueur.libre;
        nombreTourPourSortirDePrison = 0;
        Propriété = new List<Propriété>();
        nombreGare = 0;
        nombreCompagnie = 0;
    }

    public List<Propriété> GetListPropriété()
    {
        return Propriété;
    }

    public void addPropriété(Propriété p)
    {
        Propriété.Add(p);
    }

    public int getNombreGare()
    {
        return nombreGare;
    }

    public long getSolde()
    {
        return solde;
    }

    public int getNombreCompagnie()
    {
        return nombreCompagnie;
    }

    public void setNombreTourPourSortirDePrison(int p)
    {
        nombreTourPourSortirDePrison = p;
    }

    public int getNombreCarteLibererPrisonCommunauté()
    {
        return nombreCarteLibererPrisonCommunauté;
    }

    public int getNombreCarteLibererPrisonChance()
    {
        return nombreCarteLibererPrisonChance;
    }

    public void utiliserCarteLibererPrisonChance()
    {
        if (nombreCarteLibererPrisonChance > 0)
        {
            nombreCarteLibererPrisonChance--;
            etat = etatJoueur.libre;
        }
    }

    public void utiliserCarteLibererPrisonCommunauté()
    {
        if (nombreCarteLibererPrisonCommunauté > 0)
        {
            nombreCarteLibererPrisonCommunauté--;
            etat = etatJoueur.libre;
        }
    }

    public int getNombreTourPourSortirDePrison()
    {
        return nombreTourPourSortirDePrison;
    }

    public void setNombreTourPourSortirDePrison()
    {
        if (nombreTourPourSortirDePrison < 3)
            nombreTourPourSortirDePrison++;
        else
            nombreTourPourSortirDePrison = 1;
    }

    public void setEtat(etatJoueur p)
    {
        etat = p;
    }

    public etatJoueur getEtat()
    {
        return etat;
    }

    override
    public string ToString()
    {
        int x = nombreCarteLibererPrisonCommunauté + nombreCarteLibererPrisonChance;
        return  " etat: " + etat + " sold= " + solde + " position= " + position + " nombreCarteLibererPrison= " + x + " nombreTourPourSortirDePrison= " + nombreTourPourSortirDePrison;
    }

    

    public void seDeplacer(int pos)
    {
        
        position = pos;                    
    }

    public void setPosition2(int p)
    {
        if (position > p)
        {
            crediter(200);
            position = p;
        }
        else
            position = p;
    }

    public int getPosition2()
    {
        return position;         //utilisation dans le main
    }

    public void débiter(long x)
    {
        if (x < solde)
            solde -= x;
        else
            Debug.Log("pas d'argent faillite !!"); //traitement de se genr de cas à venir
    }

    public void crediter(long x)
    {
        solde += x;
    }

    public void acheterPropriété(Propriété p)
    {
        débiter(p.getValeur());
        p.setType(typeProprieté.occupé);
        Propriété.Add(p);
        p.setPropriétaire(gameObject.GetComponent<PionScript>());
        if (p.getCaseType().Equals(CaseType.Gare))
            nombreGare++;
        if (p.getCaseType().Equals(CaseType.compagnie))
            nombreCompagnie++;
    }

    public void acheterPropriété(Propriété p, long prix)//proprieté acheté aux enchére
    {
        débiter(prix);
        p.setType(typeProprieté.occupé);
        Propriété.Add(p);
        p.setPropriétaire(gameObject.GetComponent<PionScript>());
    }

    public void échanger(Propriété p, Propriété p2)//pas encore utilisé
    {
        Propriété.RemoveAt(Propriété.IndexOf(p));
        Propriété.Add(p2);
    }

    public void construireMaison(CaseTerrain t)
    {
        débiter(t.getPrixMaison());
        t.construirMaison();

    }

    public void construireHotel(CaseTerrain t)
    {
        débiter(t.getPrixHotel());
        t.construirHotel();
    }

    public void hypothéqué(CaseTerrain t)
    {
        t.setType(typeProprieté.hypothéqué);
        crediter(t.getValeurHypothéque());
    }

    public void afficherProprieté()
    {
        foreach (Propriété aPart in Propriété)
        {
            Debug.Log(aPart);
        }

    }

    public void allezEnPrison()
    {
        position = 10;
        etat = etatJoueur.prisonnier;
    }

    public void startAnimation()
	{
		anim.SetTrigger ("activate");
	}
    public void setNombreCarteLibererPrisonChance(int i)
    {
        nombreCarteLibererPrisonChance += i;
    }

    public void setNombreCarteLibererPrisonCommunauté(int i)
    {
        nombreCarteLibererPrisonCommunauté += i;
    }

    public int getNomberMosain()
    {
        int nb = 0;

        foreach (Propriété aPart in Propriété)
        {
            if (aPart.getCaseType().Equals(CaseType.Proprieté))
            {
                CaseTerrain aPar = (CaseTerrain)aPart;
                nb += aPar.getNombreDeMaison();
                if (aPar.isHotelHere())
                    nb += 4;
            }
        }

        return nb;
    }

    public int getNomberHotel()
    {
        int nb = 0;

        foreach (Propriété aPart in Propriété)
        {
            if (aPart.getCaseType().Equals(CaseType.Proprieté))
            {
                CaseTerrain aPar = (CaseTerrain)aPart;

                if (aPar.isHotelHere())
                    nb++;
            }
        }

        return nb;
    }

    public void retourner(int p)
    {
        position = p;
    }

}
