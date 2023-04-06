using System.Collections;
using System.Collections.Generic;
//using UnityEngine;

public class Tile
{
    public Tile(int newXPos, int newYPos)
    {
        xPos = newXPos;
        yPos = newYPos;
    }
    private int xPos;
    public int XPos{get;}

    private int yPos;
    public int YPos{get;}

    private bool occupied;
    public bool Occupied{get; set;}

    private Building occupyingBuilding;
    public Building OccupyingBuilding{get {return occupyingBuilding;} set{occupyingBuilding = value;}}

}
