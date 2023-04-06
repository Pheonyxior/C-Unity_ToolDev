using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cursor : MonoBehaviour
{
    Camera cam;
    GameObject cursorOverlay;

    bool isSelectingTile;

    bool isPlacingBuilding;
    bool isDestroyingBuilding;

    Building selectedBuilding;

    [SerializeField] GridMap gridMap;
    //[SerializeField] BuildingManager buildingManager;

    bool hasProductionStarted;

    private void Awake()
    {
        cam = Camera.main;
        
    }
    
    private void Start() 
    {
        
    }

    private void Update()
    {
        //Debug.Log(cam.ScreenToWorldPoint(Input.mousePosition));
        //Debug.Log(GridMapUtilities.WorldToGridCoordinates(cam.ScreenToWorldPoint(Input.mousePosition)));

        if(isSelectingTile)
        {
            UpdateSelectedTile();
        }
        
    }

    public void OnClickBuildingSlot(Building building)
    {
        selectedBuilding = building;
        DisplaySelectedBuilding();
        isSelectingTile = true;
        isPlacingBuilding = true;
        // Debug.Log(building);

        
    }

    public void OnClickDestroy () 
    {
        
    }

    private void DisplaySelectedBuilding()
    {
        cursorOverlay = Instantiate(selectedBuilding.ConstructionOverlay);
        
        cursorOverlay.SetActive(true);
    }

    public void OnCancelSelectedBuilding() 
    {
        isSelectingTile = false;
        isPlacingBuilding = false;
        
        if(cursorOverlay) cursorOverlay.SetActive(false);
        
        selectedBuilding = null;
    }

    private void UpdateSelectedTile()
    {
        Vector2 cursorCoordinates = cam.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(cursorCoordinates);
        if(isPlacingBuilding)
        {
            if(!GridMapUtilities.IsOutOfBounds(GetConstructionTilesGridPos(cursorCoordinates)))
            {
                if(!gridMap.AreTilesOccupied(GetConstructionTilesGridPos(cursorCoordinates)))
                {
                    Vector2 gridCoordinates = GridMapUtilities.WorldToGridCoordinates(cursorCoordinates);
                    //this.transform.position = gridCoordinates;
                    cursorOverlay.transform.position = gridCoordinates;

                    UpdatePlaceBuildingInput(cursorCoordinates);
                }
            }
        }
        
    }

    private void UpdatePlaceBuildingInput(Vector2 cursorCoodinates)
    {
        if(Input.GetMouseButtonDown(0))
        {
            PlaceBuilding(cursorCoodinates);
        }
    }


    private void PlaceBuilding(Vector2 cursorCoodinates)
    {
        gridMap.OccupyTiles(GetConstructionTilesGridPos(cursorCoodinates));
        Building placedBuilding = Instantiate(selectedBuilding, cursorOverlay.transform.position, Quaternion.identity);
        placedBuilding.BuildingOccupation = GetConstructionTilesGridPos(cursorCoodinates);

        OnCancelSelectedBuilding();

        // if(!hasProductionStarted)
        // {
        //     buildingManager.StartProductionCoroutine();
        //     hasProductionStarted = true;
        // }
    }

    private List<Vector2> GetConstructionTilesGridPos(Vector2 gridPos)
    {
        List<Vector2> constructionTilesGridPos = new List<Vector2>();

        foreach(Vector2 tile in selectedBuilding.BuildingDimensions)
        {
            Vector2 newTile = new Vector2(tile.x + gridPos.x, tile.y + gridPos.y) ;
            constructionTilesGridPos.Add(newTile);
        }

        return constructionTilesGridPos;
    }
    
}
