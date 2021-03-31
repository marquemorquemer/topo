using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Romper : MonoBehaviour
{
    private Vector2 mousePos;
    public Tile replace;
    public Tilemap tm;
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
            if(tm.GetTile(tilePos)!=null && tm.GetTile(tilePos).name == "prd" && count < max)
            {
                tm.SetTile(tilePos, replace);
                count++;
            } 
            
        }
    }
}
