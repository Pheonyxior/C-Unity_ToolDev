using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GridMapUtilities
{
    public static Vector2 WorldToGridCoordinates(Vector3 worldCoordinates)
    {
        Vector2 gridCoordinates = new Vector2((int)worldCoordinates.x, (int) worldCoordinates.y);

        return gridCoordinates;
    }

    public static Vector2 GridToRectCoordinates(Vector2 gridCoordinates)
    {
        Vector2 rectCoordinates = new Vector2(gridCoordinates.x * 100, gridCoordinates.y * 100);

        return rectCoordinates;
    }

    
    public static bool IsOutOfBounds(Vector2 worldPos)
    {
        bool outOfX = worldPos.x < 0 || worldPos.x >= 16; // est true si x<0 ou x>16 
        bool outOfY = worldPos.y < 0 || worldPos.y >= 10; // est true si y<0 ou y>16 
        
        
        return outOfX || outOfY; // renvoie true si outOfX est true, ou si outOfY est true
    }

    public static bool IsOutOfBounds(List<Vector2> worldPos)
    {
        foreach (Vector2 v2 in worldPos)
        {
            if(IsOutOfBounds(v2))
            {
                return true;
            }
        }

        return false;
    }
}
