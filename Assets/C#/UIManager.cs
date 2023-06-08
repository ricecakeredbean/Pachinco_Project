using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private RectTransform content;

    private void Start()
    {
        Instance = GetComponent<UIManager>();
    }

    [ContextMenu("ResetContent")]
    public void ResetContent()
    {
        content.position = new Vector2(0, 0);
    }
}
