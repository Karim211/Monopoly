using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CaseType
{
    Depart,
    Taxe,
    Prison,
    AllezPrison,
    ParcGratuit,
    Chanse,
    CaisseCmmunaute,
    Terrain,
    Compagnie,
    Gare

}

public class Case {
    public Vector3 positionGeometrique { get; set; }
    public int positionNumerique { get; set; }
    public CaseType type { get; set; }
    public int somme { get; set; }
    public GameObject[] pions { get; set; }
    private float decalage = 0.2f; //le decalage entre les pion

    public Case(Vector3 p ,int n ,CaseType type ,int nombrePionMax)
    {
        positionNumerique = n;
        positionGeometrique = p;
        this.type = type;
        pions = new GameObject[nombrePionMax];
    }

    public Vector3 getNewPionPosition(GameObject pion)
    {
        int i = 0;
        while (pions[i] != null)
        {
            i++;
        }
        pions[i] = pion;
        int p = (int)(positionNumerique / 10 % 4);
         if (p == 0)
            return positionGeometrique + new Vector3(0, -decalage * i, 0);
         if (p == 1)
            return positionGeometrique + new Vector3(-decalage * i, 0, 0);
         if (p == 2)
            return positionGeometrique + new Vector3(0, decalage * i, 0);
         return positionGeometrique + new Vector3(decalage * i, 0, 0);
    }

    //pour le passage du pion
    public Vector3 getNewPionPositionPassage()
    {
        int i = 0;
        while (pions[i] != null)
        {
            i++;
        }
        int p = (int)(positionNumerique / 10 % 4);
        if (p == 0)
            return positionGeometrique + new Vector3(0, -decalage * i, 0);
        if (p == 1)
            return positionGeometrique + new Vector3(-decalage * i, 0, 0);
        if (p == 2)
            return positionGeometrique + new Vector3(0, decalage * i, 0);
        return positionGeometrique + new Vector3(decalage * i, 0, 0);
    }

    public int getNombrePion()
    {
        int nb = 0;
        foreach(GameObject pion in pions)
        {
            nb = (pion != null) ? nb++ : nb;
        }return nb;
    }

    public void isGone(GameObject objectPion)
    {
        int i = 0;
        while(!objectPion.Equals(pions[i]))
        {
            i++; 
        }pions[i] = null;
        
    }

}
