using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(fileName = "New Carddata", menuName = "Unit Card")]
public class CardTextBuilder : Card
{
    public CardTextBuilder(int id, string cardName, string nickName, int rank, string type1, string type2, string type3, string type4, string type5, string type6, string type7, string type8, string healthtext, int health, string atktext, int atk, string suptext, int sup, string mindtext, int mind, string deftext, int def, string mdeftext, int mdef, string agitext, int agility, string stance0Text, string stance1Stattext1, int stance1Stat1, string stance1Stattext2, int stance1Stat2, string stance1Stattext3, int stance1Stat3, string stance1Stattext4, int stance1Stat4, string stance1Text, string stance2Stattext1, int stance2Stat1, string stance2Stattext2, int stance2Stat2, string stance2Stattext3, int stance2Stat3, string stance2Stattext4, int stance2Stat4, string stance2Text, Sprite cardPicture, Sprite cardBack, Material cardFrontMat, Material cardBackMat, GenUnit cardScript, int supMe, int rageatk, int startatk)
    {
        this.id = id;
        this.cardName = cardName;
        this.nickName = nickName;
        this.rank = rank;
        this.type1 = type1;
        this.type2 = type2;
        this.type3 = type3;
        this.type4 = type4;
        this.type5 = type5;
        this.type6 = type6;
        this.type7 = type7;
        this.type8 = type8;
        this.healthtext = healthtext;
        this.health = health;
        this.atktext = atktext;
        this.atk = atk;
        this.suptext = suptext;
        this.sup = sup;
        this.mindtext = mindtext;
        this.mind = mind;
        this.deftext = deftext;
        this.def = def;
        this.mdeftext = mdeftext;
        this.mdef = mdef;
        this.agitext = agitext;
        this.agility = agility;
        this.stance0Text = stance0Text;
        this.stance1Stattext1 = stance1Stattext1;
        this.stance1Stat1 = stance1Stat1;
        this.stance1Stattext2 = stance1Stattext2;
        this.stance1Stat2 = stance1Stat2;
        this.stance1Stattext3 = stance1Stattext3;
        this.stance1Stat3 = stance1Stat3;
        this.stance1Stattext4 = stance1Stattext4;
        this.stance1Stat4 = stance1Stat4;
        this.stance1Text = stance1Text;
        this.stance2Stattext1 = stance2Stattext1;
        this.stance2Stat1 = stance2Stat1;
        this.stance2Stattext2 = stance2Stattext2;
        this.stance2Stat2 = stance2Stat2;
        this.stance2Stattext3 = stance2Stattext3;
        this.stance2Stat3 = stance2Stat3;
        this.stance2Stattext4 = stance2Stattext4;
        this.stance2Stat4 = stance2Stat4;
        this.stance2Text = stance2Text;
        this.cardPicture = cardPicture;
        this.cardBack = cardBack;
        this.cardFrontMat = cardFrontMat;
        this.cardBackMat = cardBackMat;
        this.cardScript = cardScript;
        SupMe = supMe;
        this.rageatk = rageatk;
        this.startatk = startatk;
    }

    private void Awake()
    {
        
    }


    public override string CardTooltipInfoText()
    {
        StringBuilder builder = new StringBuilder();

        builder.Append(cardName).Append("(").Append(nickName).Append(")").AppendLine();
        builder.Append("Rank ").Append(rank).AppendLine();
        builder.Append((type1 == string.Empty) ? string.Empty : type1).Append((type2 == string.Empty) ? string.Empty : ", " + type2).Append((type3 == string.Empty) ? string.Empty : ", " + type3).Append((type4 == string.Empty) ? string.Empty : ", " + type4).Append((type5 == string.Empty) ? string.Empty : ", " + type5).Append((type6 == string.Empty) ? string.Empty : ", " + type6).Append((type7 == string.Empty) ? string.Empty : ", " + type7).Append((type8 == string.Empty) ? string.Empty : ", " + type8).AppendLine();
        builder.Append(healthtext + " ").Append((healthtext == string.Empty) ? string.Empty : health + " | ").Append((atktext == string.Empty) ? string.Empty : atktext + " ").Append(atk + " | ").Append((suptext == string.Empty) ? null : suptext + " ").Append(sup + " | ").Append((mindtext == string.Empty) ? string.Empty : mindtext + " ").Append(mind + " | ").AppendLine();
        builder.Append(deftext).Append((deftext == string.Empty) ? string.Empty : def + " | ").Append(mdeftext).Append((mdeftext == string.Empty) ? string.Empty : mdef + " | ").Append(agitext).Append((agitext == string.Empty) ? string.Empty : agility + " | ").AppendLine();        
        builder.Append("SupportingMe: ").Append(SupMe + " ").Append(stance0Text).AppendLine();       
        builder.Append("Stance 1 - ").Append(stance1Stattext1 + " ").Append((stance1Stattext1 == string.Empty) ? string.Empty : stance1Stat1 + " | ").Append(stance1Stattext2 + " ").Append((stance1Stattext2 == string.Empty) ? string.Empty : stance1Stat2 + " | ").Append(stance1Stattext3 + " ").Append((stance1Stattext3 == string.Empty) ? string.Empty : stance1Stat3 + " | ").Append(stance1Stattext4 + " ").Append((stance1Stattext4 == string.Empty) ? string.Empty : stance1Stat4).AppendLine();
        builder.Append(stance1Text).AppendLine();
        builder.Append("  ").AppendLine();
        builder.Append("Stance 2 - ").Append(stance2Stattext1 + " ").Append((stance2Stattext1 == string.Empty) ? string.Empty : stance2Stat1 + " | ").Append(stance2Stattext2 + " ").Append((stance2Stattext2 == string.Empty) ? string.Empty : stance2Stat2 + " | ").Append(stance2Stattext3 + " ").Append((stance2Stattext3 == string.Empty) ? string.Empty : stance2Stat3 + " |  ").Append(stance2Stattext4 + " ").Append((stance2Stattext4 == string.Empty) ? string.Empty : stance2Stat4).AppendLine();
        builder.Append(stance2Text).AppendLine();
        return builder.ToString();
    }
}
