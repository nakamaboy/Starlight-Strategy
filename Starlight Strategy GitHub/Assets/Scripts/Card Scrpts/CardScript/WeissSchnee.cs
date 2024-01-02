using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class WeissSchnee : GenUnit
{
    [SerializeField] private Button IcePrisButton;
    public bool IcePrisonSelect = false;
   
    TextMeshProUGUI Icetext;
    public Canvas IceCanvas; 
    public bool Icepicktime;
    
    // Start is called before the first frame update
    void Start()
    {
        UnitData.type1 = "Human";
        UnitData.type2 = "Hunter";
        UnitData.type3 = "Beacon Academy";
        UnitData.type4 = "RWBY";
        UnitData.type5 = "Remnant";
        UnitData.type6 = "Water";
        UnitData.healthtext = "HP";
        UnitData.atktext = "Atk";
        UnitData.suptext = "Sup";
        UnitData.mindtext = "Mind";
        UnitData.deftext = "Def";
        UnitData.mdeftext = "MDef";
        UnitData.agitext = "Agi";
        UnitData.stance1Text = "[Ice Prison]/100 MP/(1PL): Put a frozen token on chosen unit on the field.";
        UnitData.stance1Stattext1 = "Sup";
        UnitData.stance1Stattext2 = "Mind";
        UnitData.stance2Stattext1 = "Sup";
        UnitData.stance2Stattext2 = "Mind";
        UnitData.health = 9;
        UnitData.atk = 4;
        UnitData.sup = 0;
        UnitData.mind = 0;
        UnitData.def = 0;
        UnitData.mdef = 0;
        UnitData.agility = 4;
        UnitData.stance1Stat1 = 0;
        UnitData.stance1Stat2 = 0;
        UnitData.stance2Stat1 = 4;
        UnitData.stance2Stat2 = 2;
        IsMindBattling = false;
        movespeed = 5;
        teams = 0;
        IsinStance1 = true;
        movespeed = 5;
        desiredPosition = gameObject.transform.position;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (UnitData.health <= 0)
        {
            IsDestroyedCard = true;
        }
        if (UnitData.health > 0)
        {
            IsDestroyedCard = false;
        }


        if (transform.position.y == 0)
        {
            IsOnField = true;
        }


        if (controller.SelectedUnit != gameObject.transform)
        {
            
        }

        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * movespeed);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);
        //transform.localScale = Vector3.MoveTowards(transform.localScale, desiredScale, Time.deltaTime * 5);

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


        if (Icepicktime == true)
        {
            if (controller.SelectedUnit != null)
            {
                IcePrisstage2();

            }          

        }

        if (Input.GetMouseButtonDown(1))
        {
           Icepicktime = false;
           IceCanvas.gameObject.SetActive(false);
           IcePrisonSelect = false;
        }


    }


    private void Stance2ButtonsActiv()
    {
        IcePrisButton.gameObject.SetActive(false);
        UnitData.sup = UnitData.stance2Stat1;
        UnitData.mind = UnitData.stance2Stat2;

    }
    private void Stance1ButtonsActiv()
    {
        IcePrisButton = transform.GetChild(0).GetChild(0).GetComponent<Button>();
        IcePrisButton.GetComponent<FollowWorld>().lookAt = gameObject;
        IcePrisButton.GetComponent<FollowWorld>().offset = (teams == 0) ? new Vector3(0.12f, 0, -0.5f) : new Vector3(-0.12f, 0, 0.5f);
        IcePrisButton.onClick.AddListener(IcePrisonActivate);
        IcePrisButton.gameObject.SetActive(true);
        UnitData.sup = UnitData.stance1Stat1;
        UnitData.mind = UnitData.stance1Stat2;
    }

    public void IcePrisonActivate()
    {
        IcePrisButton.onClick.RemoveAllListeners();
        controller.MainOptions.gameObject.SetActive(false);
        SpecialOptions.gameObject.SetActive(false);
        IceCanvas = gameObject.transform.GetChild(1).GetComponent<Canvas>();
        IceCanvas.gameObject.SetActive(true);
        Icetext = IceCanvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        Icetext.text = "Choose a unit you would like to put an ice token."; 
        controller.SelectedUnit = null;
        IcePrisonSelect = false;
        Icepicktime = true;
        Debug.Log($"Selected Unit is {controller.SelectedUnit} , original mat is {controller.originalMaterial}");

    }
    public void IcePrisstage2()
    {
        TurnMan.DepleteMP(100, 0);
        controller.SelectedGenUnit.Isfrozen = true;
        Icetext.text = $"{controller.SelectedGenUnit.UnitData.cardName} now has the Ice Token.";
        Icepicktime = false;
        Invoke("IceCanvasDeactive", 1);
        
    }
    public void IceCanvasDeactive()
    {
        IceCanvas.gameObject.SetActive(false);

    }
}
