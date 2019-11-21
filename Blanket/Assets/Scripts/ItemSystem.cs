using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSystem : Touch
{
    public Sprite sprite;

    public int id;


    /*private void Awake()
    {
        GameManager.instance.AddItem(gameObject.name, sprite, id);
        이거 RoomGenerator 에 넣었음 지워도 됨
    }*/


    protected override bool TouchCheck()
    {
        if (!(base.TouchCheck())) return false;

        GameManager.instance.GetItem(gameObject.name, id);
        Destroy(this.gameObject);

        return true;
    }
    
}
