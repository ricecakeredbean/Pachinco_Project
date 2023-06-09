using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Purchase : MonoBehaviour
{
    public Button[] confirmation = new Button[3];
    public void Click()
    {
        GameObject ClickObject = EventSystem.current.currentSelectedGameObject;
        Text ChildText = ClickObject.gameObject.transform.GetChild(0).GetComponent<Text>();
        foreach (var a in Main.Instance.Coin_Use.Item_Name)
        {
            if (a.Value.ToString() == ChildText.text)
            {


                if (Main.Instance.Coin_Use.Coin >= a.Value)
                {
                    ClickObject.GetComponent<Item>().Count -= 1;
                    Main.Instance.Coin_Use.Coin -= a.Value;
                }
                if (ClickObject.GetComponent<Item>().Count == 0)
                    End();

            }
        }
    }
    public void End()
    {


#if UNITY_EDITOR
        Debug.Log("Dd");
#endif
        foreach (var a in Main.Instance.Coin_Use.Item_Name)
        {
            if (a.Value.ToString() == Item.Instance.GameObjectText.text)
            {
                foreach (var b in Main.Instance.Coin_Use.Price)
                {
                    if (a.Key == b.Value)
                    {
#if UNITY_EDITOR
                        Debug.Log("Dd");
                        Debug.Log(b.Key.gameObject.name);
#endif
                    }
                }
            }
        }
    }
}
