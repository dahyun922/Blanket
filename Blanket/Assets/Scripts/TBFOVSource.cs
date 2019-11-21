using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TBFOVSource : MonoBehaviour
{
    //광원
    [SerializeField] private int radius = 2;
    public int Radius {get=>radius;}
    //radius 를 넘겨주는 역할
    private Collider2D col;
    public TBFOVMap map;
    public Vector3 sourcePos {get=>this.transform.position + (Vector3)col.offset;}
    //콜라이더의 위치벡터를 의미 플레이어와 콜라이더의 벡터가 같으면 노상관

    void Awake()
    {
        col=GetComponent<Collider2D>();
        map.AddSource(this);
    }
}
