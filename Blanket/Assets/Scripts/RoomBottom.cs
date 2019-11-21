using UnityEngine;
using UnityEngine.Tilemaps;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class RoomBottom: Tile
{
    #if UNITY_EDITOR
    [MenuItem("Assets/Create/RoomBottom")]
    public static void CreateRoomBottom()
    {
        var asset=ScriptableObject.CreateInstance<RoomBottom>();
        AssetDatabase.CreateAsset(asset,"Assets/New RoomBottom.asset");
    }
    #endif
}