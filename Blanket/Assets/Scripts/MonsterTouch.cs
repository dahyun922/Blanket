using UnityEngine;
using System.Collections;

public class MonsterTouch : Touch
{

    protected override bool TouchCheck()
    {
        if (!(base.TouchCheck())) return false;

        GameManager.instance.player.Hit();

        Destroy(this.gameObject);


        return true;
    }
}
