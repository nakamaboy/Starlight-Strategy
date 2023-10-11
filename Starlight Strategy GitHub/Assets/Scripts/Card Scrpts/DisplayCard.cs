using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.ProBuilder;

public class DisplayCard : MonoBehaviour
{
    //    public List<GenUnit> displayCard = new List<GenUnit>();
    public List<GenUnit> displayCard = new List<GenUnit>();
    public int displayID;

    public int id;
    public string cardName;
    public string nickName;
    public int rank;    
    public MeshRenderer rend;
    public Canvas AttackOptions;
    public Canvas MainOptions;
    public Canvas MoveOptions;
    public Canvas ExtraOptions1;
    public Canvas ExtraOptions2;
    public GameObject prorend;
    


    // Start is called before the first frame update
    void Start()

    {
        
        displayCard[0] = gameObject.AddComponent<RubyRoseRes>();


        //        displayCard[0] = Carddatabase.cardList[displayID];




    }

    // Update is called once per frame
    void Update()
    {



    }
}
