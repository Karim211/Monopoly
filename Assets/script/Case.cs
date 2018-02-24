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
    Cmmunaute,
    Proprieté,
    Impot,
    Gare,
    compagnie

}
public enum etatJoueur
{
    libre,
    prisonnier,
    faillite
}
public enum typeProprieté
{
    occupé,
    hypothéqué,
    libre
}

public enum couleur
{
    mauve,
    rouge,
    rose,
    orange,
    jeune,
    bleu,
    vert,
    BleuTurquoise
}

public class Case {
    public Vector3 positionGeometrique { get; set; }
    public int positionNumerique { get; set; }
    public CaseType type { get; set; }
    public GameObject[] pions { get; set; }
    private float decalage = 0.2f; //le decalage entre les pion

    public Case(int n ,CaseType type)
    {
        positionNumerique = n;
        positionGeometrique = plateau.dictionary[n];
        this.type = type;
        pions = new GameObject[4];
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
    public void setPosition(int pos)
    {
        positionNumerique = pos;
    }
    public int getPosition()
    {
        return positionNumerique;
    }

    public CaseType getCaseType()
    {
        return type;
    }

}

public class Propriété : Case //héritage
{
    private typeProprieté typeP;
    private long valeur;
    private PionScript propriétaire;
    private long prixLoyer;
    private long valeurHypothéque;


    public Propriété(int p, CaseType type, typeProprieté t, long v, PionScript j, long pr, long h) : base(p, type)
    {
        typeP = t;
        valeur = v;
        propriétaire = j;
        prixLoyer = pr;
        valeurHypothéque = h;

    }

    override
    public string ToString()
    {
        return "type : " + typeP + " valeur : " + valeur + " prixLoyer : " + prixLoyer + " valeurHypothéque: " + valeurHypothéque;
    }

    public virtual long getPrixLoyer()
    {
        return prixLoyer;
    }

    public void setPropriétaire(PionScript p)
    {
        propriétaire = p;
    }

    public PionScript getPropriétaire()
    {
        return propriétaire;
    }

    public long faitPayerLoyer()
    {
        return prixLoyer;
    }

    public long getValeur()
    {
        return valeur;
    }

    public void setType(typeProprieté p)
    {
        typeP = p;
    }

    public typeProprieté getTypeProprieté()
    {
        return typeP;
    }

    public long getValeurHypothéque()
    {
        return valeurHypothéque;
    }
}

public class CaseTerrain : Propriété
{

    private int nombreMaisons;
    private couleur couleur;
    private long prixMaison;
    private long prixHotel;
    private bool hotel;
    private int casPos;
    private string nom;

    public CaseTerrain(int positionCarte, CaseType type, string nom, typeProprieté t, long prixProprieté, PionScript j, long prixLoyer, couleur cl, long hypothéque, long prixMaison, long prixHotel) : base(positionCarte, type, t, prixProprieté, j, prixLoyer, hypothéque)
    {
        nombreMaisons = 0;
        couleur = cl;
        this.prixMaison = prixMaison;
        this.prixHotel = prixHotel;
        this.casPos = positionCarte;
        this.nom = nom;
    }

    public string getNom()
    {
        return nom;
    }

    public int getCasPos()
    {
        return casPos;
    }

    public bool isHotelHere()
    {
        return hotel;
    }

    public int getNombreDeMaison()
    {
        return nombreMaisons;
    }

    public couleur getCouleur()
    {
        return couleur;
    }

    public override long getPrixLoyer()
    {
        if (nombreMaisons == 1)
        {
            return base.getPrixLoyer() * 2;
        }
        else if (nombreMaisons == 2)
        {
            return base.getPrixLoyer() * 3;
        }
        else if (nombreMaisons == 3)
        {
            return base.getPrixLoyer() * 4;
        }
        else if (nombreMaisons == 4)
        {
            return base.getPrixLoyer() * 5;
        }
        else if (hotel)
        {
            return base.getPrixLoyer() * 6;
        }

        return base.getPrixLoyer();


    }

    public void construirMaison()
    {
        if (nombreMaisons < 4)
            nombreMaisons++;
        else
            Debug.Log("vous ne pouvez plus construire car le nombre de maison est = 4 !!");
    }

    public long getPrixMaison()
    {
        return prixMaison;
    }

    public long getPrixHotel()
    {
        return prixHotel;
    }

    public void construirHotel()
    {
        hotel = true;
        nombreMaisons = 0;
    }
}

public class CaseDépart : Case //héritage
{


    public CaseDépart(int p, CaseType type) : base(p, type)
    {
    }

    public long verserSalaire()
    {
        return 1500; //1500 represent le salaire
    }
}

public class CaseCommunauté : Case //héritage
{
    private string[] carteCaisseComunauté = new string[16];
    private int curseur;
    private bool vérif;

    public CaseCommunauté(int p, CaseType type) : base(p, type)
    {
        curseur = 0;

        vérif = false;

        carteCaisseComunauté[0] = "payez la note du médecin 50 euro";
        carteCaisseComunauté[1] = "c'est votre anniversaire: chaque PionScript doit vous donner 10 euro";
        carteCaisseComunauté[2] = "payez une amende de 10 euro ou bien tirez une carte 'CHANCE'";
        carteCaisseComunauté[3] = "erreur de la banque en votre faveur recevez 200 euro";
        carteCaisseComunauté[4] = "recevez votre intérét sur l'emprunt à 7% 25 euro";
        carteCaisseComunauté[5] = "la vente de votre stock vous rapport 50 euro";
        carteCaisseComunauté[6] = "vous héritez de 100 euro";
        carteCaisseComunauté[7] = "retournez à Belleville";
        carteCaisseComunauté[8] = "allez en prison. avancez tout droit en prison. ne passez pas par la case 'départ' ne recevez pas 200 euro";
        carteCaisseComunauté[9] = "vous avez gagné le deuxiéme prix beauté. recevez 10 euro";
        carteCaisseComunauté[10] = "placez-vous sur la case départ";
        carteCaisseComunauté[11] = "vous étes libéré de prison. cette carte peut étre conservée jusqu'à ce qu'elle soit utilisée ou vendue.";
        carteCaisseComunauté[12] = "payez à l'hopital 100 euro";
        carteCaisseComunauté[13] = "les contributions vous remboursent la somme de 20 euro";
        carteCaisseComunauté[14] = "recevez votre revenu annuel 100 euro";
        carteCaisseComunauté[15] = "payez votre police d'assurance s'élevant à 50 euro";
    }

    public void rendreCarteSortireDePrison()
    {
        vérif = false;
    }

    public void tirerCarte(PionScript j, GameObject[] tabJoueur, Case Case)
    {
        Debug.Log(carteCaisseComunauté[curseur]);

        if (vérif && curseur == 11)
            curseur++;

        if (curseur == 0)
        {
            j.débiter(500);
        }
        else if (curseur == 1)
        {
            for (int i = 0; i < tabJoueur.Length; i++)
            {
                if (j != tabJoueur[i].GetComponent<PionScript>())
                {
                    j.crediter(10);
                    tabJoueur[i].GetComponent<PionScript>().débiter(10);
                }
            }
        }
        else if (curseur == 2)
        {
            CaseChance cas = (CaseChance)Case;
            int répons;

            Debug.Log("que voulez vous faire ? tapez le numéro");
            Debug.Log("1- payez 100 euro");
            Debug.Log("2- tirer carte chance");
            répons = 1;//int.Parse(Console.ReadLine());

            if (répons == 1)
                j.débiter(10);
            else
                cas.tirerCarte(j);
        }
        else if (curseur == 3)
        {
            j.crediter(200);
        }
        else if (curseur == 4)
        {
            j.crediter(25);
        }
        else if (curseur == 5)
        {
            j.crediter(50);
        }
        else if (curseur == 6)
        {
            j.crediter(100);
        }
        else if (curseur == 7)
        {
            j.retourner(1);
        }
        else if (curseur == 8)
        {
            j.allezEnPrison();
        }
        else if (curseur == 9)
        {
            j.crediter(10);
        }
        else if (curseur == 10)
        {
            j.setPosition2(0);
        }
        else if (curseur == 11)
        {
            j.setNombreCarteLibererPrisonCommunauté(1);
            vérif = true;
        }
        else if (curseur == 12)
        {
            j.débiter(100);
        }
        else if (curseur == 13)
        {
            j.crediter(20);
        }
        else if (curseur == 14)
        {
            j.crediter(100);
        }
        else if (curseur == 15)
        {
            j.débiter(50);
        }

        curseur = (curseur + 1) % 16;
    }
}

public class CaseChance : Case //héritage
{
    private string[] carteChance = new string[16];
    private int curseur;
    private bool vérif;

    public CaseChance(int p, CaseType type) : base(p, type)
    {
        curseur = 0;

        vérif = false;

        carteChance[0] = "la banque vous verse un dividendede 50 euro";
        carteChance[1] = "rendez-vous à la rue de la paix";
        carteChance[2] = "reculez de trois cases";
        carteChance[3] = "vous étes libérer de prison. cette carte peut étre conservée jusqu'à ce qu'elle soit utilisée ou vendue.";
        carteChance[4] = "faites des réparations dans toutes vos maisons. versez pour chaque maison 250 euro. versez pour chaque hotel 100 euro";
        carteChance[5] = "vous avez gagné le prix de mot croisés. recevez 100 euro.";
        carteChance[6] = "amande pour excés de vitesse: 15 euro";
        carteChance[7] = "votre immeuble et votre prét rapportent. vous devez toucher 150 euro";
        carteChance[8] = "payez pour frais de scolarité: 150 euro";
        carteChance[9] = "rendez-vous à l'avenue Henri-Martin. si vous passez par la case 'Départ' recevez 200 euro";
        carteChance[10] = "allez en prison. rendez-vous directement à la prison. ne franchissez pas la case 'Départ' ne touchez pas 2000 euro";
        carteChance[11] = "vous étes imposé pour les réparations de voirie à raison de : 40 euro par maison et 115 euro par hotel.";
        carteChance[12] = "amenede pour ivresse: 20 euro";
        carteChance[13] = "allez à la gare de lyon. si vous passez par la case 'Départ' recevez 200 euro";
        carteChance[14] = "avancez jusqu'à la case 'Départ'";
        carteChance[15] = "avancez au boulevard de la villette. si vous passezpar la case 'Départ' recevez 200 euro";
    }

    public void rendreCarteSortireDePrison()
    {
        vérif = false;
    }

    public void tirerCarte(PionScript j)
    {
        Debug.Log(carteChance[curseur]);

        if (vérif && curseur == 3)
            curseur++;

        if (curseur == 0)
        {
            j.crediter(50);
        }
        else if (curseur == 1)
        {
            j.setPosition2(39);
        }
        else if (curseur == 2)
        {
            j.seDeplacer(-3);
        }
        else if (curseur == 3)
        {
            j.setNombreCarteLibererPrisonChance(1);
            vérif = true;
        }
        else if (curseur == 4)
        {
            j.débiter(j.getNomberMosain() * 25 + j.getNomberHotel() * 100);
        }
        else if (curseur == 5)
        {
            j.crediter(100);
        }
        else if (curseur == 6)
        {
            j.débiter(15);
        }
        else if (curseur == 7)
        {
            j.crediter(150);
        }
        else if (curseur == 8)
        {
            j.débiter(150);
        }
        else if (curseur == 9)
        {
            j.setPosition2(24);
        }
        else if (curseur == 10)
        {
            j.allezEnPrison();
        }
        else if (curseur == 11)
        {
            j.débiter(j.getNomberMosain() * 40 + j.getNomberHotel() * 115);
        }
        else if (curseur == 12)
        {
            j.débiter(20);
        }
        else if (curseur == 13)
        {
            j.setPosition2(15);
        }
        else if (curseur == 14)
        {
            j.setPosition2(0);
        }
        else if (curseur == 15)
        {
            j.setPosition2(11);
        }

        curseur = (curseur + 1) % 16;
    }
}
public class casePrison : Case //héritage 
{
    public casePrison(int p, CaseType type) : base(p, type)
    {
        /*apres implemontation de la classe joeur on chengera l'état du joeur il deviendra prisonnier */
    }
}

public class caseAllezEnPrison : Case //héritage
{
    public caseAllezEnPrison(int p, CaseType type) : base(p, type)
    {

    }

    public void envoiEnPrison()
    {
        setPosition(10); //comment connaitre la position de la case prison
    }
}

public class CaseTaxeLux : Case //héritage
{

    public CaseTaxeLux(int p, CaseType type) : base(p, type)
    {    }
}

public class CaseImpot : Case //héritage
{

    public CaseImpot(int p, CaseType type) : base(p, type)
    {    }
}

public class CaseParcGratuit : Case //héritage
{
    //private long somme { get; set; }

    public CaseParcGratuit(int p, CaseType type/*, long somme*/) : base(p, type)
    {
        //this.somme = somme;
    }

    /*public void verset(long som)
    {
        somme -= som;  //j'ai pas bien compris le role de cette fonction 
    }

    public void rçoit(long som)
    {
        somme += som;  //j'ai pas compris le role de cette fonction aussi
    }*/
}
public class CaseGare : Propriété
{


    public CaseGare(int p, CaseType type, typeProprieté t, long v, PionScript j, long pr, long h) : base(p, type, t, v, j, pr, h)
    {

    }


    public override long getPrixLoyer()
    {
        if (base.getPropriétaire().getNombreGare() == 1)
            return base.getPrixLoyer();
        else if (base.getPropriétaire().getNombreGare() == 2)
            return 50;
        else if (base.getPropriétaire().getNombreGare() == 3)
            return 100;
        else
            return 200;
    }
}

public class CaseCompagnie : Propriété
{
    public CaseCompagnie(int p, CaseType type, typeProprieté t, long v, PionScript j, long pr, long h) : base(p, type, t, v, j, pr, h)
    {

    }

    public override long getPrixLoyer()
    {
        if (base.getPropriétaire().getNombreCompagnie() == 1)
            return base.getPrixLoyer() * (PlayerPrefs.GetInt("des1") + PlayerPrefs.GetInt("des2"));
        else
            return 10 * (PlayerPrefs.GetInt("des1") + PlayerPrefs.GetInt("des2"));

    }
}

