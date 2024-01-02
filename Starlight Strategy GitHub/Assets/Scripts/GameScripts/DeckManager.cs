using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.UI;
using static UnityEditor.SearchableEditorWindow;

public class DeckManager : MonoBehaviour
{
    [Header("Bools")]
    public bool SearchDone;



    


    public GameCon1 controller;
    public int CardsinHand;
    public TurnManager TurnMan;
    public GameObject Deckholder;
    public GameObject Deckholder2;
    public GameObject Deckholder3;
    public GameObject Deckholder4;
    public GameObject Deckholder5;
    public GameObject Deckholder6;
    public int x;
    public int deckSize;
    public int y;
    public GameObject HandHolder;
   
    public GameObject HandCard2;
    public Coroutine GStartCour;
    public Transform DeckSearchCanv;

    public Button DeckCardBut;
    
    public Transform GridContent;

    [Header("Lists")]
    public List<GameObject> HandCard = new List<GameObject>();
    public List<GenUnit> HandCardScript = new List<GenUnit>();
    public List<GameObject> Deck = new List<GameObject>();
    public List<GameObject> container = new List<GameObject>();
    public List<Button> DeckSearchBut = new List<Button>();







    // Start is called before the first frame update
    void Start()
    {
        SearchDone = false;

        x = 0;
        deckSize = 50;
        for (int i = 0; i < 50; i++)
        {
            x = UnityEngine.Random.Range(0, 4);
            Deck[i] = controller.CardPrefabs[x];


        }

        




    }

    // Update is called once per frame
    void Update()
    {

        if (deckSize >= 50)
        {
            Deckholder6.SetActive(true);
            Deckholder5.SetActive(true);
            Deckholder4.SetActive(true);
            Deckholder3.SetActive(true);
            Deckholder2.SetActive(true);
            Deckholder.SetActive(true);

        }
        if (deckSize <= 45)
        {
            Deckholder6.SetActive(false);
            Deckholder5.SetActive(true);
            Deckholder4.SetActive(true);
            Deckholder3.SetActive(true);
            Deckholder2.SetActive(true);
            Deckholder.SetActive(true);

        }
        if (deckSize <= 35)
        {
            Deckholder5.SetActive(false);
            Deckholder4.SetActive(true);
            Deckholder3.SetActive(true);
            Deckholder2.SetActive(true);
            Deckholder.SetActive(true);

        }
        if (deckSize <= 25)
        {
            Deckholder4.SetActive(false);
            Deckholder3.SetActive(true);
            Deckholder2.SetActive(true);
            Deckholder.SetActive(true);

        }
        if (deckSize <= 15)
        {
            Deckholder3.SetActive(false);
            Deckholder2.SetActive(true);
            Deckholder.SetActive(true);

        }
        if (deckSize < 5)
        {
            Deckholder2.SetActive(false);
            Deckholder.SetActive(true);

        }
        if (deckSize == 0)
        {
            Deckholder.SetActive(false);

        }
        if (CardsinHand == 1)
        {
            HandHolder.transform.GetChild(0).GetComponent<GenUnit>().desiredPosition = new Vector3(1, 5, 1);

        }
        if (CardsinHand == 2)
        {
            HandHolder.transform.GetChild(0).GetComponent<GenUnit>().desiredPosition = new Vector3(1, 5, 1);
            HandHolder.transform.GetChild(1).GetComponent<GenUnit>().desiredPosition = new Vector3(1.5f, 5, 1);

        }
        if (CardsinHand == 3)
        {
            HandHolder.transform.GetChild(0).GetComponent<GenUnit>().desiredPosition = new Vector3(1, 5, 1);
            HandHolder.transform.GetChild(1).GetComponent<GenUnit>().desiredPosition = new Vector3(1.5f, 5, 1);
            HandHolder.transform.GetChild(2).GetComponent<GenUnit>().desiredPosition = new Vector3(2f, 5, 1);

        }
        if (CardsinHand == 4)
        {
            HandHolder.transform.GetChild(0).GetComponent<GenUnit>().desiredPosition = new Vector3(1, 5, 1);
            HandHolder.transform.GetChild(1).GetComponent<GenUnit>().desiredPosition = new Vector3(1.5f, 5, 1);
            HandHolder.transform.GetChild(2).GetComponent<GenUnit>().desiredPosition = new Vector3(2f, 5, 1);
            HandHolder.transform.GetChild(3).GetComponent<GenUnit>().desiredPosition = new Vector3(2.5f, 5, 1);
            

        }
        if (CardsinHand == 5)
        {
            HandHolder.transform.GetChild(0).GetComponent<GenUnit>().desiredPosition = new Vector3(1, 5, 1);
            HandHolder.transform.GetChild(1).GetComponent<GenUnit>().desiredPosition = new Vector3(1.5f, 5, 1);
            HandHolder.transform.GetChild(2).GetComponent<GenUnit>().desiredPosition = new Vector3(2f, 5, 1);
            HandHolder.transform.GetChild(3).GetComponent<GenUnit>().desiredPosition = new Vector3(2.5f, 5, 1);
            HandHolder.transform.GetChild(4).GetComponent<GenUnit>().desiredPosition = new Vector3(3f, 5, 1);


        }

        if (CardsinHand == 6)
        {
            HandHolder.transform.GetChild(0).GetComponent<GenUnit>().desiredPosition = new Vector3(1, 5, 1);
            HandHolder.transform.GetChild(1).GetComponent<GenUnit>().desiredPosition = new Vector3(1.5f, 5, 1);
            HandHolder.transform.GetChild(2).GetComponent<GenUnit>().desiredPosition = new Vector3(2f, 5, 1);
            HandHolder.transform.GetChild(3).GetComponent<GenUnit>().desiredPosition = new Vector3(2.5f, 5, 1);
            HandHolder.transform.GetChild(4).GetComponent<GenUnit>().desiredPosition = new Vector3(3f, 5, 1);
            HandHolder.transform.GetChild(5).GetComponent<GenUnit>().desiredPosition = new Vector3(3.5f, 5, 1);
         
        }
        if (CardsinHand == 7)
        {
            HandHolder.transform.GetChild(0).GetComponent<GenUnit>().desiredPosition = new Vector3(1, 5, 1);
            HandHolder.transform.GetChild(1).GetComponent<GenUnit>().desiredPosition = new Vector3(1.5f, 5, 1);
            HandHolder.transform.GetChild(2).GetComponent<GenUnit>().desiredPosition = new Vector3(2f, 5, 1);
            HandHolder.transform.GetChild(3).GetComponent<GenUnit>().desiredPosition = new Vector3(2.5f, 5, 1);
            HandHolder.transform.GetChild(4).GetComponent<GenUnit>().desiredPosition = new Vector3(3f, 5, 1);
            HandHolder.transform.GetChild(5).GetComponent<GenUnit>().desiredPosition = new Vector3(3.5f, 5, 1);
            HandHolder.transform.GetChild(6).GetComponent<GenUnit>().desiredPosition = new Vector3(4f, 5, 1);

        }
        if (CardsinHand == 8)
        {
            HandHolder.transform.GetChild(0).GetComponent<GenUnit>().desiredPosition = new Vector3(1, 5, 1);
            HandHolder.transform.GetChild(1).GetComponent<GenUnit>().desiredPosition = new Vector3(1.5f, 5, 1);
            HandHolder.transform.GetChild(2).GetComponent<GenUnit>().desiredPosition = new Vector3(2f, 5, 1);
            HandHolder.transform.GetChild(3).GetComponent<GenUnit>().desiredPosition = new Vector3(2.5f, 5, 1);
            HandHolder.transform.GetChild(4).GetComponent<GenUnit>().desiredPosition = new Vector3(3f, 5, 1);
            HandHolder.transform.GetChild(5).GetComponent<GenUnit>().desiredPosition = new Vector3(3.5f, 5, 1);
            HandHolder.transform.GetChild(6).GetComponent<GenUnit>().desiredPosition = new Vector3(4f, 5, 1);
            HandHolder.transform.GetChild(7).GetComponent<GenUnit>().desiredPosition = new Vector3(4.5f, 5, 1);

        }
        if (CardsinHand == 9)
        {
            HandHolder.transform.GetChild(0).GetComponent<GenUnit>().desiredPosition = new Vector3(1, 5, 1);
            HandHolder.transform.GetChild(1).GetComponent<GenUnit>().desiredPosition = new Vector3(1.5f, 5, 1);
            HandHolder.transform.GetChild(2).GetComponent<GenUnit>().desiredPosition = new Vector3(2f, 5, 1);
            HandHolder.transform.GetChild(3).GetComponent<GenUnit>().desiredPosition = new Vector3(2.5f, 5, 1);
            HandHolder.transform.GetChild(4).GetComponent<GenUnit>().desiredPosition = new Vector3(3f, 5, 1);
            HandHolder.transform.GetChild(5).GetComponent<GenUnit>().desiredPosition = new Vector3(3.5f, 5, 1);
            HandHolder.transform.GetChild(6).GetComponent<GenUnit>().desiredPosition = new Vector3(4f, 5, 1);
            HandHolder.transform.GetChild(7).GetComponent<GenUnit>().desiredPosition = new Vector3(4.5f, 5, 1);            
            HandHolder.transform.GetChild(8).GetComponent<GenUnit>().desiredPosition = new Vector3(5f, 5, 1);
            

        }
        if (CardsinHand == 10)
        {
            HandHolder.transform.GetChild(0).GetComponent<GenUnit>().desiredPosition = new Vector3(1, 5, 1);
            HandHolder.transform.GetChild(1).GetComponent<GenUnit>().desiredPosition = new Vector3(1.5f, 5, 1);
            HandHolder.transform.GetChild(2).GetComponent<GenUnit>().desiredPosition = new Vector3(2f, 5, 1);
            HandHolder.transform.GetChild(3).GetComponent<GenUnit>().desiredPosition = new Vector3(2.5f, 5, 1);
            HandHolder.transform.GetChild(4).GetComponent<GenUnit>().desiredPosition = new Vector3(3f, 5, 1);
            HandHolder.transform.GetChild(5).GetComponent<GenUnit>().desiredPosition = new Vector3(3.5f, 5, 1);
            HandHolder.transform.GetChild(6).GetComponent<GenUnit>().desiredPosition = new Vector3(4f, 5, 1);
            HandHolder.transform.GetChild(7).GetComponent<GenUnit>().desiredPosition = new Vector3(4.5f, 5, 1);
            HandHolder.transform.GetChild(8).GetComponent<GenUnit>().desiredPosition = new Vector3(5f, 5, 1);
            HandHolder.transform.GetChild(9).GetComponent<GenUnit>().desiredPosition = new Vector3(5.5f, 5, 1);

        }
        if (CardsinHand == 11)
        {
            HandHolder.transform.GetChild(0).GetComponent<GenUnit>().desiredPosition = new Vector3(1, 5, 1);
            HandHolder.transform.GetChild(1).GetComponent<GenUnit>().desiredPosition = new Vector3(1.5f, 5, 1);
            HandHolder.transform.GetChild(2).GetComponent<GenUnit>().desiredPosition = new Vector3(2f, 5, 1);
            HandHolder.transform.GetChild(3).GetComponent<GenUnit>().desiredPosition = new Vector3(2.5f, 5, 1);
            HandHolder.transform.GetChild(4).GetComponent<GenUnit>().desiredPosition = new Vector3(3f, 5, 1);
            HandHolder.transform.GetChild(5).GetComponent<GenUnit>().desiredPosition = new Vector3(3.5f, 5, 1);
            HandHolder.transform.GetChild(6).GetComponent<GenUnit>().desiredPosition = new Vector3(4f, 5, 1);
            HandHolder.transform.GetChild(7).GetComponent<GenUnit>().desiredPosition = new Vector3(4.5f, 5, 1);
            HandHolder.transform.GetChild(8).GetComponent<GenUnit>().desiredPosition = new Vector3(5f, 5, 1);
            HandHolder.transform.GetChild(9).GetComponent<GenUnit>().desiredPosition = new Vector3(5.5f, 5, 1);
            HandHolder.transform.GetChild(10).GetComponent<GenUnit>().desiredPosition = new Vector3(6f, 5, 1);

        }


        if (CardsinHand == 12)
        {
            HandHolder.transform.GetChild(0).GetComponent<GenUnit>().desiredPosition = new Vector3(1, 5, 1);
            HandHolder.transform.GetChild(1).GetComponent<GenUnit>().desiredPosition = new Vector3(1.5f, 5, 1);
            HandHolder.transform.GetChild(2).GetComponent<GenUnit>().desiredPosition = new Vector3(2f, 5, 1);
            HandHolder.transform.GetChild(3).GetComponent<GenUnit>().desiredPosition = new Vector3(2.5f, 5, 1);
            HandHolder.transform.GetChild(4).GetComponent<GenUnit>().desiredPosition = new Vector3(3f, 5, 1);
            HandHolder.transform.GetChild(5).GetComponent<GenUnit>().desiredPosition = new Vector3(3.5f, 5, 1);
            HandHolder.transform.GetChild(6).GetComponent<GenUnit>().desiredPosition = new Vector3(4f, 5, 1);
            HandHolder.transform.GetChild(7).GetComponent<GenUnit>().desiredPosition = new Vector3(4.5f, 5, 1);
            HandHolder.transform.GetChild(8).GetComponent<GenUnit>().desiredPosition = new Vector3(5f, 5, 1);
            HandHolder.transform.GetChild(9).GetComponent<GenUnit>().desiredPosition = new Vector3(5.5f, 5, 1);
            HandHolder.transform.GetChild(10).GetComponent<GenUnit>().desiredPosition = new Vector3(6f, 5, 1);
            HandHolder.transform.GetChild(11).GetComponent<GenUnit>().desiredPosition = new Vector3(6.5f, 5, 1);

        }

    }
    public void Shuffle()
    {
        for (int i = 0; i < 50; i++)
        {
            container[0] = Deck[i];
            int randomIndex = UnityEngine.Random.Range(i, deckSize);
            Deck[i] = Deck[randomIndex];
            Deck[randomIndex] = container[0];
            
        }
    }

    public void DeckSearchDisplay()
    {
        DeckSearchCanv.gameObject.SetActive(true);
        foreach (GameObject card in Deck)
        {
            DeckCardBut = Instantiate(DeckCardBut, GridContent.transform);
            DeckCardBut.name = card.name;
            DeckCardBut.image.sprite = card.GetComponent<GenUnit>().UnitData.cardPicture;
            int c = DeckCardBut.transform.GetSiblingIndex();
            DeckCardBut.onClick.AddListener(() => SearchACard(c)) ;

        }

       
    }

//    public void DeckSearchDisplay2nd()
//    {
//        DeckSearchCanv.gameObject.SetActive(true);
//        for (int i = 0; i < deckSize; i++)
//        {
//            DeckSearchBut[i].name = Deck[i].name;
//            DeckSearchBut[i].image.sprite = Deck[i].GetComponent<GenUnit>().UnitData.cardPicture;
//            DeckSearchBut[i] = Instantiate(DeckSearchBut[i], GridContent.transform);
//            DeckSearchBut[i].onClick.AddListener(delegate { SearchACard(i); }) ;

//        }


//    }

    public IEnumerator StartingHandDraw()
    {
        for (int i = 0; i < 9; i++)
        {
            if (i >= 8)
            {
//                GStartCour = StartCoroutine(StartingHandDraw());
                TurnMan.isDrawPhase = true;               
                StopCoroutine(StartingHandDraw());               
                Debug.Log("GameStart Couroutine has finished.");

            }
            else
            {
                DrawACard();
                yield return new WaitForSeconds(0.2f);

            }
                          

        }       

        
    }

    public void SearchACard(int z)
    {
        if (CardsinHand == 12)
        {
            SearchDone = true;
            DeckSearchCanv.gameObject.SetActive(false);
            DeckCardBut.onClick.RemoveAllListeners();
            return;
            

        }
        else
        {
            Debug.Log($"z is equal to {z}");
            HandCard2 = Instantiate(Deck[z] , new Vector3(6.9f, 0.5f, 1), Quaternion.identity, HandHolder.transform) as GameObject;
            deckSize -= 1;
            CardsinHand += 1;
            Deck.RemoveRange(z, 1);
            Invoke("MoveCardtoHand", 0.001f);
            SearchDone = true;
            DeckSearchCanv.gameObject.SetActive(false);
            DeckCardBut.onClick.RemoveAllListeners();
            

        }
    }




    public void DrawACard()
    {
        if (CardsinHand == 12)
        {
            return;

        }
        else
        {
            HandCard2 = Instantiate(Deck[0], new Vector3(6.9f, 0.5f, 1), Quaternion.identity, HandHolder.transform) as GameObject;
            deckSize -= 1;
            CardsinHand += 1;
            Deck.RemoveRange(0, 1);
            Invoke("MoveCardtoHand", 0.001f);



        }

    }
    public void MoveCardtoHand()
    {
        
        HandCard2.GetComponent<GenUnit>().MoveToHand();
        

    }
    
}
