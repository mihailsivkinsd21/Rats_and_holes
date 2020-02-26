using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block 
{

    public int x { get; private set; }
    public int y { get; private set; }

    private Grid<Block> grid;

    private Hole currentHole;

    private PlaceableObject pObject;

    public Block(Grid<Block> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
    }

    public Hole GetHole()
    {
        return currentHole;
    }

    public void SetHole(Hole hole)
    {
        currentHole = hole;
    }

    public PlaceableObject GetPlaceableObject()
    {
        return pObject;
    }
    public void SetPlaceableObject(PlaceableObject newObject)
    {
        pObject = newObject;
    }

}