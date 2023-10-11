using System.Collections;
using System.Collections.Generic;
using Image = UnityEngine.UI.Image;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;

public abstract class Card : ScriptableObject
{
    public int id;
    public string cardName;
    public string nickName;
    public int rank;
    public string type1;
    public string type2;
    public string type3;
    public string type4;
    public string type5;
    public string type6;
    public string type7;
    public string type8;
    public string healthtext;
    public int health;
    public string atktext;
    public int atk;
    public string suptext;
    public int sup;
    public string mindtext;
    public int mind;
    public string deftext;
    public int def;
    public string mdeftext;
    public int mdef;
    public string agitext;
    public int agility;
    public string stance0Text;
    public string stance1Stattext1;
    public int stance1Stat1;
    public string stance1Stattext2;
    public int stance1Stat2;
    public string stance1Stattext3;
    public int stance1Stat3;
    public string stance1Stattext4;
    public int stance1Stat4;
    public string stance1Text;
    public string stance2Stattext1;
    public int stance2Stat1;
    public string stance2Stattext2;
    public int stance2Stat2;
    public string stance2Stattext3;
    public int stance2Stat3;
    public string stance2Stattext4;
    public int stance2Stat4;
    public string stance2Text;
    public Sprite cardPicture;
    public Sprite cardBack;
    public Material cardFrontMat;
    public Material cardBackMat;
    public GenUnit cardScript;
    public int SupMe;
    public int rageatk;
    public int startatk;

    
    public abstract string CardTooltipInfoText();




}





