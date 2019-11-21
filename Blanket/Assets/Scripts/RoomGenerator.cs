using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class RoomGenerator : MonoBehaviour
{
    Tilemap tilemap;

    

    public int halfWidth, halfHeight;

    public RoomTile roomTile;

    public ItemSystem[] items;
    public MonsterTouch[] monsters;

    void Awake()
    {
        tilemap=GetComponent<Tilemap>();
    }

    void Start()
    {
        for(int y= -halfHeight; y<=halfHeight; y++)
        {
            for(int x=-halfHeight; x<=halfHeight;x++)
            {
                Vector3Int pos = new Vector3Int(x,y,0);
                var tile = tilemap.GetTile(pos) as RoomTile;
                if(tile != null && tile == roomTile)
                    tile.MakeRoom(pos, tilemap);
            }
        }

        for(int i=0;i<items.Length;i++)
        {
            items[i].id=i;
            Room.RandomGenerate(items[i], tilemap);
            GameManager.instance.AddItem(items[i].name, items[i].sprite, items[i].id);
        }
    }
    



}
