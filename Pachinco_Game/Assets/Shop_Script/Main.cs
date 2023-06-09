using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
    public Text Money;
    public List<GameObject> UseAfter;
};
public class Main : MonoBehaviour
{
    public static Main Instance;
    public Game_Coin Coin_Use;
    GameObject Object;
    //Nullable<GameObject> Object
    string end;

    private void Awake()
    {
        Instance = this;
    }
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
        Item_Instantiate();
    }

    public void Item_Instantiate()
    {
        GameObject ClickObject = EventSystem.current.currentSelectedGameObject;
        if(ClickObject != null)
            //누를때마다 10코인차감 10코인 없으면 안돌아가게 
        for (int i = 0; i < 3; i++)
        {

            //do
            //{
            Object = Coin_Use.Item[UnityEngine.Random.Range(0, 8)];
            foreach (var a in Coin_Use.UseAfter)
            {
                //if(Object == a)
                while (Object == a)
                {
                    Object = Coin_Use.Item[UnityEngine.Random.Range(0, 8)];
                }

            }
            //} while ();
            //{
            //    Object = Coin_Use.Item[UnityEngine.Random.Range(0, 8)];
            //    //Debug.Log(Object);
            //}
            //while (Object == null)
            //{
            //    Object = Coin_Use.Item[UnityEngine.Random.Range(0, 8)];
            //    //Debug.Log(Object);
            //}
            if (Object != null)
            {
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
                                Coin_Use._Price[i].text = b.Value.ToString();
                                //Coin_Use.Price.Remove(a.Key);
                                end = "end";
                                break;
                            }
                        }
                    }
                    if (end == "end")
                    {
                        end = "";
                        break;
                    }
                }
                Coin_Use.UseAfter.Add(Object);
                //for (int l = 0; l < Coin_Use.Item.Length; l++)
                //{
                //    if (Object == Coin_Use.Item[l])
                //    {
                //        Array.Clear(Coin_Use.Item, l, 1);
                //    }
                //}
            }
        }
    }
    void Update()
    {
        Coin_Use.Money.text = "남은돈:" + Coin_Use.Coin;
    }
}
