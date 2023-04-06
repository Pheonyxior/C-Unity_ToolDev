using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMap : MonoBehaviour
{

    private Tile[,] tiles;

    private SpriteRenderer spriteRenderer;

    private void Awake() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //Debug.Log("bounds : "+spriteRenderer.bounds+ ", spriteborder : "+ spriteRenderer.sprite.border+ ", spritebounds : "+ spriteRenderer.sprite.bounds+ ", spriterect : "+ spriteRenderer.sprite.rect+ ", localbounds :"+ spriteRenderer.localBounds);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        GenerateGridMap((int)spriteRenderer.size.x, (int)spriteRenderer.size.y);
        
        
    }

    public void GenerateGridMap (int xSize, int ySize)
    {
        tiles = new Tile[xSize,ySize];

        for(int y = 0; y < ySize; y++) 
        {
            for(int x = 0; x < xSize; x++) 
            {
                tiles[x,y] = new Tile(x, y);
                Debug.Log("Tile generated : " +x + ", " + y);
            }
        }
    }

    public void OccupyTiles(List<Vector2> coordinates)//, Building building)
    {
        foreach (Vector2 coordinate in coordinates)
        {
            tiles[(int)coordinate.x, (int)coordinate.y].Occupied = true;
            //tiles[(int)coordinate.x, (int)coordinate.y].OccupyingBuilding = building;
        }
    }

    public void DeOccupyTiles(List<Vector2> coordinates)//, Building building)
    {
        foreach (Vector2 coordinate in coordinates)
        {
            tiles[(int)coordinate.x, (int)coordinate.y].Occupied = false;
            //tiles[(int)coordinate.x, (int)coordinate.y].OccupyingBuilding = building;
        }
    }
    

    public bool AreTilesOccupied(List<Vector2> coordinates)
    {
        foreach (Vector2 coordinate in coordinates)
        {
            if (tiles[(int)coordinate.x, (int) coordinate.y].Occupied)
            {
                return true;
            }
        }
        return false;
    }

    public bool AreTilesOccupied(Vector2 coordinate)
    {
        if (tiles[(int)coordinate.x, (int) coordinate.y].Occupied)
        {
            return true;
        }
        
        else return false;
    }

    

}
