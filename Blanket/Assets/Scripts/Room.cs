using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Room
{
    public readonly int width;
    public readonly int height;
    public readonly Vector2Int topLeft;

    public static List<Room> rooms=new List<Room>();
    private static int ids=0;

    public Room(int width, int height, Vector2Int topLeft)
    {
        this.width=width;
        this.height=height;
        this.topLeft=topLeft;

        rooms.Add(this);
    }

    public static void RandomGenerate(Touch item, Tilemap tilemap)
    {   
        int roomNum=Random.Range(0,rooms.Count);
        Room room=rooms[roomNum];
        Vector3Int topLeft;
        topLeft = (Vector3Int)room.topLeft;

        Vector3 tL = tilemap.GetCellCenterWorld(topLeft);


        float x=Random.Range(tL.x, tL.x+room.width);
        float y=Random.Range(tL.y-room.height, tL.y);


        GameObject.Instantiate(item.gameObject,new Vector3(x,y,0), Quaternion.identity);
    }
    
}
