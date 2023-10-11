using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YangXiaoLong : GenUnit
{
    public Button ShotGunButton;
    public bool DashingShot;
    // Start is called before the first frame update

    void Start()
    {
        
        IsinStance1 = true;
        UnitData.id = 4;
        UnitData.cardName = "Yang Xiao Long";
        UnitData.nickName = "I burn";
        UnitData.type1 = "Human";
        UnitData.type2 = "Hunter";
        UnitData.type3 = "Beacon Academy";
        UnitData.type4 = "RWBY";
        UnitData.type5 = "Remnant";
        UnitData.type6 = "Fire";
        UnitData.healthtext = "HP";
        UnitData.health = 10;
        UnitData.atktext = "Atk";
        UnitData.startatk = 4;
        UnitData.atk = 4;
        UnitData.suptext = "Sup";
        UnitData.sup = 0;
        UnitData.mindtext = "Mind";
        UnitData.mind = 0;
        UnitData.deftext = "Def";
        UnitData.def = 0;
        UnitData.mdeftext = "MDef";
        UnitData.mdef = 0;
        UnitData.agitext = "Agi";
        UnitData.agility = 4;
        UnitData.stance1Text = "If self’s HP is 5 or lower: Double the Atk of self.";
        UnitData.stance1Stattext1 = "Sup";
        UnitData.stance2Text = "[Shotgun dash]/200 MP/: Warp user to 8.";
        UnitData.stance2Stattext1 = "Sup";
        IsMindBattling = false;       
        teams = 0;
        movespeed = 5;
        desiredPosition = gameObject.transform.position;
        UnitData.rageatk = UnitData.atk + UnitData.atk;
        ShotGunButton = transform.GetChild(0).GetChild(0).GetComponent<Button>();
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * movespeed);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);


        if (transform.position.y == 0)
        {
            IsOnField = true;
            
        }

        if (controller.SelectedUnit != gameObject.transform)
        {

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
                if (DashingShot == true)
                {
                    ShotGunDash();

                }

            }       
            
            Stance2rotation();

        }


    }
    public void ShotGunDash()
    {
        ShotGunButton.onClick.RemoveAllListeners();

        if (IsinStance1 == false && (teams == 0) ? gameObject.transform.position.z != 7 : gameObject.transform.position.z != 0)
        {
            if ((teams == 0) ? TurnMan.PlayerData.player1Mana >= 200 : TurnMan.PlayerData.player2Mana >= 200)
            {
                if ((teams == 0) ? controller.SpottedUnitForward == null : controller.SpottedUnitBack == null)
                {
                    TurnMan.DepleteMP(200, teams);
                    direction = (teams == 0) ? 1 : -1;
                    desiredPosition = gameObject.transform.position + new Vector3(0, 0, direction);
                    Debug.Log($"New desired position is: {desiredPosition}");
                    DashingShot = false;

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
    private void Stance2ButtonsActiv()
    {
        ShotGunButton.gameObject.SetActive(true);
        ShotGunButton.GetComponent<FollowWorld>().lookAt = gameObject;
        ShotGunButton.GetComponent<FollowWorld>().offset = (teams == 0) ? new Vector3(0.12f, 0, -0.5f) : new Vector3(-0.12f, 0, 0.5f);
        ShotGunButton.onClick.AddListener(ShotGunBool);
        UnitData.atk = UnitData.startatk;
        UnitData.sup = UnitData.stance2Stat1;

    }
    private void Stance1ButtonsActiv()
    {
        UnitData.sup = UnitData.stance1Stat1;       
        ShotGunButton.gameObject.SetActive(false);
        if (UnitData.health <= 5)
        {
            UnitData.atk = UnitData.rageatk;
        }
        else
        {
            UnitData.atk = UnitData.startatk;
        }

    }
    public void ShotGunBool()
    {
        ShotGunButton.onClick.RemoveAllListeners();
        DashingShot = true;
    }
}
