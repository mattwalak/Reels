using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page : MonoBehaviour
{
    List<GameObject> geometry;

    public void Init(int type, List<Color> colors, List<float> data)
    {
        switch (type)
        {
            case 1:
                GeoInit_1(colors, data);
                break;
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////// PAGE INITIALIZERS //////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////

    private void GeoInit_1(List<Color> colors, List<float> data)
    {
        float min_x = -StaticData.cam_width + 0.5f;
        float min_y = 0.0f;
        float stride_y = StaticData.cam_height / 2.0f;
        for (int i = 0; i < 4; i++)
        {
            GameObject bar = Instantiate(StaticData.square, transform);
            bar.transform.localScale = new Vector2(data[i], 1.0f);
            float x = min_x;
            float y = min_y + i * stride_y;
            bar.transform.localPosition = new Vector2(x, y);
        }
    }

}
