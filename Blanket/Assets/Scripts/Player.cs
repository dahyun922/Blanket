using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    int life=3;
    public Image[] heartImage = new Image[3];

    // Use this for initialization


    public void Hit()
    {
        life = life - 1;
        heartImage[life].color = Color.black;
        GameObject.Find("GameManager").GetComponent<GameManager>().hitAudio.Play();
        if(life==0)
        {
            Lose();
        }
    }

    void Lose()
    {
        Debug.Log("게임 끝");
    }
}
