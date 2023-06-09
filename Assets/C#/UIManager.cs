using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private RectTransform content;

    private void Awake()
    {
        Instance = GetComponent<UIManager>();
    }

    [ContextMenu("ResetContent")]
    public void ResetContent()
    {
        content.position = Vector2.zero;
    }
}
