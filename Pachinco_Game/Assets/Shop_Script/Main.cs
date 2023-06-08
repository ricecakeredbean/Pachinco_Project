using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[Serializable]
public struct Game_Coin
{
    public int Coin;
    public GameObject[] Item;
    public GameObject[] Position;
    public Text[] Name;
    public Text[] _Price;
    public Dictionary<GameObject, string> Price;
    public Dictionary<string, int> Item_Name;
};
public class Main : MonoBehaviour
{
    public Game_Coin Coin_Use;


    void Start()
    {

        Coin_Use.Price = new Dictionary<GameObject, string>()
        {
            {Coin_Use.Item[0],"아이템1"},
            {Coin_Use.Item[1],"아이템2"},
            {Coin_Use.Item[2],"아이템3"},
            {Coin_Use.Item[3],"아이템4"},
            {Coin_Use.Item[4],"아이템5"},
            {Coin_Use.Item[5],"아이템6"},
            {Coin_Use.Item[6],"아이템7"},
            {Coin_Use.Item[7],"아이템8"}
        };
        Coin_Use.Item_Name = new Dictionary<string, int>()
        {
            {"아이템1",10},
            {"아이템2",20},
            {"아이템3",30},
            {"아이템4",40},
            {"아이템5",50},
            {"아이템6",60},
            {"아이템7",70},
            {"아이템8",80},
        };
        for (int i = 0; i < 3; i++)
        {
            GameObject Object = Coin_Use.Item[UnityEngine.Random.Range(0, 9)];
            Instantiate(Object, Coin_Use.Position[i].transform.position, Quaternion.identity);
            foreach (var a in Coin_Use.Price)
            {
                if (a.Key == Object)
                {
                    Coin_Use.Name[i].text = a.Value;
                    foreach (var b in Coin_Use.Item_Name)
                    {
                        if (a.Value == b.Key)
                        {
                            Coin_Use._Price[i].text = "가격" + b.Value;
                            Coin_Use.Price.Remove(a.Key);
                            Coin_Use.Item_Name.Remove(b.Key);
                        }
                    }
                }
            }
            //foreach(var c in Coin_Use.Item)
            //{
            //    if(c == Object)

            //}Object값에 해당하는 배열을 지워야함
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
