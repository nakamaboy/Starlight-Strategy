using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlakeBelladonna : GenUnit
{
    // Start is called before the first frame update
    void Start()
    {
        IsinStance1 = true;
        UnitData.type1 = "Faunus";
        UnitData.type2 = "Hunter";
        UnitData.type3 = "Beacon Academy";
        UnitData.type4 = "RWBY";
        UnitData.type5 = "Remnant";
        UnitData.type6 = "Dark";
        UnitData.healthtext = "HP";
        UnitData.health = 9;
        UnitData.atktext = "Atk";
        UnitData.atk = 3;
        UnitData.suptext = "Sup";
        UnitData.sup = 0;
        UnitData.mindtext = "Mind";
        UnitData.mind = 0;
        UnitData.deftext = "Def";
        UnitData.def = 1;
        UnitData.mdeftext = "MDef";
        UnitData.mdef = 0;
        UnitData.agitext = "Agi";
        UnitData.agility = 5;
        UnitData.stance1Text = "[Shadow Clone]/100 MP/ When an opponent’s unit declares an attack on self: Warp user to 7 or 9.";
        UnitData.stance1Stattext1 = "Sup";
        UnitData.stance1Stat1 = 0;
        UnitData.stance2Text = "[Bumblebee]/100 MP/(1PL): Extra deploy “Yang Xiao Long” from your Deck at 4 or 6.";
        UnitData.stance2Stattext1 = "Sup";
        UnitData.stance2Stat1 = 3;
        IsMindBattling = false;
        movespeed = 5;
        teams = 0;
        direction = (teams == 0) ? 1 : -1;
        desiredPosition = gameObject.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * movespeed);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, Time.deltaTime * 150);
        //transform.localScale = Vector3.MoveTowards(transform.localScale, desiredScale, Time.deltaTime * 5);

        if (transform.position.y == 0)
        {
            IsOnField = true;
        }


        if (controller.SelectedUnit != gameObject.transform)
        {

        }

        if (IsinStance1 == true)
        {
            Stance1ButtonsActiv();
            Stance1rotation();

        }
        if (IsinStance1 == false)
        {

            Stance2ButtonsActiv();
            Stance2rotation();

        }

    }

    private void Stance2ButtonsActiv()
    {
        
        UnitData.sup = UnitData.stance2Stat1;
        UnitData.mind = UnitData.stance2Stat2;

    }
    private void Stance1ButtonsActiv()
    {               
        UnitData.sup = UnitData.stance1Stat1;
        UnitData.mind = UnitData.stance1Stat2;
    }
}
