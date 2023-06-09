using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public int Count = 3;
    public Text GameObjectText;
    public static Item Instance;
    void Awake()
    {
        Instance =this;
    }


}
