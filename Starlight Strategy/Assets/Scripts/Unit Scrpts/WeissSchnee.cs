using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class WeissSchnee : GenUnit
{
    [SerializeField] private GameObject IcePrisButton;
    public bool IcePrisonSelect = false;
    Transform Icetext;
    public bool Icepicktime;
    
    // Start is called before the first frame update
    void Start()
    {
        desiredPosition = gameObject.transform.position;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (controller.SelectedUnit != gameObject.transform)
        {
            Unselected();
            
        }

        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * 5);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, Time.deltaTime * 150);
        //transform.localScale = Vector3.MoveTowards(transform.localScale, desiredScale, Time.deltaTime * 5);

        if (IsinStance1 == true)
        {
            Stance1ButtonsActiv();

        }
        if (IsinStance1 == false)
        {
            Stance2ButtonsActiv();

        }

        if (IcePrisonSelect == true)
        {
            IcePrisprep();

            
        }

        if (Icepicktime == true && controller.SelectedUnit != null)
        {
            IcePrisstage2();


        }
        if (Input.GetMouseButtonDown(1))
        {
            Icetext.gameObject.SetActive(false);
            IcePrisonSelect = false;
        }


    }


    private void Stance2ButtonsActiv()
    {
        IcePrisButton.SetActive(false);

    }
    private void Stance1ButtonsActiv()
    {
        IcePrisButton.SetActive(true);
    }

    public void IcePrisonActivate()
    {
        IcePrisonSelect = true;
        
    }
    public void IcePrisprep()
    {
        Debug.Log("IcePrsonSelect is activated.");
        Icetext = gameObject.transform.GetChild(3);
        Icetext.gameObject.SetActive(true);
        Debug.Log($"Selected Unit is {controller.SelectedUnit} , original mat is {controller.originalMaterial}");
        controller.SelectedUnit = null;
        IcePrisonSelect = false;
        Icepicktime = true;
    }
    public void IcePrisstage2()
    {

        Movebutton = controller.SelectedUnit.GetChild(1).GetChild(0);
        Debug.Log(($"{controller.SelectedUnit} now has the ice token."));
        Movebutton.gameObject.SetActive(false);
        Debug.Log($"MoveButton is deactivated. Movebutton is: {Movebutton}");
        Icetext.gameObject.SetActive(false);
        Icepicktime = false;

    }
}
