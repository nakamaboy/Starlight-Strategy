using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameBoard : MonoBehaviour
{
    [Header("Art stuff")]
    [SerializeField] private Material tileMaterial;
    [SerializeField] private float tileSize = 0.9f;
    [SerializeField] private float yOffset = 0.1f;
    [SerializeField] private Vector3 boardCenter = Vector3.zero;

    [Header("Prefabs & Materials")]
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private Material[] teamMaterials;
    public Material highlightMaterial;
    public Material selectionMaterial;

    private Material originalMaterial;
    private GameObject mainmenu;
    private Transform highlight;
    private Transform selection;
    private RaycastHit raycastHit;
    private RaycastHit info;
    private GenUnit unit;

    //LOGIC
    public GenUnit Rubes; 
    public GenUnit[,] unitPositions; // In tutorial this is: ChessPiece[,] chessPieces;
    private const int TILE_COUNT_X = 8;
    private const int TILE_COUNT_Y = 8;
    public GameObject[,] tiles;
    private Camera currentCamera;
    private Vector2Int currentHover;
    private Vector3 bounds;
    public GenUnit SelectedUnit; // Was currentlyDragging in tutorial
   
    private void Awake()
    {
        GenerateAllTiles(tileSize, TILE_COUNT_X, TILE_COUNT_Y);

        DeployAtSpecificTile();
        PositionAllPieces();

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && highlight.CompareTag("Selectable"))
        {

            highlight.GetComponent<MeshRenderer>().material = originalMaterial;
            highlight = null;
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
        if (!EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButtonDown(0))
        {

            if (Physics.Raycast(ray, out info, 100, LayerMask.GetMask("Tile", "Hover", "Selectable")))
            {

                Vector2Int hitPosition = LookupTileIndex(info.transform.gameObject);

                highlight = info.transform;
                if (highlight.CompareTag("Background"))
                    Debug.Log("background got hit");
                if (highlight != null && highlight.CompareTag("Selectable"))
                {

                    if (info.transform != highlight.CompareTag("Background"))
                        highlight.GetComponent<MeshRenderer>().material = originalMaterial;
                    
                    Transform mainmenu = highlight.Find("Main options");
                    Transform movemenu = highlight.Find("Movement options");
                    mainmenu.gameObject.SetActive(false);
                    movemenu.gameObject.SetActive(false);
                    highlight = null;


                }

                highlight = info.transform;
                if (highlight.CompareTag("Selectable") && Input.GetMouseButtonDown(0))
                {
                    Debug.Log("Game Object is selected");
                    Transform mainmenu = highlight.Find("Main options");
                    mainmenu.gameObject.SetActive(true);
                    Debug.Log("Game Object is attempting to change materials");
                    originalMaterial = highlight.GetComponent<MeshRenderer>().material;
                    highlight.GetComponent<MeshRenderer>().material = highlightMaterial;
                    
                    
                    //Prevous position from tutorial that used to remember the previous position to fall back on if move is invalid. 
                    //Vector2Int previousPosition = new Vector2Int(SelectedUnit.currentX, SelectedUnit.currentY);
                    
                    //Variable to make the piece follow your mouse and move from tutorial 
                    //SelectedUnit = unitPositions[hitPosition.x, hitPosition.y];
                    //bool validMove = MoveTo(SelectedUnit, hitPosition.x, hitPosition.y);

                }
                if (currentHover == -Vector2Int.one)
                {
                    currentHover = hitPosition;
                    tiles[hitPosition.x, hitPosition.y].layer = LayerMask.NameToLayer("Hover");   
                }
                

                if (highlight.GetComponent<MeshRenderer>().material != highlightMaterial)
                {


                }

                // Debug.Log("Selected Unit is ")

                else
                {
                    highlight = null;
                }

            }
        }   
        else
        {
            
        }
    }

 //   public void MoveForward(ref GenUnit[,] unitPositions, int TILE_COUNT_X, int TILE_COUNT_Y)
 //   {
 //       unitPositions.position = new Vector2(TILE_COUNT_X, TILE_COUNT_Y + 1)
 //   }

    //Generating the board
    private void GenerateAllTiles(float tileSize, int tileCountX, int tileCountY)
    {
        yOffset += transform.position.y;
        bounds = new Vector3((tileCountX / 2) * tileSize, 0, (tileCountX / 2) * tileSize) + boardCenter;

        tiles = new GameObject[tileCountX, tileCountY];
        for (int x = 0; x < tileCountX; x++)
            for (int y = 0; y < tileCountY; y++)
                tiles[x, y] = GenerateSingleTiles(tileSize, x, y);

    }

    private GameObject GenerateSingleTiles(float tileSize, int x, int y)
    {
        GameObject tileObject = new GameObject(string.Format("X:{0}, Y:{1},", x, y));
        tileObject.transform.parent = transform;

        Mesh mesh = new Mesh();
        tileObject.AddComponent<MeshFilter>().mesh = mesh;
        tileObject.AddComponent<MeshRenderer>().material = tileMaterial;

        Vector3[] vertices = new Vector3[4];

        //How the tutorial did this section.
        vertices[0] = new Vector3(x * tileSize, yOffset, y * tileSize) - bounds;
        vertices[1] = new Vector3(x * tileSize, yOffset, (y + 1) * tileSize) - bounds;
        vertices[2] = new Vector3((x + 1) * tileSize, yOffset, y * tileSize) - bounds;
        vertices[3] = new Vector3((x + 1) * tileSize, yOffset, (y + 1) * tileSize) - bounds;

        //vertices[0] = new Vector3(x * tileSize, yOffset, y * tileSize);
        //vertices[1] = new Vector3(x * tileSize, yOffset, (y + 1) * tileSize);
        //vertices[2] = new Vector3((x + 1) * tileSize, yOffset, y * tileSize);
        //vertices[3] = new Vector3((x + 1) * tileSize, yOffset, (y + 1) * tileSize);



        int[] tris = new int[] { 0, 1, 2, 1, 3, 2 };

        mesh.vertices = vertices;
        mesh.triangles = tris;
        mesh.RecalculateNormals();

        tileObject.layer = LayerMask.NameToLayer("Tile");
        //tileObject.layer = LayerMask.NameToLayer("Hover");
        tileObject.AddComponent<BoxCollider>();

        return tileObject;
    }

    private GenUnit DeploySingleUnit(UnitListNames names, int team)
    {
        GenUnit gu = Instantiate(prefabs[(int)names], transform).GetComponent<GenUnit>();

        //gu = cp in tutorial 

        gu.names = names;
        gu.team = team;

        //Adds material to the card to signify which team it is on.   
        //gu.GetComponent<MeshRenderer>().material = teamMaterials[team];

        return gu;
   
    }

    public void DeployAtSpecificTile()
    {

        unitPositions = new GenUnit[TILE_COUNT_X , TILE_COUNT_Y]; 

        //player 1 = whiteteam, player2 = blackteam in tutorial. 

        int player1 = 0, player2 = 1;

        unitPositions[0, 0] = DeploySingleUnit(UnitListNames.RubyRose, player1);     

    }

    private void PositionAllPieces()
    {
        for (int x = 0; x < TILE_COUNT_X; x++)
            for (int y = 0; y < TILE_COUNT_Y; y++)
                if (unitPositions[x, y] != null)
                    PositionSinglePiece(x, y, true);
    }

    private void PositionSinglePiece(int x, int y, bool force = false)
    {
        unitPositions[x, y].currentX = x;
        unitPositions[x, y].currentY = y;
        unitPositions[x, y].transform.position = GetTileCenter(x, y);

    }
    private Vector3 GetTileCenter(int x, int y)
    {
        return new Vector3(x * tileSize, yOffset, y * tileSize) - bounds + new Vector3(tileSize / 4, 0, tileSize);  
    }

    //Operations
    private Vector2Int LookupTileIndex(GameObject hitInfo)
    {
        for (int x = 0; x < TILE_COUNT_X; x++)
            for (int y = 0; y < TILE_COUNT_Y; y++)
                if (tiles[x, y] == hitInfo)
                    return new Vector2Int(x, y);

        return -Vector2Int.one; //Invalid

    }

    public void MoveforwardPart2()
    {
        MoveForward(unit, 0, 0, 0);
        PositionAllPieces();
    }
    public void MoveForward(GenUnit unit , int x, int y, int team)
    {
        unitPositions = new GenUnit[TILE_COUNT_X, TILE_COUNT_Y];
        Debug.Log($"highlight: {highlight}"); 
        //Debug.Log($"Ruby Rose: {RubyRose}, Unit: {unit}");
        highlight.position = unit.transform.position;
        //Vector2Int nowPosition = new Vector2Int(unit.currentX, unit.currentY);
        //unitPositions[x, y] = unit;
        //RubyRose.position = Vector3.MoveTowards(unitPositions[x, y].transform.position);
        //chec
        Debug.Log("Highlight has become equal to unitPositions");
        int direction = (team == 0) ? 1 : -1;

        if (unitPositions[x, y + direction] == null)
            unit.desiredPosition = unitPositions[x, y + direction].transform.position;
            //unitPositions[nowPosition.x, nowPosition.y] = null;

        //Vector2Int previousPosition = new Vector2Int(gu.currentX, gu.currentY);

        //SelectedUnit = unitPositions[x , y + 1];
        //unitPositions[previousPosition.x, previousPosition.y] = null;
    }

        // Method from tutorial 
    private bool MoveTo(GenUnit unit, int x, int y)
    {
        Vector2Int previousPosition = new Vector2Int(unit.currentX, unit.currentY);

        unitPositions[x, y] = unit;
        unitPositions[previousPosition.x, previousPosition.y] = null;

        PositionSinglePiece(x, y);

        return true;

    }

    
    
}







