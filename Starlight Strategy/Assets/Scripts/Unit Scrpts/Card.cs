using System.Collections;
using System.Collections.Generic;
using Image = UnityEngine.UI.Image;
using UnityEngine;
using UnityEngine.UI;

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

    public string CardName { get { return cardName; } }
    public string NickName { get { return nickName; } }
    public int Rank { get { return rank; } }

    public string Type1 { get { return type1; } }
    public string Type2 { get { return type2; } }
    public string Type3 { get { return type3; } }
    public string Type4 { get { return type4; } }
    public string Type5 { get { return type5; } }
    public string Type6 { get { return type6; } }
    public string Type7 { get { return type7; } }
    public string Type8 { get { return type8; } }

    public string HealthText { get { return healthtext; } }

    public int Health { get { return health; } }

    public string AtkText { get { return atktext; } }

    public int Atk { get { return atk; } }

    public string SupText { get { return suptext; } }

    public int Sup { get { return sup; } }

    public string MindText { get { return mindtext; } }

    public int Mind { get { return mind; } }

    public string DefText { get { return deftext; } }

    public int Def { get { return def; } }

    public string MdefText { get { return mdeftext; } }

    public int Mdef { get { return mdef; } }

    public string AgiText { get { return agitext; } }

    public int Agility { get { return agility; } }

    public string Stance0Text { get { return stance0Text; } }

    public string Stance1Stattext1 { get { return stance1Stattext1; } }

    public int Stance1Stat1 { get { return stance1Stat1; } }

    public string Stance1Stattext2 { get { return stance1Stattext2; } }

    public int Stance1Stat2 { get { return stance1Stat2; } }

    public string Stance1Stattext3 { get { return stance1Stattext3; } }

    public int Stance1Stat3 { get { return stance1Stat3; } }

    public string Stance1Stattext4 { get { return stance1Stattext4; } }

    public int Stance1Stat4 { get { return stance1Stat4; } }

    public string Stance1Text { get { return stance1Text; } }

    public string Stance2Stattext1 { get { return stance2Stattext1; } }

    public int Stance2Stat1 { get { return stance2Stat1; } }

    public string Stance2Stattext2 { get { return stance2Stattext2; } }

    public int Stance2Stat2 { get { return stance2Stat2; } }

    public string Stance2Stattext3 { get { return stance2Stattext3; } }

    public int Stance2Stat3 { get { return stance2Stat3; } }

    public string Stance2Stattext4 { get { return stance2Stattext4; } }

    public int Stance2Stat4 { get { return stance2Stat4; } }

    public string Stance2Text { get { return stance2Text; } }

    public Sprite CardPicture { get { return cardPicture; } }


    public abstract string CardTooltipInfoText();

}





