using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.ProBuilder.MeshOperations;

public class GameCon1 : MonoBehaviour
{
    [Header("Art stuff")]
    [SerializeField] private Material tileMaterial;

    [Header("Prefabs & Materials")]
    [SerializeField] public GameObject[] Unitprefabs;
    public GameObject SUnit;
    [SerializeField] private Material[] teamMaterials;
    public Material selectionMaterial;
    [Header("Raycast related stuff")]
    public Transform highlight;
    public Transform SelectedUnit;
    public Transform Switchselect;
    public Transform SwitchUnitLeft;
    public Transform SwitchUnitRight;
    public Transform SwitchUnitForward;
    public Transform SwitchUnitBack;
    public Material originalMaterial;
    
    public RaycastHit LeftHit;
    public RaycastHit RightHit;
    public RaycastHit ForwardHit;
    public RaycastHit BackHit;
    public RaycastHit info;
    public Vector3 forwardline;

    public Vector3 Swiraypos;

    [Header("Selected character related")]
    public Transform AttackOptions;
    public Transform MoveOptions;
    public Transform MainOptions;
    public Transform ExtraOptions;
    private GameObject mainmenu;
    private GenUnit SelectedGenUnit;
    public CardTooltipUI CardTipUI;
    public Transform TipUICanvas;
    public Card card;
    public Sprite Image;


    //LOGIC
    public GameObject[,] tiles;
    private Camera currentCamera;
     // Was currentlyDragging in tutorial
    public int teams;
    

    private void Awake()
    {
        


    }

    private void Update()
    {
        

        if (SelectedUnit == null)
        {
           SelectedUnit = null;
       
        }

        if (Input.GetMouseButtonDown(1))
        {
            SelectedUnit.GetComponent<MeshRenderer>().material = originalMaterial;
            SelectedUnit = null;

        }

        if (!currentCamera)
        {
            currentCamera = Camera.main;
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Originally it was like this
        // " if (Physics.Raycast(ray, out info, 100, LayerMask.GetMask("Tile", "Hover", "Selectable")))
        if (!EventSystem.current.IsPointerOverGameObject())
        {

            if (Physics.Raycast(ray, out info, 100) && Input.GetMouseButton(0))
            {

                highlight = info.transform;
                if (highlight.CompareTag("Units"))
                {
                    SelectedUnit = null;
                    SelectedUnit = highlight.transform;
                    Debug.Log($"SelectedUnit is now: {SelectedUnit}");
                    highlight = null;
                    TipUICanvas = CardTipUI.transform.GetChild(0);
                    TipUICanvas.gameObject.SetActive(true);
                    SelectedGenUnit = SelectedUnit.GetComponent<GenUnit>();
                    card = SelectedGenUnit.UnitData;
                    CardTipUI.CardImage = card.CardPicture;
                    CardTipUI.DisplayInfo(card);                    
                    AttackOptions = SelectedUnit.transform.GetChild(0);
                    MainOptions = SelectedUnit.transform.GetChild(1);
                    MoveOptions = SelectedUnit.transform.GetChild(2);
                    ExtraOptions = SelectedUnit.transform.GetChild(3);                  
                    originalMaterial = SelectedUnit.GetComponent<MeshRenderer>().material;
                    SelectedUnit.GetComponent<MeshRenderer>().material = selectionMaterial;
                    
                   
                    if (AttackOptions.gameObject.activeSelf == false && MoveOptions.gameObject.activeSelf == false && ExtraOptions.gameObject.activeSelf == false)
                    {
                        MainOptions.gameObject.SetActive(true);

                    }                   

                }
                
                else
                {
                    MainOptions.gameObject.SetActive(false);
                    SelectedUnit = null;
                }



            }           


        }

        teams = 0;
        int direction = (teams == 0) ? 1 : -1;
        if (Physics.Linecast(SelectedUnit.transform.position, SelectedUnit.transform.position + new Vector3(-direction * 2, 0, 0), out LeftHit))
        {

            if (LeftHit.transform.CompareTag("Units"))
            {
                SwitchUnitLeft = LeftHit.transform;
                Debug.Log($" SwitchUnitLeft is {SwitchUnitLeft}");

            }
            if (SelectedUnit == null)
            {
                return;
            }


        }
        teams = 0;
        int direction1 = (teams == 0) ? 1 : -1;
        if (Physics.Linecast(SelectedUnit.transform.position, SelectedUnit.transform.position + new Vector3(+direction1 * 2, 0, 0), out RightHit))
        {

            if (RightHit.transform.CompareTag("Units"))
            {
                SwitchUnitRight = RightHit.transform;
                Debug.Log($" SwitchUnitRight is {SwitchUnitRight}");

            }
            if (SelectedUnit == null)
            {
                return;
            }


        }
        teams = 0;
        int direction2 = (teams == 0) ? 1 : -1;      
        if (Physics.Linecast(SelectedUnit.transform.position, SelectedUnit.transform.position + new Vector3(0, 0, +direction2 * 2), out ForwardHit))
        {

            if (ForwardHit.transform.CompareTag("Units"))
            {
                SwitchUnitForward = ForwardHit.transform;
                Debug.Log($" SwitchUnitForward is {SwitchUnitForward}");

            }
            if (SelectedUnit == null)
            {
                return;
            }


        }
        teams = 0;
        int direction3 = (teams == 0) ? 1 : -1;
        if (Physics.Linecast(SelectedUnit.transform.position, SelectedUnit.transform.position + new Vector3(0, 0, -direction3 * 2), out BackHit))
            {

            if (BackHit.transform.CompareTag("Units"))
            {
                SwitchUnitBack = BackHit.transform;
                Debug.Log($" SwitchUnitBack is {SwitchUnitBack}");

            }
            if (SelectedUnit == null)
            {
                return;
            }


        }
    }
}




