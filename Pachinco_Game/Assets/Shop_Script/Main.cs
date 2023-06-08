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
            {Coin_Use.Item[0],"������1"},
            {Coin_Use.Item[1],"������2"},
            {Coin_Use.Item[2],"������3"},
            {Coin_Use.Item[3],"������4"},
            {Coin_Use.Item[4],"������5"},
            {Coin_Use.Item[5],"������6"},
            {Coin_Use.Item[6],"������7"},
            {Coin_Use.Item[7],"������8"}
        };
        Coin_Use.Item_Name = new Dictionary<string, int>()
        {
            {"������1",10},
            {"������2",20},
            {"������3",30},
            {"������4",40},
            {"������5",50},
            {"������6",60},
            {"������7",70},
            {"������8",80},
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
                            Coin_Use._Price[i].text = "����" + b.Value;
                            Coin_Use.Price.Remove(a.Key);
                            Coin_Use.Item_Name.Remove(b.Key);
                        }
                    }
                }
            }
            //foreach(var c in Coin_Use.Item)
            //{
            //    if(c == Object)

            //}Object���� �ش��ϴ� �迭�� ��������
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
