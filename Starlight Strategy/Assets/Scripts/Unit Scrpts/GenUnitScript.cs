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
    None = 0,
    TheGirl = 1,
    RubyRose = 2,
    WeissSchnee = 3,
    BlakeBelladonna = 4,
    YangXiaoLong = 5,
    QrowBranwen = 6,
    FushichinAkaida = 7,
    HellenHoward = 8,
    KlancyLockhart = 9,
    GaltomorJargalant = 10,
    SalimAziz = 11,

}

// GenUnit = ChessPiece inside the tutorial
public class GenUnit  : MonoBehaviour
{
    public Transform Movebutton;
    public Transform MainOptions;
    public Transform AttackOptions;
    public Transform MoveOptions;
    public GameObject SwitchUnit;
    public GenUnit Switchbuddy;
    public int team;
    public int currentX;
    public int currentY;
    public UnitListNames names; //types in tutorial 
    public Vector3 desiredPosition;
    public Quaternion desiredRotation;
    public Vector3 desiredScale;
    public CardTextBuilder UnitData; 
    public GameCon1 controller;
    public bool IsinStance1 = true;
    //public GameBoard.;

    public void Awake()
    {


    }

    private void Start()
    {
 
        
        
            
    }
    private void Update()
    {
       

    }


    public void MoveForward(int teams)
    {
        teams = 0;
        int direction2 = (teams == 0) ? 1 : -1;
        if (gameObject.transform.position.z <= 6)
        {
            
            if (controller.SwitchUnitForward == null)
            {
                desiredPosition = gameObject.transform.position + new Vector3(0, 0, +direction2);

            }
            if (gameObject.transform.position + new Vector3(0, 0, +direction2) == controller.SwitchUnitForward.transform.position)
            {
                controller.SwitchUnitForward.transform.position = gameObject.transform.position + new Vector3(0, 0, +direction2);
                Switchbuddy = controller.SwitchUnitForward.GetComponent<GenUnit>();
                desiredPosition = gameObject.transform.position + new Vector3(0, 0, +direction2);
                Switchbuddy.desiredPosition = gameObject.transform.position;
            }
            else
            {
                desiredPosition = gameObject.transform.position + new Vector3(0, 0, +direction2);

            }
            
        }
        else
        {
            return;
        }       

    }

    public void MoveBackwards(int teams)
    {
        teams = 0;
        int direction3 = (teams == 0) ? 1 : -1;
        if (gameObject.transform.position.z >= 1)
        {
            
            if (controller.SwitchUnitBack == null)
            {
                desiredPosition = gameObject.transform.position + new Vector3(0, 0, -direction3);

            }
            if (gameObject.transform.position + new Vector3(0, 0, -direction3) == controller.SwitchUnitBack.transform.position)
            {
                controller.SwitchUnitBack.transform.position = gameObject.transform.position + new Vector3(0, 0, -direction3);
                Switchbuddy = controller.SwitchUnitBack.GetComponent<GenUnit>();
                desiredPosition = gameObject.transform.position + new Vector3(0, 0, -direction3);
                Switchbuddy.desiredPosition = gameObject.transform.position;
            }
            else
            {
                desiredPosition = gameObject.transform.position + new Vector3(0, 0, -direction3);

            }
            

        }
        else
        {
            return;
        }

    }

    public void MoveLeft(int teams)
    {
        teams = 0;
        int direction = (teams == 0) ? 1 : -1;
        if (gameObject.transform.position.x >= 1)
        {
            if (controller.SwitchUnitLeft == null)
            {
                desiredPosition = gameObject.transform.position + new Vector3(-direction, 0, 0);

            }
            if (gameObject.transform.position + new Vector3(-direction, 0, 0) == controller.SwitchUnitLeft.transform.position)
            {
                controller.SwitchUnitLeft.transform.position = gameObject.transform.position + new Vector3(-direction, 0, 0);
                Debug.Log($"SwitchUnitLeft is {controller.SwitchUnitLeft}");
                Switchbuddy = controller.SwitchUnitLeft.GetComponent<GenUnit>();
                desiredPosition = gameObject.transform.position + new Vector3(-direction, 0, 0);
                Switchbuddy.desiredPosition = gameObject.transform.position;
            }
            
            else
            {
                desiredPosition = gameObject.transform.position + new Vector3(-direction, 0, 0);
            }

        }                                  
            
        else
        {
            return;
        }

    }

    public void MoveRight(int teams)
    {
        teams = 0;
        int direction = (teams == 0) ? 1 : -1;
        if (gameObject.transform.position.x <= 6)
        {
            
            if (controller.SwitchUnitRight == null)
            {
                desiredPosition = gameObject.transform.position + new Vector3(+direction, 0, 0);

            }
            if (gameObject.transform.position + new Vector3(+direction, 0, 0) == controller.SwitchUnitRight.transform.position)
            {
                controller.SwitchUnitRight.transform.position = gameObject.transform.position + new Vector3(+direction, 0, 0);
                Debug.Log($"SwitchUnitRight is {controller.SwitchUnitRight}");
                Switchbuddy = controller.SwitchUnitRight.GetComponent<GenUnit>();
                desiredPosition = gameObject.transform.position + new Vector3(+direction, 0, 0);
                Switchbuddy.desiredPosition = gameObject.transform.position;
            }
            
            else
            {
                desiredPosition = gameObject.transform.position + new Vector3(+direction, 0, 0);
            }
            

        }
        else
        {
            return;
        }
    }
    public void SwitchStance(int teams)
    {
        //if (Vector3.Angle(transform.forward, Vector3.forward) < 1)
        // transform.rotation never exceeds 1 
        if (gameObject.transform.rotation.y >= 0.7)
        {
            teams = 0;
            Quaternion direction = Quaternion.Euler((teams == 0) ? new Vector3(0, 0, 0) : new Vector3(0, 0, 0));
            desiredRotation = Quaternion.Euler(0, direction.eulerAngles.y, 0);
            IsinStance1 = true;


        }

        if (gameObject.transform.rotation.y == 0)
        {
            teams = 0;
            Quaternion direction = Quaternion.Euler((teams == 0) ? new Vector3(0, 90, 0) : new Vector3(0 ,-90, 0));
            desiredRotation = Quaternion.Euler(0, direction.eulerAngles.y, 0);
            IsinStance1 = false;

        }

    }
    public void Unselected()
    {
        AttackOptions = gameObject.transform.GetChild(1);
        MainOptions = gameObject.transform.GetChild(1);
        MoveOptions = gameObject.transform.GetChild(2);
        AttackOptions.gameObject.SetActive(false);
        MainOptions.gameObject.SetActive(false);
        MoveOptions.gameObject.SetActive(false);
        transform.GetComponent<MeshRenderer>().material = controller.originalMaterial;

    }

}
