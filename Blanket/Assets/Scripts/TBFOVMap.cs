using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Tilemaps;
using System;
using System.Linq;


public class TBFOVMap : MonoBehaviour
{
    public Tile black;
    public Tile grey;

    public Tilemap FOVmap;
    
    public int colliderFlag;

    [SerializeField] private int width, height;

    public Vector2Int start{get=>new Vector2Int(-width/2, -height/2);}
    //좌측 하단이 스타트

    private List<TBFOVSource> sources = new List<TBFOVSource>();

    private List<TileDrawInfo> lastDraw = new List<TileDrawInfo>();


    void Awake()
    {
        for(int y=0; y<height; y++)
        {
            for(int x=0; x<width; x++)
            {
                FOVmap.SetTile(new Vector3Int(x,y,0)+(Vector3Int)start, black);
                
            }
        }
    }

    void Start()
    {
        if(black==null || grey==null || FOVmap==null)
            throw new System.Exception("Fov Setting Error");
            //디버그 오류 출력
    }

    void Update()
    {
        List<Vector2Int> circle;
        List<TileDrawInfo> tileDrawInfos = new List<TileDrawInfo>();
        int mask = 1 << colliderFlag;

        foreach(TBFOVSource source in sources)
        {
            circle = GetCircle(source.Radius);
            var tilePos = FOVmap.WorldToCell(source.sourcePos);
            var tileWorldPos = FOVmap.GetCellCenterWorld(tilePos);

           

            circle.RemoveAll(v=>Physics2D.Raycast(tileWorldPos, v, 0.5f*v.magnitude, mask).collider != null);

            //벽
            
            foreach(Vector2Int v in circle)
            {
                tileDrawInfos.Add(new TileDrawInfo((Vector2Int)tilePos+v, 2));
            }
        }

        UpdateTiles(tileDrawInfos);
        lastDraw = tileDrawInfos;

    }

    private void UpdateTiles(List<TileDrawInfo> update)
    {
        lastDraw.Except (update);
        //update 새로 온 애들 제외
        for(int i=0; i<lastDraw.Count; i++)
        {
            lastDraw[i] = new TileDrawInfo(lastDraw[i].pos, 1);
        }

        foreach(TileDrawInfo info in lastDraw)
            DrawTile(info);
        foreach(TileDrawInfo info in update)
            DrawTile(info);
    }

    public static List<Vector2Int> GetCircle(int radius)
    {
        List<Vector2Int> list = new List<Vector2Int>();

        for(int y=-radius; y<=radius; y++)
        {
            for(int x=-radius; x<=radius;x++)
            {
                if(x*x+y*y<=radius*radius)
                    list.Add(new Vector2Int(x,y));
            }
        }

        return list;
    }

    public bool AddSource(TBFOVSource source)
    {
        if(source.Radius<=0)
            return false;
        
        sources.Add(source);

        return true;
        
    }

    private void DrawTile(TileDrawInfo info)
    {
        Tile tile;

        if(info.draw==2)
            tile=null;
        else if(info.draw==1)
            tile=grey;
        else
            tile=black;
        
        FOVmap.SetTile((Vector3Int)(info.pos), tile);
    }

    private struct TileDrawInfo : IEquatable<TileDrawInfo>
    {
        public Vector2Int pos;
        public int draw;
        public int x {get=>pos.x;}
        public int y {get=>pos.y;}

        public TileDrawInfo(Vector2Int pos, int draw)
        {
            this.pos=pos;
            this.draw=draw;

        }

        public bool Equals(TileDrawInfo com)
        {
            return this.pos==com.pos;
        }

        public static bool operator == (TileDrawInfo info1, TileDrawInfo info2)
        {
            return info1.Equals(info2);
        }

        public static bool operator != (TileDrawInfo info1, TileDrawInfo info2)
        {
            return !(info1==info2);
        }
    }
}
