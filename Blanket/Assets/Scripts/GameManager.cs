using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{

    string sceneNum;

    public List<string> getItems = new List<string>();
    public List<string> itemIds = new List<string>();
    public Image[] uiImage = new Image[3];
    public AudioSource getAudio;
    public AudioSource hitAudio;
    public Player player;

 
    void Start()
    {
        sceneNum=SceneManager.GetActiveScene().name;
    }

    public void GetItem(string itemName, int id)
    {
        getItems.Add(itemName);
        uiImage[id].color = Color.white;
        getAudio.Play();

        //for(int i=0;i<ItemIds.Lenght;i++) 이거 말고
        //getItems[ItemIds.Length-1]가 존재하면

    }

    public void AddItem(string ItemName, Sprite sprite, int id)
    {
        itemIds.Add(ItemName);
        uiImage[id].sprite = sprite;
        uiImage[id].color = Color.black;
       
    }


}
