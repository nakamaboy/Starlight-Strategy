using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public enum UnitListNames // ChessPieceTypes in tutorial
{
    RubyRose = 0,
    WeissSchnee = 1,
    BlakeBelladonna = 2,
    YangXiaoLong = 3,
    QrowBranwen = 4,
    FushichinAkaida = 6,
    HellenHoward = 7,
    KlancyLockhart = 8,
    GaltomorJargalant = 9,
    SalimAziz = 10,
    Cahara = 11,
    Enki = 12,
    Ragnavaldar = 13,
    Dharce = 14,
    TheGirl = 15,
    GOFAH = 16,



}

// GenUnit = ChessPiece inside the tutorial
public class GenUnit  : MonoBehaviour
{
    public Vector3 SpecialDeckPos1;
    public Vector3 MainDeckPos1;
    public Vector3 DiscardPoolPos1;
    public Vector3 VoidPoolPos1;
    public Vector3 SpecialDeckPos2;
    public Vector3 MainDeckPos2;
    public Vector3 DiscardPoolPos2;
    public Vector3 VoidPoolPos2;
    public Vector3 MyMoveDirection;
    public DeckManager DeckMan;
    public int direction;
    public int movespeed;
    public int teams;
    
    public Vector3 desiredPosition;
    public Quaternion desiredRotation;
    public Vector3 desiredScale;
    public bool IsOnField;
    public bool IsinHand;
    public bool IsinDP;
    public bool IsinVoid;
    public bool IsinDeck;
    public bool Isfacedown;
    public Transform SpecialOptions;
    public Transform Movebutton;
    public Transform MainOptions;
    public Transform AttackOptions;
    public Transform MoveOptions;
    public GameObject SwitchUnit;
    public GenUnit Switchbuddy;
    public UnitListNames names;  
    public CardTextBuilder UnitData;
    public TurnManager TurnMan;
    public GameCon1 controller;
    public CardTooltipUI TipUI;
    public Quaternion rotatedirection;
    public Card card;
    public bool IsinStance1;

    public bool IsMindBattling;
   
    public CardTextBuilder EnemyData;
    public int PreviousinHand;

    [Header("Field related")]
    public GameObject TheEnemy;
    public int DamageDealt;
    public int rotationSpeed;

    [Header("Deploy related")]

    public bool DeployinSta1;

    [Header("Status effects")]
    public bool Isfrozen;


    public void Awake()
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
        
//        TurnMan = Resources.Load<TurnManager>("Card prefabs/TurnManager 2");
//        controller = Resources.Load<GameCon1>("Card prefabs/BoardController 1");
//        DeckMan = Resources.Load<DeckManager>("Card prefabs/DeckManager 1");
//        TipUI = Resources.Load<CardTooltipUI>("Card prefabs/CardTooltipUI 1");
        


    }

    private void Start()
    {
        

       
        
            
    }
    private void Update()
    {
       

    }
    public void AttackForward()
    {

        if (controller.EnemyUnitForward != null)
        {
            EnemyData = controller.EnemyGenUnitForward.UnitData;
            TheEnemy = controller.EnemyUnitForward.gameObject;
            if (IsMindBattling == true)
            {
                DamageDealt = UnitData.mind - EnemyData.mdef;
                EnemyData.health -= DamageDealt;
                Invoke("DamageDisplay", 0);



            }
            else
            {
                if (EnemyData.agility >= UnitData.agility * 2)
                {
                    return;

                }
                else
                {
                    DamageDealt = UnitData.atk - EnemyData.def + controller.SupportingMe;
                    EnemyData.health -= DamageDealt;
                    Invoke("DamageDisplay", 0);

                }

            }

        }
        else
        {
            return;
        }


    }
    public void AttackLeft()
    {

        if (controller.EnemyUnitLeft != null)
        {
            EnemyData = controller.EnemyGenUnitLeft.UnitData;
            if (EnemyData.agility >= UnitData.agility * 2)
            {
                return;

            }
            else
            {
                if (IsMindBattling == true)
                {
                    EnemyData.health -= UnitData.mind - EnemyData.mdef;

                }

                else
                {
                    EnemyData.health -= UnitData.atk - EnemyData.def + controller.SupportingMe;
                }
            }

        }
        else
        {
            return;
        }


    }
    public void AttackRight()
    {


        if (controller.EnemyUnitRight != null)
        {
            EnemyData = controller.EnemyGenUnitRight.UnitData;
            if (EnemyData.agility >= UnitData.agility * 2)
            {
                return;

            }
            else
            {
                if (IsMindBattling == true)
                {
                    EnemyData.health -= UnitData.mind - EnemyData.mdef;

                }
                else
                {
                    EnemyData.health -= UnitData.atk - EnemyData.def + controller.SupportingMe;
                }
            }

        }
        else
        {
            return;
        }


    }
    public void AttackBack()
    {

        if (controller.EnemyUnitBack != null)
        {
            EnemyData = controller.EnemyGenUnitBack.UnitData;
            if (EnemyData.agility >= UnitData.agility * 2)
            {
                return;

            }
            else
            {
                if (IsMindBattling == true)
                {
                    EnemyData.health -= UnitData.mind - EnemyData.mdef;

                }
                else
                {
                    EnemyData.health -= UnitData.atk - EnemyData.def + controller.SupportingMe;
                }
            }


        }
        else
        {
            return;
        }


    }


    public void MoveForward()
    {

        direction = (teams == 0) ? 1 : -1;
        if (gameObject.transform.position.z != 7 && teams == 0 || gameObject.transform.position.z != 0 && teams == 1)
        {
            if (controller.EnemyUnitForward != null)
            {
                return;
            }
            if (controller.SwitchUnitForward != null)
            {
                Switchbuddy = controller.SwitchUnitForward.GetComponent<GenUnit>();
                desiredPosition = gameObject.transform.position + new Vector3(0, 0, +direction);
                Switchbuddy.desiredPosition = gameObject.transform.position;
                
            }            
            
            else
            {
                MyMoveDirection = gameObject.transform.position + new Vector3(0, 0, +direction);
                if (MyMoveDirection == SpecialDeckPos1 | MyMoveDirection == SpecialDeckPos2 | MyMoveDirection == MainDeckPos2 | MyMoveDirection == MainDeckPos1 | MyMoveDirection == DiscardPoolPos2 | MyMoveDirection == DiscardPoolPos1 | MyMoveDirection == VoidPoolPos1 | MyMoveDirection == VoidPoolPos2)
                {
                    return;

                }
                else
                {
                    desiredPosition = gameObject.transform.position + new Vector3(0, 0, +direction);

                }                

            }
            
        }
        else
        {
            return;
        }       

    }

    public void MoveBackwards()
    {


        direction = (teams == 0) ? 1 : -1;
        if (gameObject.transform.position.z != 0 && teams == 0 || gameObject.transform.position.z != 7 && teams == 1)
        {
            if (controller.EnemyUnitBack != null)
            {
                return;
            }
            if (controller.SwitchUnitBack != null)
            {
                Switchbuddy = controller.SwitchUnitBack.GetComponent<GenUnit>();                
                desiredPosition = gameObject.transform.position + new Vector3(0, 0, -direction);
                Switchbuddy.desiredPosition = gameObject.transform.position;               

            }
            
            else
            {
                MyMoveDirection = gameObject.transform.position + new Vector3(0, 0, -direction);
                if (MyMoveDirection == SpecialDeckPos1 | MyMoveDirection == SpecialDeckPos2 | MyMoveDirection == MainDeckPos2 | MyMoveDirection == MainDeckPos1 | MyMoveDirection == DiscardPoolPos2 | MyMoveDirection == DiscardPoolPos1 | MyMoveDirection == VoidPoolPos1 | MyMoveDirection == VoidPoolPos2)
                {
                    return;

                }
                else
                {
                    desiredPosition = gameObject.transform.position + new Vector3(0, 0, -direction);

                }


               

            }
            

        }
        else
        {
            return;
        }

    }

    public void MoveLeft()
    {


        direction = (teams == 0) ? 1 : -1;
        if ((teams == 0) ? gameObject.transform.position.x != 0 : gameObject.transform.position.x != 7)
        {
            if (controller.EnemyUnitLeft != null)
            {
                return;
            }
            if (controller.SwitchUnitLeft != null)
            {
                Switchbuddy = controller.SwitchUnitLeft.GetComponent<GenUnit>();
                desiredPosition = gameObject.transform.position + new Vector3(-direction, 0, 0);
                Switchbuddy.desiredPosition = gameObject.transform.position;
            }           
            else
            {
                MyMoveDirection = gameObject.transform.position + new Vector3(-direction, 0, 0);
                if (MyMoveDirection == SpecialDeckPos1 | MyMoveDirection == SpecialDeckPos2 | MyMoveDirection == MainDeckPos2 | MyMoveDirection == MainDeckPos1 | MyMoveDirection == DiscardPoolPos2 | MyMoveDirection == DiscardPoolPos1 | MyMoveDirection == VoidPoolPos1 | MyMoveDirection == VoidPoolPos2)
                {
                    return;

                }
                else
                {
                    desiredPosition = gameObject.transform.position + new Vector3(-direction, 0, 0);

                }
                
            }

        }                                  
            
        else
        {
            return;
        }

    }

    public void MoveRight()
    {
        direction = (teams == 0) ? 1 : -1;
        if ((teams == 0) ? gameObject.transform.position.x != 7 : gameObject.transform.position.x != 0)
        {
            if (controller.EnemyUnitRight != null)
            {
                return;
            }
            if (controller.SwitchUnitRight != null)
            {
                Switchbuddy = controller.SwitchUnitRight.GetComponent<GenUnit>();
                desiredPosition = gameObject.transform.position + new Vector3(+direction, 0, 0);
                Switchbuddy.desiredPosition = gameObject.transform.position;

            }
                                   
            else
            {
                MyMoveDirection = gameObject.transform.position + new Vector3(+direction, 0, 0);
                if (MyMoveDirection == SpecialDeckPos1 | MyMoveDirection == SpecialDeckPos2 | MyMoveDirection == MainDeckPos2 | MyMoveDirection == MainDeckPos1 | MyMoveDirection == DiscardPoolPos2 | MyMoveDirection == DiscardPoolPos1 | MyMoveDirection == VoidPoolPos1 | MyMoveDirection == VoidPoolPos2)
                {
                    return;

                }
                else
                {
                    desiredPosition = gameObject.transform.position + new Vector3(+direction, 0, 0);

                }
                
            }
            

        }
        else
        {
            return;
        }
    }
    public void SwitchStance()
    {
        if (IsinStance1 == false)
        {
            IsinStance1 = true;
            

        }

        else 
        {
            
            IsinStance1 = false;
            
        }
    }
    public void MoveToHand()
    {
        IsOnField = false;
        IsinDeck = false;
        movespeed = 20;
        if (!IsinHand)
        {
            IsinHand = true;
            Debug.Log($"I have {DeckMan.CardsinHand} in Hand.");

        }


    }
    public void OnDeployChanges()
    {
        movespeed = 5;
        DeckMan.CardsinHand -= 1;

    }

    public void Stance1rotation()
    {
        rotatedirection = Quaternion.Euler((teams == 0) ? new Vector3(0, 0, 0) : new Vector3(0, 180, 0));
        desiredRotation = Quaternion.Euler(0, rotatedirection.eulerAngles.y, 0);


    }
    public void Stance2rotation()
    {
        rotatedirection = Quaternion.Euler((teams == 0) ? new Vector3(0, 90, 0) : new Vector3(0, -90, 0));
        desiredRotation = Quaternion.Euler(0, rotatedirection.eulerAngles.y, 0);


    }
    public void DamageDisplay()
    {
        controller.DamageCanvas.gameObject.SetActive(true);
        controller.DamageShowText.text = $"<color=#ff0000>-{DamageDealt}" + "<color=#228b22>HP";
        controller.DamageShowText.GetComponent<FollowWorld>().lookAt = TheEnemy.gameObject;
       // controller.DamageShowText.color = Color.red;
        controller.DamageShowText.fontSize = 15;
        Invoke("DamDisplayDeact", 1);

    }
    public void DamDisplayDeact()
    {
        controller.DamageCanvas.gameObject.SetActive(false);

    }
  

}
