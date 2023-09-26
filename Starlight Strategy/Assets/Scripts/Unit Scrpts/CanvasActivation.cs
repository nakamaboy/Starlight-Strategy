using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.UIElements;

public class CanvasActivation : MonoBehaviour
{   
    public bool UnitMainOptionsOpen = false;

    [SerializeField] private GameObject Buttons;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ActivateObject();

        }
        
    }
    public void ActivateObject()
    {
        Buttons.SetActive(true);
    }





}
