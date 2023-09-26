using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RubyRose : GenUnit
{
    [SerializeField] private GameObject PetalButton;
    [SerializeField] private GameObject WhiteRoseButton;
    // Start is called before the first frame update
    void Start()
    {
        desiredPosition = gameObject.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * 5);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, Time.deltaTime * 150);
        //transform.localScale = Vector3.MoveTowards(transform.localScale, desiredScale, Time.deltaTime * 5);

        if (controller.SelectedUnit != gameObject.transform)
        {
            Unselected();
        }      

        if (IsinStance1 == true)
        {
            Stance1ButtonsActiv();

        }
        if (IsinStance1 == false)
        {
            Stance2ButtonsActiv();

        }


    }
    public void PetalBurstLeft(int teams)
    {
        if (gameObject.transform.position.x >= 1 && IsinStance1 == true)
        {
            teams = 0;
            int direction = (teams == 0) ? 1 : -1;
            desiredPosition = gameObject.transform.position + new Vector3(-direction, 0, 0);
            Debug.Log($"New desired position is: {desiredPosition}");
        }
        else
        {
            return;
        }
    }
    public void PetalBurstRight(int teams)
    {
        if (gameObject.transform.position.x <= 6 && IsinStance1 == true)
        {
            teams = 0;
            int direction = (teams == 0) ? 1 : -1;
            desiredPosition = gameObject.transform.position + new Vector3(+direction, 0, 0);
            Debug.Log($"New desired position is: {desiredPosition}");
        }

        else
        {
            return;
        }
    }
    private void Stance2ButtonsActiv()
    {
        PetalButton.SetActive(false);
        WhiteRoseButton.SetActive(true);
    }
    private void Stance1ButtonsActiv()
    {
        PetalButton.SetActive(true);
        WhiteRoseButton.SetActive(false);
    }


}
