using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Purchase : MonoBehaviour
{
    public Button[] confirmation = new Button[3];
    public GameObject ClickObject;
    public Text ChildText;
    public void Click()
    {
        ClickObject = EventSystem.current.currentSelectedGameObject;
        ChildText = ClickObject.gameObject.transform.GetChild(0).GetComponent<Text>();
        Debug.Log(ChildText.text);
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
            if (a.Value.ToString() == ChildText.text)
            {
                foreach (var b in Main.Instance.Coin_Use.Price)
                {
                    if (a.Key == b.Value)
                    {
                        ClickObject.gameObject.SetActive(false);
                        foreach (var c in Main.Instance.Coin_Use.UseAfter)
                        {
                            if(b.Key.tag == c.tag)
                                c.gameObject.SetActive(false);
                        }
                        foreach(var d in Main.Instance.Coin_Use.Name)
                        {
                            if(b.Value == d.text)
                                d.gameObject.SetActive(false);
                        }

                    }
                }
            }
        }
    }
}
