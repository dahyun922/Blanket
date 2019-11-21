using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class RoomTile : Tile
{
    public Tile right;
    public Tile bottom;

    public void MakeRoom(Vector3Int cellPos, Tilemap tilemap)
    {
        int width=0, height=0;

        for(int i=1; i<=10;i++)
        {
            if(tilemap.GetTile(cellPos+new Vector3Int(i,0,0))==right && width==0)
            {
                width=i;
            }
            if(tilemap.GetTile(cellPos+new Vector3Int(0,-i,0))==bottom && height==0)
            {
                height=i;
            }
        }

        new Room(width, height, (Vector2Int)cellPos);

        Debug.Log("width: " + width);
        Debug.Log("height: " + height);
    }
    
#if UNITY_EDITOR
    [MenuItem("Assets/Create/RoomTile")]

    public static void CreateRoomTile()
    {
        var asset=ScriptableObject.CreateInstance<RoomTile>();
        AssetDatabase.CreateAsset(asset, "Assets/New RoomTile.asset");
    }

#endif
}
