using UnityEngine;
using UnityEngine.Tilemaps;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class RoomRight: Tile
{
    #if UNITY_EDITOR
    [MenuItem("Assets/Create/RoomRight")]
    public static void CreateRoomRight()
    {
        var asset=ScriptableObject.CreateInstance<RoomRight>();
        AssetDatabase.CreateAsset(asset,"Assets/New RoomRight.asset");
    }
    #endif
}