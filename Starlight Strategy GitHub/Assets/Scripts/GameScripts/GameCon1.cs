using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.UI;

public class GameCon1 : MonoBehaviour
{
    [Header("Art stuff")]
    [SerializeField] private Material tileMaterial;

    [Header("Prefabs & Materials")]
    [SerializeField] public List<GameObject> CardPrefabs = new List<GameObject>();
    public GameObject SUnit;
    [SerializeField] private Material[] teamMaterials;
    public Material selectionMaterial;
    [Header("Raycast related stuff")]
    public Transform highlight;
    public Transform SelectedUnit;
    public Transform Switchselect;
    public Transform SpottedUnitLeft;
    public Transform SpottedUnitRight;
    public Transform SpottedUnitForward;
    public Transform SpottedUnitBack;
    public Transform EnemyUnitLeft;
    public Transform EnemyUnitRight;
    public Transform EnemyUnitForward;
    public Transform EnemyUnitBack;
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
    public RaycastHit LeftLine;
    public Vector3 forwardline;

    [Header("Selected character related")]

    public Transform ExtraOptions;
    private GameObject mainmenu;
    public GenUnit SelectedGenUnit;
    public GenUnit LeftGenUnit;
    public GenUnit RightGenUnit;
    public GenUnit ForwardGenUnit;
    public GenUnit BackGenUnit;
    public GenUnit SwitchGenUnitLeft;
    public GenUnit SwitchGenUnitRight;
    public GenUnit SwitchGenUnitForward;
    public GenUnit SwitchGenUnitBack;
    public GenUnit EnemyGenUnitLeft;
    public GenUnit EnemyGenUnitRight;
    public GenUnit EnemyGenUnitForward;
    public GenUnit EnemyGenUnitBack;
    public CardTooltipUI CardTipUI;
    public Transform TipUICanvas;
    public Card card;
    public Sprite Image;
    public int SupportingMe;

    [Header("Selected In Hand related")]

    public GameObject InHandCanvas;
    public GameObject DeployCanvas;
    public Button NormalDepButt;
    public FollowWorld NormalDepTarget;
    public Button Sta1DepButt;
    public Button Sta2DepButt;
    public Image Stance1Image;
    public Image Stance2Image;
    public GameObject ChooseTileDeploy;
    public Button NDeployTile1;
    public Button NDeployTile2;
    public Button NDeployTile3;
    public Button NDeployTile4;
    public Button NDeployTile5;
    public Button NDeployTile6;
    public Button NDeployTile7;
    public Button NDeployTile8;
    public Vector3 DeployingPosition;
    public bool DeployTime;
    public RaycastHit DeployingHit;
    public Transform DeployingPosSpot;

    [Header("Selected FieldUnit Control related")]
    public Transform UnitController;
    public Transform AttackOptions;
    public Transform MoveOptions;
    public Transform MainOptions;
    public Button AttackForwardBut;
    public Button AttackLeftBut;
    public Button AttackRightBut;
    public Button AttackBackBut;
    public Button MoveForwardBut;
    public Button MoveLeftBut;
    public Button MoveRightBut;
    public Button MoveBackBut;
    public Button MainMoveBut;
    public Button MainAttackBut;
    public Button SwitchStanceBut;
    public TextMeshProUGUI DamageShowText;
    public Canvas DamageCanvas;



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
        if (SelectedUnit != null)
        {
            SelectedGenUnit = SelectedUnit.GetComponent<GenUnit>();
            if (SelectedGenUnit != null)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    SelectedUnit.GetComponent<MeshRenderer>().material = originalMaterial;
                    MainOptions.gameObject.SetActive(false);
                    SelectedGenUnit.SpecialOptions.gameObject.SetActive(false);
                    AttackOptions.gameObject.SetActive(false);
                    MoveOptions.gameObject.SetActive(false);
                    ChooseTileDeploy.SetActive(false);
                    DeployCanvas.SetActive(false);
                    InHandCanvas.SetActive(false);
                    SelectedUnit = null;

                }
                CardTipUI.CardDataChangeEvent.Invoke(SelectedGenUnit.UnitData);
                int ReferSwiGenUnitBack = (SwitchGenUnitBack == null) ? 0 : SwitchGenUnitBack.UnitData.sup;
                int ReferSwiGenUnitForward = (SwitchGenUnitForward == null) ? 0 : SwitchGenUnitForward.UnitData.sup;
                int ReferSwiGenUnitLeft = (SwitchGenUnitLeft == null) ? 0 : SwitchGenUnitLeft.UnitData.sup;
                int ReferSwiGenUnitRight = (SwitchGenUnitRight == null) ? 0 : SwitchGenUnitRight.UnitData.sup;
                if (SelectedGenUnit.IsOnField == true)
                {
                    SupportingMe = ReferSwiGenUnitBack + ReferSwiGenUnitForward + ReferSwiGenUnitLeft + ReferSwiGenUnitRight;
                    card.SupMe = SupportingMe;

                    if (AttackOptions.gameObject.activeSelf == true)
                    {


                    }
                    if (MainOptions.gameObject.activeSelf == true)
                    {



                    }
                }







            }


            int direction = (teams == 0) ? 1 : -1;
            if (Physics.Linecast(SelectedUnit.transform.position + new Vector3(-0.5f, 0, 0), SelectedUnit.transform.position + new Vector3(-direction * 2, 0, 0), out LeftHit))
            {
                SpottedUnitLeft = LeftHit.transform;
                LeftGenUnit = SpottedUnitLeft.GetComponent<GenUnit>();

                if (LeftHit.transform.CompareTag("Units") && SelectedUnit.transform.position + new Vector3(-direction, 0, 0) == LeftHit.transform.position)
                {
                    if (SelectedGenUnit.teams == LeftGenUnit.teams)
                    {
                        SwitchUnitLeft = LeftHit.transform;
                        SwitchGenUnitLeft = SwitchUnitLeft.GetComponent<GenUnit>();
                        Debug.Log($" SwitchUnitLeft is {SwitchUnitLeft}");

                    }
                    if (SelectedGenUnit.teams != LeftGenUnit.teams)
                    {
                        EnemyUnitLeft = LeftHit.transform;
                        EnemyGenUnitLeft = EnemyUnitLeft.GetComponent<GenUnit>();
                        Debug.Log($" EnemyUnitLeft is {EnemyUnitLeft}");
                    }

                    else
                    {

                    }

                }
                else
                {
                    SwitchUnitLeft = null;
                    EnemyUnitLeft = null;
                    SwitchGenUnitLeft = null;
                    EnemyGenUnitLeft = null;
                    SpottedUnitLeft = null;
                    LeftGenUnit = null;

                }

            }

            if (Physics.Linecast(SelectedUnit.transform.position + new Vector3(0.5f, 0, 0), SelectedUnit.transform.position + new Vector3(+direction * 2, 0, 0), out RightHit))
            {
                SpottedUnitRight = RightHit.transform;
                RightGenUnit = SpottedUnitRight.GetComponent<GenUnit>();

                if (RightHit.transform.CompareTag("Units") && SelectedUnit.transform.position + new Vector3(+direction, 0, 0) == RightHit.transform.position)
                {
                    if (SelectedGenUnit.teams == RightGenUnit.teams)
                    {
                        SwitchUnitRight = RightHit.transform;
                        SwitchGenUnitRight = SwitchUnitRight.GetComponent<GenUnit>();
                        Debug.Log($" SwitchUnitRight is {SwitchUnitRight}");
                    }
                    if (SelectedGenUnit.teams != RightGenUnit.teams)
                    {
                        EnemyUnitRight = RightHit.transform;
                        EnemyGenUnitRight = EnemyUnitRight.GetComponent<GenUnit>();

                        Debug.Log($" EnemyUnitRight is {EnemyUnitRight}");
                    }

                    else
                    {

                    }

                }
                else
                {
                    SwitchUnitRight = null;
                    EnemyUnitRight = null;
                    SwitchGenUnitRight = null;
                    EnemyGenUnitRight = null;
                    SpottedUnitRight = null;
                    RightGenUnit = null;

                }

            }
            if (Physics.Linecast(SelectedUnit.transform.position + new Vector3(0, 0, 0.5f), SelectedUnit.transform.position + new Vector3(0, 0, +direction * 2), out ForwardHit))
            {
                SpottedUnitForward = ForwardHit.transform;
                ForwardGenUnit = SpottedUnitForward.GetComponent<GenUnit>();
                if (ForwardHit.transform.CompareTag("Units") && SelectedUnit.transform.position + new Vector3(0, 0, +direction) == ForwardHit.transform.position)
                {

                    if (SelectedGenUnit.teams == ForwardGenUnit.teams)
                    {
                        SwitchUnitForward = ForwardHit.transform;
                        SwitchGenUnitForward = SwitchUnitForward.GetComponent<GenUnit>();
                        Debug.Log($" SwitchUnitForward is {SwitchUnitForward}");
                    }
                    if (SelectedGenUnit.teams != ForwardGenUnit.teams)
                    {
                        EnemyUnitForward = ForwardHit.transform;
                        EnemyGenUnitForward = EnemyUnitForward.GetComponent<GenUnit>();
                        Debug.Log($" EnemyUnitForward is {EnemyUnitForward}");
                    }

                    else
                    {

                    }

                }
                else
                {
                    SwitchUnitForward = null;
                    EnemyUnitForward = null;
                    SwitchGenUnitForward = null;
                    EnemyGenUnitForward = null;
                    SpottedUnitForward = null;
                    ForwardGenUnit = null;

                }


            }
            int direction3 = (teams == 0) ? 1 : -1;
            if (Physics.Linecast(SelectedUnit.transform.position + new Vector3(0, 0, -0.5f), SelectedUnit.transform.position + new Vector3(0, 0, -direction3 * 2), out BackHit))
            {
                SpottedUnitBack = BackHit.transform;
                BackGenUnit = SpottedUnitBack.GetComponent<GenUnit>();
                if (BackHit.transform.CompareTag("Units") && SelectedUnit.transform.position + new Vector3(0, 0, -direction3) == BackHit.transform.position)
                {

                    if (SelectedGenUnit.teams == BackGenUnit.teams)
                    {
                        SwitchUnitBack = BackHit.transform;
                        SwitchGenUnitBack = SwitchUnitBack.GetComponent<GenUnit>();
                        Debug.Log($" SwitchUnitBack is {SwitchUnitBack}");
                    }
                    if (SelectedGenUnit.teams != BackGenUnit.teams)
                    {
                        EnemyUnitBack = BackHit.transform;
                        EnemyGenUnitBack = EnemyUnitBack.GetComponent<GenUnit>();
                        Debug.Log($" EnemyUnitBack is {EnemyUnitBack}");
                    }

                    else
                    {

                    }


                }
                else
                {
                    SwitchUnitBack = null;
                    EnemyUnitBack = null;
                    SwitchGenUnitBack = null;
                    EnemyGenUnitBack = null;
                    SpottedUnitBack = null;
                    BackGenUnit = null;

                }
            }



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
                    if (SelectedUnit != null)
                    {
                        SelectedGenUnit.SpecialOptions.gameObject.SetActive(false);
                        

                        SwitchUnitLeft = null;
                        EnemyUnitLeft = null;
                        SwitchGenUnitLeft = null;
                        EnemyGenUnitLeft = null;

                        LeftGenUnit = null;
                        SwitchUnitRight = null;
                        EnemyUnitRight = null;
                        SwitchGenUnitRight = null;
                        EnemyGenUnitRight = null;

                        RightGenUnit = null;
                        SwitchUnitForward = null;
                        EnemyUnitForward = null;
                        SwitchGenUnitForward = null;
                        EnemyGenUnitForward = null;

                        ForwardGenUnit = null;
                        SwitchUnitBack = null;
                        EnemyUnitBack = null;
                        SwitchGenUnitBack = null;
                        EnemyGenUnitBack = null;

                        SpottedUnitForward = null;
                        SpottedUnitLeft = null;
                        SpottedUnitRight = null;
                        SpottedUnitBack = null;

                        BackGenUnit = null;
                        InHandCanvas.SetActive(false);
                        ChooseTileDeploy.SetActive(false);
                        DeployCanvas.SetActive(false);
                        InHandCanvas.SetActive(false);
                        SelectedUnit = null;
                        SelectedGenUnit = null;

                        AttackForwardBut.onClick.RemoveAllListeners();
                        AttackBackBut.onClick.RemoveAllListeners();
                        AttackLeftBut.onClick.RemoveAllListeners();
                        AttackRightBut.onClick.RemoveAllListeners();
                        MainAttackBut.onClick.RemoveAllListeners();
                        MainMoveBut.onClick.RemoveAllListeners();
                        SwitchStanceBut.onClick.RemoveAllListeners();
                        MoveForwardBut.onClick.RemoveAllListeners();
                        MoveBackBut.onClick.RemoveAllListeners();
                        MoveLeftBut.onClick.RemoveAllListeners();
                        MoveRightBut.onClick.RemoveAllListeners();
                        SelectedUnit = highlight;
                        Debug.Log($"SelectedUnit is now: {SelectedUnit}");

                        SelectedGenUnit = SelectedUnit.GetComponent<GenUnit>();
                        TipUICanvas = CardTipUI.transform.GetChild(0);
                        TipUICanvas.gameObject.SetActive(true);
                        card = SelectedGenUnit.UnitData;
                        CardTipUI.CardImage = card.cardPicture;
                        CardTipUI.DisplayInfo(card);
                        originalMaterial = SelectedUnit.GetComponent<MeshRenderer>().material;
                        SelectedUnit.GetComponent<MeshRenderer>().material = selectionMaterial;
                        highlight = null;
                        if (SelectedGenUnit.IsOnField == true)
                        {
                            MainOptionsSetMeth();



                        }
                        if (SelectedGenUnit.IsinHand == true)
                        {

                            InHandCanvas.SetActive(true);
                            NormalDepTarget = NormalDepButt.GetComponent<FollowWorld>();
                            NormalDepTarget.lookAt = SelectedUnit.gameObject;
                            NormalDepButt.onClick.AddListener(NormalDepFunction);

                        }

                    }
                    else
                    {
                        SelectedUnit = highlight.transform;
                        Debug.Log($"SelectedUnit is now: {SelectedUnit}");

                        SelectedGenUnit = SelectedUnit.GetComponent<GenUnit>();
                        TipUICanvas = CardTipUI.transform.GetChild(0);
                        TipUICanvas.gameObject.SetActive(true);
                        card = SelectedGenUnit.UnitData;
                        CardTipUI.CardImage = card.cardPicture;
                        CardTipUI.DisplayInfo(card);

                        originalMaterial = SelectedUnit.GetComponent<MeshRenderer>().material;
                        SelectedUnit.GetComponent<MeshRenderer>().material = selectionMaterial;
                        highlight = null;
                        if (SelectedGenUnit.IsOnField == true)
                        {
                            MainOptionsSetMeth();


                        }
                        if (SelectedGenUnit.IsinHand == true)
                        {

                            InHandCanvas.SetActive(true);
                            NormalDepTarget = NormalDepButt.GetComponent<FollowWorld>();
                            NormalDepTarget.lookAt = SelectedUnit.gameObject;
                            NormalDepButt.onClick.AddListener(NormalDepFunction);

                        }

                    }

                    

                    

                }



                else
                {
                    MainOptions.gameObject.SetActive(false);
                    SelectedUnit = null;
                }



            }


        }
        if (DeployTime == true)
        {
            if (Physics.Linecast(DeployingPosition + new Vector3(0, 1, 0), DeployingPosition + new Vector3(0, 0, 0), out DeployingHit))
            {
                DeployingPosSpot = DeployingHit.transform;
                if (!DeployingPosSpot.CompareTag("Units"))
                {
                    return;

                }

            }
            else
            {
                SelectedUnit.transform.SetParent(null);
                Debug.Log("DeployingHit didn't hit a unit.");
                ChooseTileDeploy.SetActive(false);
                SelectedGenUnit.desiredPosition = DeployingPosition;
                SelectedGenUnit.IsOnField = true;
                SelectedGenUnit.IsinDeck = false;
                SelectedGenUnit.IsinHand = false;
                NDeployTile1.onClick.RemoveListener(DeployTile1Check);
                NDeployTile1.onClick.RemoveListener(DeployTile2Check);
                NDeployTile1.onClick.RemoveListener(DeployTile3Check);
                NDeployTile1.onClick.RemoveListener(DeployTile4Check);
                NDeployTile1.onClick.RemoveListener(DeployTile5Check);
                NDeployTile1.onClick.RemoveListener(DeployTile6Check);
                NDeployTile1.onClick.RemoveListener(DeployTile7Check);
                NDeployTile1.onClick.RemoveListener(DeployTile8Check);
                Invoke("SelectedGenUnit.OnDeployChanges", 1);

                if (SelectedGenUnit.DeployinSta1 == true)
                {
                    SelectedGenUnit.IsinStance1 = true;
                    DeployTime = false;

                }
                else
                {
                    SelectedGenUnit.IsinStance1 = false;
                    DeployTime = false;

                }

            }


        }
        else
        {

        }


    }
    void NormalDepFunction()
    {
        SelectedGenUnit = SelectedUnit.GetComponent<GenUnit>();
        InHandCanvas.SetActive(false);
        DeployCanvas.SetActive(true);
        Stance1Image.sprite = card.cardPicture;
        Stance2Image.sprite = card.cardPicture;
        Sta1DepButt.onClick.AddListener(DepSta1OnClick);
        Sta2DepButt.onClick.AddListener(DepSta2OnClick);

    }
    void DepSta1OnClick()
    {

        SelectedGenUnit.DeployinSta1 = true;
        DepTileSelect();


    }
    void DepSta2OnClick()
    {
        SelectedGenUnit.DeployinSta1 = false;
        DepTileSelect();


    }
    void DepTileSelect()
    {
        ChooseTileDeploy.SetActive(true);
        DeployCanvas.SetActive(false);
        Sta1DepButt.onClick.RemoveListener(DepSta1OnClick);
        Sta2DepButt.onClick.RemoveListener(DepSta2OnClick);
        NDeployTile1.onClick.AddListener(DeployTile1Check);
        NDeployTile2.onClick.AddListener(DeployTile2Check);
        NDeployTile3.onClick.AddListener(DeployTile3Check);
        NDeployTile4.onClick.AddListener(DeployTile4Check);
        NDeployTile5.onClick.AddListener(DeployTile5Check);
        NDeployTile6.onClick.AddListener(DeployTile6Check);
        NDeployTile7.onClick.AddListener(DeployTile7Check);
        NDeployTile8.onClick.AddListener(DeployTile8Check);

    }
    void DeployTile1Check()
    {
        DeployingPosSpot = null;
        DeployingPosition = (SelectedGenUnit.teams == 0) ? new Vector3(1, 0, 1) : new Vector3(6, 0, 6);
        DeployTime = true;
        Debug.Log($"Deploy Position has become{DeployingPosition}");

    }
    void DeployTile2Check()
    {
        DeployingPosSpot = null;
        DeployingPosition = (SelectedGenUnit.teams == 0) ? new Vector3(1, 0, 0) : new Vector3(6, 0, 7);
        DeployTime = true;

    }
    void DeployTile3Check()
    {
        DeployingPosSpot = null;
        DeployingPosition = (SelectedGenUnit.teams == 0) ? new Vector3(2, 0, 0) : new Vector3(5, 0, 7);
        DeployTime = true;

    }
    void DeployTile4Check()
    {
        DeployingPosSpot = null;
        DeployingPosition = (SelectedGenUnit.teams == 0) ? new Vector3(3, 0, 0) : new Vector3(4, 0, 7);
        DeployTime = true;

    }
    void DeployTile5Check()
    {
        DeployingPosSpot = null;
        DeployingPosition = (SelectedGenUnit.teams == 0) ? new Vector3(4, 0, 0) : new Vector3(3, 0, 7);
        DeployTime = true;

    }
    void DeployTile6Check()
    {
        DeployingPosSpot = null;
        DeployingPosition = (SelectedGenUnit.teams == 0) ? new Vector3(5, 0, 0) : new Vector3(2, 0, 7);
        DeployTime = true;

    }
    void DeployTile7Check()
    {
        DeployingPosSpot = null;
        DeployingPosition = (SelectedGenUnit.teams == 0) ? new Vector3(6, 0, 0) : new Vector3(1, 0, 7);
        DeployTime = true;

    }
    void DeployTile8Check()
    {
        DeployingPosSpot = null;
        DeployingPosition = (SelectedGenUnit.teams == 0) ? new Vector3(6, 0, 1) : new Vector3(1, 0, 6);
        DeployTime = true;

    }

    void AttackOptionsSetMeth()
    {
        SelectedGenUnit = SelectedUnit.GetComponent<GenUnit>();
        MainOptions.gameObject.SetActive(false);
        MoveOptions.gameObject.SetActive(false);
        SelectedGenUnit.SpecialOptions.gameObject.SetActive(false);
        AttackOptions.gameObject.SetActive(true);
        AttackForwardBut.GetComponent<FollowWorld>().lookAt = SelectedUnit.gameObject;
        AttackForwardBut.GetComponent<FollowWorld>().offset = (SelectedGenUnit.teams == 0) ? new Vector3(0, 0, 0.69f) : new Vector3(0, 0, -0.54f);
        AttackBackBut.GetComponent<FollowWorld>().lookAt = SelectedUnit.gameObject;
        AttackBackBut.GetComponent<FollowWorld>().offset = (SelectedGenUnit.teams == 0) ? new Vector3(0, 0, -0.54f) : new Vector3(0, 0, 0.69f);
        AttackLeftBut.GetComponent<FollowWorld>().lookAt = SelectedUnit.gameObject;
        AttackLeftBut.GetComponent<FollowWorld>().offset = (SelectedGenUnit.teams == 0) ? new Vector3(-1.2f, 0, 0.1f) : new Vector3(1.2f, 0, 0.1f);
        AttackRightBut.GetComponent<FollowWorld>().lookAt = SelectedUnit.gameObject;
        AttackRightBut.GetComponent<FollowWorld>().offset = (SelectedGenUnit.teams == 0) ? new Vector3(1.2f, 0, 0.1f) : new Vector3(-1.2f, 0, 0.1f);
        AttackForwardBut.onClick.AddListener(SelectedGenUnit.AttackForward);
        AttackBackBut.onClick.AddListener(SelectedGenUnit.AttackBack);
        AttackLeftBut.onClick.AddListener(SelectedGenUnit.AttackLeft);
        AttackRightBut.onClick.AddListener(SelectedGenUnit.AttackRight);
       
    }
    void MainOptionsSetMeth()
    {
        SelectedGenUnit = SelectedUnit.GetComponent<GenUnit>();
        MainOptions.gameObject.SetActive(true);
        MoveOptions.gameObject.SetActive(false);
        SelectedGenUnit.SpecialOptions.gameObject.SetActive(true);
        AttackOptions.gameObject.SetActive(false);
        MainAttackBut.GetComponent<FollowWorld>().lookAt = SelectedUnit.gameObject;
        MainAttackBut.GetComponent<FollowWorld>().offset = (SelectedGenUnit.teams == 0) ? new Vector3(0.15f, 0, 0.55f) : new Vector3(-0.15f, 0, -0.55f);
        MainMoveBut.GetComponent<FollowWorld>().lookAt = SelectedUnit.gameObject;
        MainMoveBut.GetComponent<FollowWorld>().offset = (SelectedGenUnit.teams == 0) ? new Vector3(0.15f, 0, 0.25f) : new Vector3(-0.15f, 0, -0.25f);
        SwitchStanceBut.GetComponent<FollowWorld>().lookAt = SelectedUnit.gameObject;
        SwitchStanceBut.GetComponent<FollowWorld>().offset = (SelectedGenUnit.teams == 0) ? new Vector3(0.15f, 0, -0.15f) : new Vector3(-0.15f, 0, 0.15f);
        MainAttackBut.onClick.AddListener(AttackOptionsSetMeth);
        SwitchStanceBut.onClick.AddListener(SelectedGenUnit.SwitchStance);
        MainMoveBut.onClick.AddListener(MoveOptionsSetMeth);
        if (SelectedGenUnit.Isfrozen || SelectedGenUnit.movementlock)
        {
            MainMoveBut.gameObject.SetActive(false);

        }
        else
        {
            MainMoveBut.gameObject.SetActive(true);
                      
        }
        if (SelectedGenUnit.attacklock)
        {
            MainAttackBut.gameObject.SetActive(false);

        }
        else
        {
            MainAttackBut.gameObject.SetActive(true);

        }
        if (SelectedGenUnit.switchlock)
        {
            SwitchStanceBut.gameObject.SetActive(false);

        }
        else
        {
            SwitchStanceBut.gameObject.SetActive(true);

        }


        Debug.Log("MainOptionSetMethod got finished running.");

    }
    void MoveOptionsSetMeth()
    {
        SelectedGenUnit = SelectedUnit.GetComponent<GenUnit>();
        MainOptions.gameObject.SetActive(false);
        MoveOptions.gameObject.SetActive(true);
        SelectedGenUnit.SpecialOptions.gameObject.SetActive(false);
        AttackOptions.gameObject.SetActive(false);
        
        MoveForwardBut.GetComponent<FollowWorld>().lookAt = SelectedUnit.gameObject;
        MoveForwardBut.GetComponent<FollowWorld>().offset = (SelectedGenUnit.teams == 0) ? new Vector3(0, 0, 0.69f) : new Vector3(0, 0, -0.54f);
        MoveBackBut.GetComponent<FollowWorld>().lookAt = SelectedUnit.gameObject;
        MoveBackBut.GetComponent<FollowWorld>().offset = (SelectedGenUnit.teams == 0) ? new Vector3(0, 0, -0.54f) : new Vector3(0, 0, 0.69f);
        MoveLeftBut.GetComponent<FollowWorld>().lookAt = SelectedUnit.gameObject;
        MoveLeftBut.GetComponent<FollowWorld>().offset = (SelectedGenUnit.teams == 0) ? new Vector3(-1.2f, 0, 0.1f) : new Vector3(1.2f, 0, 0.1f);
        MoveRightBut.GetComponent<FollowWorld>().lookAt = SelectedUnit.gameObject;
        MoveRightBut.GetComponent<FollowWorld>().offset = (SelectedGenUnit.teams == 0) ? new Vector3(1.2f, 0, 0.1f) : new Vector3(-1.2f, 0, 0.1f);
        
        MoveForwardBut.onClick.AddListener(SelectedGenUnit.MoveForward);
        MoveBackBut.onClick.AddListener(SelectedGenUnit.MoveBackwards);
        MoveLeftBut.onClick.AddListener(SelectedGenUnit.MoveLeft);
        MoveRightBut.onClick.AddListener(SelectedGenUnit.MoveRight);

    }

}




