using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Romper : MonoBehaviour
{
    private Vector2 mousePos;
    public Tile replace;
    public GameObject topo;
    public Tilemap tm;
    public int max;
    private int count;
    private GameObject prefabTopo;

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
            if(tm.GetTile(tilePos)!=null && tm.GetTile(tilePos).name.Substring(0,5) == "tierra" && count < max)
            {
                prefabTopo = Instantiate(topo, new Vector3 (tilePos.x + 1, tilePos.y + 0.5f, -1), Quaternion.identity);
                Destroy(prefabTopo, 1);
                tm.SetTile(tilePos, replace);
                count++;
            }
            else if (count >= max)
            {
            }
            
        }
    }
}
