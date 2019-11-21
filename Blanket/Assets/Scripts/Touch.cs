using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    public float distance=0.50f;




    void Update()
    {
        TouchCheck();
    }

    protected virtual bool TouchCheck()
    {
        return distance>Vector2.Distance(GameManager.instance.player.transform.position , this.transform.position);
    }

}
