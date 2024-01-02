using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static UnityEditor.ObjectChangeEventStream;

public class TurnManager : MonoBehaviour
{
    public DeckManager DeckMan;
    public Button EndPhaseBut;
    public bool gameStart;
    public bool P1turn;
    public bool P1firstTurn;
    public bool isDrawPhase;
    public bool isStandbyPhase;
    public bool isMainPhase;
    public bool isEndPhase;
    public bool DrawRouteActive;
    public bool StandbyRouteActive;
    public bool MainPhaRouteActive;
    public int MaxMP;
    public int newMP;
    public int ChainLinkAct;
    public PlayerDetstring PlayerData;
    public UnityEvent<PlayerDetails> MPChangeEvent;
    [SerializeField] private TextMeshProUGUI PlayInfoTMP;
    private PlayerDetails playersdet;
    
    public TextMeshProUGUI PhaseText;
    public Canvas PhaseCanvas;
    public Vector3 PhTextDesiredPos;
    public int PhTextMoveSpeed; 

        

    // Start is called before the first frame update
    void Start()
    {
        MPChangeEvent = new UnityEvent<PlayerDetails>();
        MaxMP = 2000;
        PlayerData.player1Mana = MaxMP;
        PlayerData.player2Mana = MaxMP;
        MPChangeEvent.AddListener(DisplayPlayerInfos);
        DisplayPlayerInfos(playersdet);
        gameStart = true;
        isDrawPhase = false;
        DeckMan.StartingHandDraw();
        EndPhaseBut = transform.GetChild(0).GetChild(0).GetComponent<Button>();
        EndPhaseBut.onClick.AddListener(EndphaseActivate);
        PhaseCanvas = transform.GetChild(0).GetComponent<Canvas>();
        PhaseText = transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();
//        PhTextDesiredPos = new Vector3(0, 0, 0);
        PhaseText.gameObject.SetActive(false);
        PhTextMoveSpeed = 300;
        DrawRouteActive = false;
        StandbyRouteActive = false;
        


    }

    // Update is called once per frame
    void Update()
    {
        PhaseText.transform.position = Vector3.MoveTowards(PhaseText.transform.position, PhTextDesiredPos, Time.deltaTime * PhTextMoveSpeed);

        if (gameStart == true)
        {
            StartCoroutine(DeckMan.StartingHandDraw());
            P1turn = true;
            gameStart = false;

        }
        if (isDrawPhase)
        {
            if (DrawRouteActive == false)
            {
                StartCoroutine(DrawPhaseEnum());
                DrawRouteActive = true;

            }
            if (DeckMan.SearchDone == true)
            {
                isStandbyPhase = true;             
                DrawRouteActive = false;
                Debug.Log("DrawPhase Enum has finished running now.");
                StopCoroutine(DrawPhaseEnum());
                isDrawPhase = false;

            }
            



        }

        if (isStandbyPhase)
        {
            if (StandbyRouteActive == false)
            {
                StartCoroutine(StandbyPhaseEnum());
                StandbyRouteActive = true;

            }
                       

        }
        if (isMainPhase)
        {
            if (MainPhaRouteActive == false)
            {
                StartCoroutine(MainPhaseEnum());
                MainPhaRouteActive = true;

            }
            

        }

        if (isEndPhase)
        {
            if (P1turn)
            {
                PlayerData.p1Rankcount += 1;
                PlayerData.player1TurnNum += 1;
                P1turn = false;
                isDrawPhase = true;
                isEndPhase = false;

            }
            else
            {
                PlayerData.p2Rankcount += 1;
                PlayerData.player2TurnNum += 1;
                P1turn = true;
                isDrawPhase = true;
                isEndPhase = false;

            }
            

        }
        
    }
    public void EndphaseActivate()
    {
        isEndPhase = true;

    }

    public void DisplayPlayerInfos(PlayerDetails playersdet)
    {
        playersdet = PlayerData;
        StringBuilder bd = new StringBuilder();
        bd.Append(playersdet.PlayersInfoText());
        PlayInfoTMP.text = bd.ToString();

    }
    public void DepleteMP(int amount, int teams)
    {

        Debug.Log($"Deplete amount is = {amount}");       

        if (teams == 0)
        {
            newMP = PlayerData.player1Mana - amount;
            PlayerData.player1Mana = newMP;
            Debug.Log($"Player1 mana is now = {PlayerData.player1Mana}");           
            MPChangeEvent.Invoke(PlayerData);

        }
        if (teams == 1)
        {
            newMP = PlayerData.player2Mana - amount;
            PlayerData.player2Mana = newMP;
            MPChangeEvent.Invoke(PlayerData);
        }

    }

    public IEnumerator DrawPhaseEnum()
    {
        PhaseCanvas.gameObject.SetActive(true);
        PhaseText.gameObject.SetActive(true);
        PhaseText.fontSize = 70;
        PhaseText.text = "Draw Phase";     
        PhaseText.transform.position = new Vector3(400, 400, 0);
        PhTextDesiredPos = new Vector3(700, 400, 0);
        yield return new WaitForSeconds(0.5f);
        DeckMan.DrawACard();
        PhaseCanvas.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        DeckMan.DeckSearchDisplay();
        

       

    }
    public IEnumerator StandbyPhaseEnum()
    {
        PhaseCanvas.gameObject.SetActive(true);
        PhaseText.gameObject.SetActive(true);
        PhaseText.fontSize = 70;
        PhaseText.text = "Standby Phase";
        PhaseText.transform.position = new Vector3(400, 400, 0);
        PhTextDesiredPos = new Vector3(700, 400, 0);
        yield return new WaitForSeconds(0.5f);
        PhaseCanvas.gameObject.SetActive(false);
        isMainPhase = true;
        isStandbyPhase = false;
        StandbyRouteActive = false;        
        Debug.Log("StandbyPhase Enum has finished running now.");
        StopCoroutine(StandbyPhaseEnum());

    }
    public IEnumerator MainPhaseEnum()
    {
        PhaseCanvas.gameObject.SetActive(true);
        PhaseText.gameObject.SetActive(true);
        PhaseText.fontSize = 70;
        PhaseText.text = "Main Phase";
        PhaseText.transform.position = new Vector3(400, 400, 0);
        PhTextDesiredPos = new Vector3(700, 400, 0);
        yield return new WaitForSeconds(0.5f);
        PhaseCanvas.gameObject.SetActive(false);
        Debug.Log("MainPhase Enum has finished running now.");
        StopCoroutine(MainPhaseEnum());

    }


}


