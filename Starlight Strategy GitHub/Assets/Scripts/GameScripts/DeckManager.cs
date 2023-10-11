using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.UI;

public class DeckManager : MonoBehaviour
{
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
    public GameObject HandHolder;
    public List<GameObject> HandCard = new List<GameObject>();
    public List<GenUnit> HandCardScript = new List<GenUnit>();
    public GameObject HandCard2;
    public Coroutine GStartCour;
    public Transform DeckSearchPanel;

    public Button DeckCardBut;
    public Transform GridContent;

    public List<GameObject> Deck = new List<GameObject>();
    public List<GameObject> container = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {



        x = 0;
        deckSize = 50;
        for (int i = 0; i < 50; i++)
        {
            x = UnityEngine.Random.Range(0, 4);
            Deck[i] = controller.CardPrefabs[x];


        }


       

        //        StartCoroutine(StartingHandGet());



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
        foreach (GameObject card in Deck)
        {
            DeckCardBut = Instantiate(DeckCardBut, GridContent.transform); 

            DeckCardBut.image.sprite = card.GetComponent<GenUnit>().UnitData.cardPicture;
              

        }
    }

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
    IEnumerator StartingHandGet()
    {
        HandCard = new List<GameObject>();
        HandCardScript = new List<GenUnit>();
        for (int i = 0; i < 8; i++)
        {           
            HandCard.Add(Instantiate(Deck[i], new Vector3(6.9f, 0.5f, 1), Quaternion.identity, HandHolder.transform));
            deckSize -= 1;
            HandCardScript.Add(HandCard[i].GetComponent<GenUnit>());
            HandCardScript[i].desiredPosition = new Vector3(1, 5, 1);
            Debug.Log($"Handcard{i}'s Desired position is {HandCardScript[i].desiredPosition}");
            yield return new WaitForSeconds(1);

        }
    }
}
