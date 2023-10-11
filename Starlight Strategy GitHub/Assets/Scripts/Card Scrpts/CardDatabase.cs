using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Playables;
using UnityEngine;
using static UnityEngine.InputManagerEntry;

public class Carddatabase : MonoBehaviour 

{
    public static List<CardTextBuilder> cardList = new List<CardTextBuilder>();
    private void Awake()
    {
//        cardList.Add(new CardTextBuilder(0, "Name", "Nickname", 0, "type", "type2", "type3", "type4", "type5", "type6", "type7", "type8", "healthtext", 0, "atktext", 0, "suptext", 0, "mindtext", 0, "deftext", 0, "mdeftext", 0, "agitext", 0, "stance0Text", "stance1Stattext1", 0, "stance1Stattext2", 0, "stance1Stattext3", 0, "string stance1Stattext4", 0, "stance1Text", "stance2Stattext1", 0, "stance2Stattext2", 0, "stance2Stattext3", 0, "stance2Stattext4", 0, "stance2Text", Resources.Load<Sprite>("CardBack"), Resources.Load<Sprite>("CardBack"), Resources.Load<Material>("Materials/"), Resources.Load<Material>("Materials/"), Resources.Load<GenUnit>("CardScript/RubyRose - Copy"), 0, 0, 0));
//        cardList.Add(new CardTextBuilder(1, "Ruby Rose", "Red like Roses", 1, "Human", "Hunter", "Beacon Academy", "RWBY", "Remnant", "Light", " ", " ", "HP", 10, "Atk", 3, "Sup", 0, "Mind", 1, "Def", 0, "MDef", 0, "Agi", 4, " ", "Sup", 0, "Mind", 1, " ", 0, " ", 0, "[Petal Burst]/100 MP/(Bturn): Warp user to 4 or 6.", "Sup", 3, "Mind", 0, " ", 0, " ", 0, "[Whiterose] /100 MP/: Extra deploy “Weiss Schnee” from your Deck at 4 or 6.",  Resources.Load<Sprite>("Rubycard 1"), Resources.Load<Sprite>("CardBack"), Resources.Load<Material>("Materials/RubyRose"), Resources.Load<Material>("Materials/BackMat"), Resources.Load<GenUnit>("CardScript/RubyRose - Copy"), 0, 0, 3));

    }


}
