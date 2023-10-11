using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor.ProBuilder;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.ProBuilder;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.XR;
using static UnityEngine.EventSystems.EventTrigger;

public class RubyRose : GenUnit
{
    [Header("Things I need to assign")]
    public Transform PetalMenu; 
    public Button PetalButton;
    public Button WhiteRoseButton;
    
    private Transform WhiteRoseOptions;

    [Header("Unit look related")]

    [Header("Gets assigned by script")]
    public Button BurstRight;
    public Button BurstLeft;
    public Button WRoseLeftSta1But;
    public Button WRoseRightSta1But;
    public Button WRoseLeftSta2But;
    public Button WRoseRightSta2But;
    public bool Whiterosecontinue;
    public bool whiteroseleft;
    public bool Wdeploystance1;
    public bool PBursting;
    public GameObject DeployedWeiss;
    public MeshRenderer Rend;
    public Material Rubymat;
    public Material Backmat;
    public GameObject ProBui;
    public GenUnit WeissData;

    // Start is called before the first frame update

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
        PBursting = false;
        IsMindBattling = false;
        movespeed = 5;
        Whiterosecontinue = false;
        IsinDeck = true;
        teams = 0;
        direction = (teams == 0) ? 1 : -1;
        desiredPosition = gameObject.transform.position;
        UnitData.cardPicture = Resources.Load<Sprite>("Rubycard 1");
        Rend = GetComponent<MeshRenderer>();
        Rubymat = Resources.Load<Material>("Materials/RubyRose");
        Backmat = Resources.Load<Material>("Materials/BackMat");
//        GetComponent<MeshRenderer>().sharedMaterials = new Material[3]
//        {
//            BuiltinMaterials.defaultMaterial,
//            Rubymat, Backmat
//        };

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

            }

            Stance1rotation();

        }
        if (IsinStance1 == false)
        {
            if (controller.SelectedUnit == gameObject.transform)
            {
                Stance2ButtonsActiv();

            }

            Stance2rotation();

        }
        if (Whiterosecontinue == true)
        {
            if (whiteroseleft == true)
            {

                WhiteRosepart2(gameObject.transform.position + new Vector3(-direction, 0, 0));

            }
            if (whiteroseleft == false)
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
                if (controller.SpottedUnitLeft == null && PBursting == true)
                {
                    PetalMenu.gameObject.SetActive(false);
                    PBursting = false;
                    BurstLeft.onClick.RemoveListener(PetalBurstLeft);
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
                if (controller.SpottedUnitRight == null && PBursting == true)
                {
                    PetalMenu.gameObject.SetActive(false);
                    PBursting = false;
                    BurstRight.onClick.RemoveListener(PetalBurstRight);
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
            WhiteRoseOptions = gameObject.transform.GetChild(4);
            
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
        DeployedWeiss = Instantiate(controller.CardPrefabs[(1)], position, (teams == 0) ? Quaternion.Euler(0, 90 , 0) : Quaternion.Euler(0, -90, 0));
        WeissData = DeployedWeiss.GetComponent<GenUnit>();
        Whiterosecontinue = false;
        Invoke("WeissChange", 0.05f);
        return;
              
    }
    private void Stance2ButtonsActiv()
    {
        Debug.Log("Stance2Buttons being activated.");
        PetalButton.gameObject.SetActive(false);
        WhiteRoseButton.gameObject.SetActive(true);
        WhiteRoseButton.GetComponent<FollowWorld>().lookAt = gameObject;
        WhiteRoseButton.GetComponent<FollowWorld>().offset = (teams == 0) ? new Vector3(0.12f, 0, -0.5f) : new Vector3(-0.12f, 0, 0.5f);
        WhiteRoseButton.onClick.AddListener(WhiteRoseActivate);
        UnitData.sup = UnitData.stance2Stat1;
        UnitData.mind = UnitData.stance2Stat2;

    }
    private void Stance1ButtonsActiv()
    {
        Debug.Log("Stance1Buttons being activated.");
        PetalButton = gameObject.transform.GetChild(0).GetChild(1).GetComponent<Button>();
        PetalButton.gameObject.SetActive(true);
        WhiteRoseButton.gameObject.SetActive(false);
        PetalButton.GetComponent<FollowWorld>().lookAt = gameObject;
        PetalButton.GetComponent<FollowWorld>().offset = (teams == 0) ? new Vector3(0.12f, 0, -0.5f) : new Vector3(-0.12f, 0, 0.5f);
        PetalButton.onClick.AddListener(PetalActivate);
        UnitData.sup = UnitData.stance1Stat1;
        UnitData.mind = UnitData.stance1Stat2;
    }
    private void PetalActivate()
    {
        SpecialOptions.gameObject.SetActive(false);
        PetalButton.onClick.RemoveAllListeners();
        controller.MainOptions.gameObject.SetActive(false);
        PetalMenu = gameObject.transform.GetChild(1);
        PetalMenu.gameObject.SetActive(true);
        BurstLeft = PetalMenu.GetChild(0).GetComponent<Button>();
        BurstRight = PetalMenu.GetChild(1).GetComponent<Button>();
        BurstLeft.onClick.AddListener(PetalBurstLeft);
        BurstRight.onClick.AddListener(PetalBurstRight);
        PBursting = true;


    }
    private void WhiteRoseActivate()
    {
        controller.MainOptions.gameObject.SetActive(false);
        SpecialOptions.gameObject.SetActive(false);
        WhiteRoseButton.onClick.RemoveAllListeners();
        WhiteRoseOptions = gameObject.transform.GetChild(2);
        WhiteRoseOptions.gameObject.SetActive(true);
        WRoseLeftSta1But = WhiteRoseOptions.GetChild(0).GetComponent<Button>();
        WRoseLeftSta2But = WhiteRoseOptions.GetChild(1).GetComponent<Button>();
        WRoseRightSta1But = WhiteRoseOptions.GetChild(2).GetComponent<Button>();
        WRoseRightSta2But = WhiteRoseOptions.GetChild(3).GetComponent<Button>();
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
            whiteroseleft= false;
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
            whiteroseleft = false;
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



}
