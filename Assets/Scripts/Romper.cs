using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Romper : MonoBehaviour
{
    private Vector2 mousePos;
    public Tile replace;
    public Tile topoTile;
    public Tilemap tm;
    public Tilemap topoTm;
    public int max;
    private int count;

    public void Start()
    {
        count = 0;
    }

    public void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0))
        {
            var grid = tm.GetComponentInParent<Grid>();
            var tilePos = grid.WorldToCell(mousePos);
            var topoPos = tilePos;
            topoPos.x--;
            if(tm.GetTile(tilePos)!=null && tm.GetTile(tilePos).name == "prd" && count < max)
            {
                topoTm.ClearAllTiles();
                tm.SetTile(tilePos, replace);
                topoTm.SetTile(topoPos, topoTile);
                count++;
            }
            else if (count >= max)
            {
                topoTm.ClearAllTiles();
            }
            
        }
    }
}
