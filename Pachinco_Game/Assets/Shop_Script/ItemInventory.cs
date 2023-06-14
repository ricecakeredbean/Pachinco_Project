using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Tem", menuName = "Tem", order = 0)]
public class ItemInventory : ScriptableObject
{
    public List<GameObject> Inventory;
    public int a = 0;
}
