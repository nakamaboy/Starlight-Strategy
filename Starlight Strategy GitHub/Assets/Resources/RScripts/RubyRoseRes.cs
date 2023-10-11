using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.UI;

public class RubyRoseRes : GenUnit
{
    [Header("Things I need to assign")]
    

    

    [Header("Children related")]
    public Canvas PetalMenu;
    public Button PetalButton;
    public Button WhiteRoseButton;
    private Canvas WhiteRoseOptions;
    public Button BurstRight;
    public Button BurstLeft;
    public Button WRoseLeftSta1But;
    public Button WRoseRightSta1But;
    public Button WRoseLeftSta2But;
    public Button WRoseRightSta2But;
    public TextMeshProUGUI PetalText;
    public TextMeshProUGUI WhiteRoseText;
    public TextMeshProUGUI BurstRightText;
    public TextMeshProUGUI BurstLeftText;
    public TextMeshProUGUI WRoseLeftSta1Text;
    public TextMeshProUGUI WRoseRightSta1Text;
    public TextMeshProUGUI WRoseLeftSta2Text;
    public TextMeshProUGUI WRoseRightSta2Text;




    [Header("Gets assigned by script")]
    
    public bool Whiterosecontinue;
    public bool whiteroseleft;
    public bool whiteroseright;
    public bool Wdeploystance1;
    public GameObject DeployedWeiss;
    public MeshRenderer Rend;
    public Material Rubymat;
    public Material Backmat;
    public GameObject ProBui;
    public GenUnit WeissData;

    private void Awake()
    {
        MainDeckPos1 = new Vector3(7, 0, 1);
        DiscardPoolPos1 = new Vector3(7, 0, 2);
        VoidPoolPos1 = new Vector3(7, 0, 3);
        SpecialDeckPos1 = new Vector3(0, 0, 1);
        MainDeckPos2 = new Vector3(0, 0, 6);
        DiscardPoolPos2 = new Vector3(0, 0, 5);
        VoidPoolPos2 = new Vector3(0, 0, 4);
        SpecialDeckPos2 = new Vector3(7, 0, 6);
        movespeed = 5;
        direction = (teams == 0) ? 1 : -1;
        Isfrozen = false;
        rotationSpeed = 200;
        IsinStance1 = true;

        TurnMan = Resources.Load<TurnManager>("Card prefabs/TurnManager 1");
        controller = Resources.Load<GameCon1>("Card prefabs/BoardController");
        DeckMan = Resources.Load<DeckManager>("Card prefabs/DeckManager");
        TipUI = Resources.Load<CardTooltipUI>("Card prefabs/CardTooltipUI");
        SpecialOptions = transform.GetChild(0);
        UnitData = Resources.Load<CardTextBuilder>("ScriptObjs/RubyRose2");
        Rubymat = Resources.Load<Material>("Materials/RubyRose");
        Backmat = Resources.Load<Material>("Materials/BackMat");
        desiredPosition = gameObject.transform.position;
        UnitData.cardPicture = Resources.Load<Sprite>("Rubycard 1");
        GetComponent<MeshRenderer>().sharedMaterials = new Material[3]
      {
            BuiltinMaterials.defaultMaterial,
            Rubymat, Backmat
      };
        transform.name = "Ruby Rose";
        PetalButton = Instantiate(Resources.Load<Button>("Card prefabs/ButtonPrefab"), SpecialOptions.transform);
        WhiteRoseButton = Instantiate(Resources.Load<Button>("Card prefabs/ButtonPrefab"), SpecialOptions.transform);
        PetalMenu = Instantiate(Resources.Load<Canvas>("Card prefabs/CanvasPrefab"), gameObject.transform);
        WhiteRoseOptions = Instantiate(Resources.Load<Canvas>("Card prefabs/CanvasPrefab"), gameObject.transform);
        BurstLeft = Instantiate(Resources.Load<Button>("Card prefabs/ButtonPrefab"), PetalMenu.transform);
        BurstRight = Instantiate(Resources.Load<Button>("Card prefabs/ButtonPrefab"), PetalMenu.transform);
        WRoseLeftSta1But = Instantiate(Resources.Load<Button>("Card prefabs/ButtonPrefab"), WhiteRoseOptions.transform);
        WRoseLeftSta2But = Instantiate(Resources.Load<Button>("Card prefabs/ButtonPrefab"), WhiteRoseOptions.transform);
        WRoseRightSta1But = Instantiate(Resources.Load<Button>("Card prefabs/ButtonPrefab"), WhiteRoseOptions.transform);
        WRoseRightSta1But = Instantiate(Resources.Load<Button>("Card prefabs/ButtonPrefab"), WhiteRoseOptions.transform);

    }
    void Start()
    {
          
        UnitData.type1 = "Human";
        UnitData.type2 = "Hunter";
        UnitData.type3 = "Beacon Academy";
        UnitData.type4 = "RWBY";
        UnitData.type5 = "Remnant";
        UnitData.type6 = "Light";
        UnitData.healthtext = "HP";
        UnitData.atktext = "Atk";
        UnitData.suptext = "Sup";
        UnitData.mindtext = "Mind";
        UnitData.deftext = "Def";
        UnitData.mdeftext = "MDef";
        UnitData.agitext = "Agi";
        UnitData.stance1Text = "[Petal Burst]/100 MP/(Bturn): Warp user to 4 or 6.";
        UnitData.stance2Text = "[Whiterose] /100 MP/: Extra deploy “Weiss Schnee” from your Deck at 4 or 6.";
        UnitData.stance1Stattext1 = "Sup";
        UnitData.stance1Stattext2 = "Mind";
        UnitData.stance2Stattext1 = "Sup";
        UnitData.stance2Stattext2 = "Mind";
        IsinStance1 = true;
        UnitData.health = 10;
        UnitData.atk = 3;
        UnitData.sup = 0;
        UnitData.mind = 1;
        UnitData.def = 0;
        UnitData.mdef = 0;
        UnitData.agility = 4;
        UnitData.stance1Stat1 = 0;
        UnitData.stance1Stat2 = 1;
        UnitData.stance2Stat1 = 3;
        UnitData.stance2Stat2 = 0;
        IsMindBattling = false;
        movespeed = 5;
        Whiterosecontinue = false;
        teams = 0;
        direction = (teams == 0) ? 1 : -1;
        WhiteRoseButton.GetComponent<FollowWorld>().lookAt = gameObject;
        WhiteRoseButton.GetComponent<FollowWorld>().offset = (teams == 0) ? new Vector3(0.12f, 0, -0.5f) : new Vector3(-0.12f, 0, 0.5f);
        PetalButton.GetComponent<FollowWorld>().lookAt = gameObject;
        PetalButton.GetComponent<FollowWorld>().offset = (teams == 0) ? new Vector3(0.12f, 0, -0.5f) : new Vector3(-0.12f, 0, 0.5f);
        BurstLeft.GetComponent<FollowWorld>().lookAt = gameObject;
        BurstLeft.GetComponent<FollowWorld>().offset = (teams == 0) ? new Vector3(-1.2f, 0, 0.1f) : new Vector3(1.2f, 0, 0.1f);
        BurstRight.GetComponent<FollowWorld>().lookAt = gameObject;
        BurstRight.GetComponent<FollowWorld>().offset = (teams == 0) ? new Vector3(1.2f, 0, 0.1f) : new Vector3(-1.2f, 0, 0.1f);

        PetalButton.name = "Petal button";
        WhiteRoseButton.name = "WhiteRose button";
        PetalText = PetalButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        PetalText.text = "Petal Burst";
        WhiteRoseText = WhiteRoseButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        WhiteRoseText.text = "White Rose";
        BurstLeftText = BurstLeft.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        BurstLeftText.text = "Burst Left";
        BurstRightText = BurstLeft.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        BurstRightText.text = "Burst Right";

        




    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * movespeed);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);
        //transform.localScale = Vector3.MoveTowards(transform.localScale, desiredScale, Time.deltaTime * 5);

        if (transform.position.y == 0)
        {
            IsOnField = true;
        }



        if (IsinStance1 == true)
        {
            if (controller.SelectedUnit == gameObject.transform)
            {

                Stance1ButtonsActiv();

                Invoke("Stance1ButtonsActiv", 0.2f);


            }
            

            Stance1rotation();

        }
        if (IsinStance1 == false)
        {
            if (controller.SelectedUnit == gameObject.transform)
            {
                Stance2ButtonsActiv();

                //Invoke("Stance2ButtonsActiv", 0.2f);

            }
            Stance2rotation();

        }
        if (Whiterosecontinue == true)
        {
            if (whiteroseleft == true)
            {

                WhiteRosepart2(gameObject.transform.position + new Vector3(-direction, 0, 0));

            }
            if (whiteroseright == true)
            {
                WhiteRosepart2(gameObject.transform.position + new Vector3(+direction, 0, 0));

            }


        }


    }
    public void PetalBurstLeft()
    {

        if (gameObject.transform.position.x != 0 && IsinStance1 == true)
        {
            if ((teams == 0) ? TurnMan.PlayerData.player1Mana >= 100 : TurnMan.PlayerData.player2Mana >= 100)
            {
                if (controller.SpottedUnitLeft == null)
                {
                    TurnMan.DepleteMP(100, teams);
                    int direction = (teams == 0) ? 1 : -1;
                    desiredPosition = gameObject.transform.position + new Vector3(-direction, 0, 0);
                    Debug.Log($"New desired position is: {desiredPosition}");

                }
                else
                {
                    return;
                }


            }
            else
            {
                return;
            }


        }
        else
        {
            return;
        }
    }
    public void PetalBurstRight()
    {

        if (gameObject.transform.position.x != 7 && IsinStance1 == true)
        {
            if ((teams == 0) ? TurnMan.PlayerData.player1Mana >= 100 : TurnMan.PlayerData.player2Mana >= 100)
            {
                if (controller.SpottedUnitRight == null)
                {
                    TurnMan.DepleteMP(100, 0);
                    int direction = (teams == 0) ? 1 : -1;
                    desiredPosition = gameObject.transform.position + new Vector3(+direction, 0, 0);
                    Debug.Log($"New desired position is: {desiredPosition}");

                }
                else
                {
                    return;
                }


            }
            else
            {
                return;
            }

        }

        else
        {
            return;
        }
    }

    public void WhiteRose()
    {
        if (controller.SwitchUnitLeft && controller.SwitchUnitRight && IsinStance1 == false && (teams == 0) ? TurnMan.PlayerData.player1Mana >= 100 : TurnMan.PlayerData.player2Mana >= 100)
        {

            WhiteRoseOptions.gameObject.SetActive(true);
            Whiterosecontinue = true;
            Debug.Log("WhitRoseOptions is" + WhiteRoseOptions);

        }

        else
        {
            return;
        }

    }
    private void WhiteRosepart2(Vector3 position)
    {


        WRoseLeftSta1But.onClick.RemoveAllListeners();
        WRoseLeftSta2But.onClick.RemoveAllListeners();
        WRoseRightSta1But.onClick.RemoveAllListeners();
        WRoseRightSta2But.onClick.RemoveAllListeners();
        TurnMan.DepleteMP(100, teams);
        DeployedWeiss = Instantiate(controller.CardPrefabs[(1)], position, Quaternion.identity);
        WeissData = DeployedWeiss.GetComponent<GenUnit>();
        Whiterosecontinue = false;
        Invoke("WeissChange", 0.2f);
        return;

    }
    public void Stance2ButtonsActiv()
    {
        Debug.Log("Stance2 Buttons are being activated");
        WhiteRoseButton = gameObject.transform.GetChild(0).GetChild(1).GetComponent<Button>();

        PetalButton.gameObject.SetActive(false);

        WhiteRoseButton.gameObject.SetActive(true); 
        WhiteRoseButton.GetComponent<FollowWorld>().lookAt = gameObject;
        WhiteRoseButton.GetComponent<FollowWorld>().offset = (teams == 0) ? new Vector3(0.12f, 0, -0.5f) : new Vector3(-0.12f, 0, 0.5f);
        WhiteRoseButton.onClick.AddListener(WhiteRoseActivate);
        UnitData.sup = UnitData.stance2Stat1;
        UnitData.mind = UnitData.stance2Stat2;
        

    }
    public void Stance1ButtonsActiv()
    {
        Debug.Log("Stance1 Buttons are being activated");
        PetalButton = gameObject.transform.GetChild(0).GetChild(0).GetComponent<Button>();

        PetalButton.GetComponent<FollowWorld>().lookAt = gameObject;
        PetalButton.GetComponent<FollowWorld>().offset = (teams == 0) ? new Vector3(0.12f, 0, -0.5f) : new Vector3(-0.12f, 0, 0.5f);
        PetalButton.onClick.AddListener(PetalActivate);
        UnitData.sup = UnitData.stance1Stat1;
        UnitData.mind = UnitData.stance1Stat2;
        PetalButton.gameObject.SetActive(true);
        WhiteRoseButton.gameObject.SetActive(false);
        
    }
    private void PetalActivate()
    {
        SpecialOptions.gameObject.SetActive(false);
        PetalButton.onClick.RemoveAllListeners();
        controller.MainOptions.gameObject.SetActive(false);
        PetalMenu = gameObject.transform.GetChild(1).GetComponent<Canvas>();
        PetalMenu.gameObject.SetActive(true);
        BurstLeft = PetalMenu.transform.GetChild(0).GetComponent<Button>();
        BurstRight = PetalMenu.transform.GetChild(1).GetComponent<Button>();
        BurstLeft.onClick.AddListener(PetalBurstLeft);
        BurstRight.onClick.AddListener(PetalBurstRight);


    }
    private void WhiteRoseActivate()
    {
        controller.MainOptions.gameObject.SetActive(false);
        SpecialOptions.gameObject.SetActive(false);
        WhiteRoseButton.onClick.RemoveAllListeners();
        WhiteRoseOptions.gameObject.SetActive(true);
        WRoseLeftSta1But.onClick.AddListener(WhiteRoseleftdepstance1);
        WRoseLeftSta2But.onClick.AddListener(WhiteRoseleftdepstance2);
        WRoseRightSta1But.onClick.AddListener(WhiteRoserightdepstance1);
        WRoseRightSta2But.onClick.AddListener(WhiteRoserightdepstance2);


    }
    public void WhiteRoseleftdepstance1()
    {
        if (controller.SwitchUnitLeft == null && (teams == 0) ? TurnMan.PlayerData.player1Mana >= 100 : TurnMan.PlayerData.player2Mana >= 100)
        {
            WhiteRoseOptions.gameObject.SetActive(false);
            Whiterosecontinue = true;
            whiteroseleft = true;
            Wdeploystance1 = true;

        }
        else
        {
            return;
        }

    }
    public void WhiteRoseleftdepstance2()
    {
        if (controller.SwitchUnitLeft == null && (teams == 0) ? TurnMan.PlayerData.player1Mana >= 100 : TurnMan.PlayerData.player2Mana >= 100)
        {
            WhiteRoseOptions.gameObject.SetActive(false);
            Whiterosecontinue = true;
            whiteroseleft = true;
            Wdeploystance1 = false;

        }
        else
        {
            return;
        }


    }
    public void WhiteRoserightdepstance1()
    {
        if (controller.SwitchUnitRight == null && (teams == 0) ? TurnMan.PlayerData.player1Mana >= 100 : TurnMan.PlayerData.player2Mana >= 100)
        {
            WhiteRoseOptions.gameObject.SetActive(false);
            Whiterosecontinue = true;
            whiteroseright = true;
            Wdeploystance1 = true;

        }
        else
        {
            return;
        }


    }
    public void WhiteRoserightdepstance2()
    {
        if (controller.SwitchUnitRight == null && (teams == 0) ? TurnMan.PlayerData.player1Mana >= 100 : TurnMan.PlayerData.player2Mana >= 100)
        {
            WhiteRoseOptions.gameObject.SetActive(false);
            Whiterosecontinue = true;
            whiteroseright = true;
            Wdeploystance1 = false;

        }
        else
        {
            return;
        }

    }
    public void WeissChange()
    {
        WeissData.teams = teams;
        Debug.Log("Extra Deployed Unit is" + DeployedWeiss);
        if (Wdeploystance1 == false)
        {
            Debug.Log("Wdeploy is false");

            WeissData.IsinStance1 = false;
        }
        else
        {
            WeissData.IsinStance1 = true;

        }


    }

    public void SetupStartPT2()
    {
        

        Invoke("SetupStartPT3", 0.2f);
    }

    public void SetupStartPT3()
    {
        


    }



}


