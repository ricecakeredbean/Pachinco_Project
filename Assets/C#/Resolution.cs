using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution : MonoBehaviour
{
    private int DefaultWidth = 1920;
    private int DefaultHeight = 1080;

    private void Start()
    {
        ResolutionView();
    }

    [ContextMenu("ResolutionView")]
    public void ResolutionView()
    {
        int deviceWidth = Screen.width;
        int deviceHeight = Screen.height;

        Screen.SetResolution(DefaultWidth, (int)(((float)deviceHeight / deviceWidth) * DefaultWidth), true);

        if ((float)DefaultWidth / DefaultHeight < (float)deviceWidth / deviceHeight)
        {
            float newWidth = ((float)DefaultWidth / DefaultHeight) / ((float)deviceHeight / deviceWidth);

            Camera.main.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f);
        }
        else
        {
            float newHeight = ((float)deviceWidth / deviceHeight) / ((float)DefaultWidth / DefaultHeight);

            Camera.main.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight);
        }
    }
}
