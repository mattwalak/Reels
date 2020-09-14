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
            case 0:
                GeoInit_0(colors, data);
                break;
            case 1:
                GeoInit_1(colors, data);
                break;
            case 2:
                GeoInit_2(colors, data);
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

    // 1D perlin noise
    private void GeoInit_0(List<Color> colors, List<float> data)
    {
        GameObject bg = Instantiate(StaticData.square, transform);
        bg.transform.localPosition = Vector2.zero;
        bg.transform.localScale = new Vector2(2.0f * StaticData.cam_width, 2.0f * StaticData.cam_height);
        Renderer render_bg = bg.GetComponent<Renderer>();
        render_bg.material.color = colors[0];
        render_bg.sortingLayerName = "BG";

        float stride_y = StaticData.cam_height / 2.0f;
        for (int i = 0; i < 4; i++)
        {
            GameObject bar_left = Instantiate(StaticData.square, transform);
            float width_left = data[i * 2];
            bar_left.transform.localScale = new Vector2(width_left, 1.0f);
            float x_left = -StaticData.cam_width + width_left / 2.0f;
            float y_left = i * stride_y;
            bar_left.transform.localPosition = new Vector2(x_left, y_left);
            Renderer render_left = bar_left.GetComponent<Renderer>();
            render_left.material.color = colors[1];
            render_left.sortingLayerName = "Midground_1";

            GameObject bar_right = Instantiate(StaticData.square, transform);
            float width_right = data[i * 2 + 1];
            bar_right.transform.localScale = new Vector2(width_right, 1.0f);
            float x_right = StaticData.cam_width - width_right / 2.0f;
            float y_right = i * stride_y;
            bar_right.transform.localPosition = new Vector2(x_right, y_right);
            Renderer render_right = bar_right.GetComponent<Renderer>();
            render_right.material.color = colors[2];
            render_right.sortingLayerName = "Midground_1";
        }
    }

    // Random squares
    private void GeoInit_1(List<Color> colors, List<float> data)
    {
        GameObject bg = Instantiate(StaticData.square, transform);
        bg.transform.localPosition = Vector2.zero;
        bg.transform.localScale = new Vector2(2.0f * StaticData.cam_width, 2.0f * StaticData.cam_height);
        Renderer render_bg = bg.GetComponent<Renderer>();
        render_bg.material.color = colors[0];
        render_bg.sortingLayerName = "BG";

        int num_squares = (int) data[0];
        for(int i = 0; i < num_squares; i++)
        {
            float x = data[1 + i * 4 + 0];
            float y = data[1 + i * 4 + 1];
            float x_scale = data[1 + i * 4 + 2];
            float y_scale = data[1 + i * 4 + 3];

            /*if ((y + y_scale / 2.0f) > StaticData.cam_height)
                y_scale = (StaticData.cam_height - y) * 2.0f; // TOP BOUND
            if ((y - y_scale / 2.0f) < -StaticData.cam_height)
                y_scale = (StaticData.cam_height + y) * 2.0f; // BOTTOM BOUND*/
            if ((x + x_scale / 2.0f) > StaticData.cam_width)
                x_scale = (StaticData.cam_width - x) * 2.0f; // RIGHT BOUND
            if ((x - x_scale / 2.0f) < -StaticData.cam_width)
                x_scale = (StaticData.cam_width + x) * 2.0f; // LEFT BOUND

            GameObject square = Instantiate(StaticData.blendSquare, transform);
            square.transform.localPosition = new Vector2(x, y);
            square.transform.localScale = new Vector2(x_scale, y_scale);
            Renderer render = square.GetComponent<Renderer>();
            render.material.color = colors[1];
            render.sortingLayerName = "Midground_1";
        }
    }

    // Random circles
    private void GeoInit_2(List<Color> colors, List<float> data)
    {
        GameObject bg = Instantiate(StaticData.square, transform);
        bg.transform.localPosition = Vector2.zero;
        bg.transform.localScale = new Vector2(2.0f * StaticData.cam_width, 2.0f * StaticData.cam_height);
        Renderer render_bg = bg.GetComponent<Renderer>();
        render_bg.material.color = colors[0];
        render_bg.sortingLayerName = "BG";

        int num_circles = (int)data[0];
        for (int i = 0; i < num_circles; i++)
        {
            float x = data[1 + i * 3 + 0];
            float y = data[1 + i * 3 + 1];
            // float scale = data[1 + i * 3 + 2];

            /*if ((y + y_scale / 2.0f) > StaticData.cam_height)
                y_scale = (StaticData.cam_height - y) * 2.0f; // TOP BOUND
            if ((y - y_scale / 2.0f) < -StaticData.cam_height)
                y_scale = (StaticData.cam_height + y) * 2.0f; // BOTTOM BOUND
            if ((x + x_scale / 2.0f) > StaticData.cam_width)
                x_scale = (StaticData.cam_width - x) * 2.0f; // RIGHT BOUND
            if ((x - x_scale / 2.0f) < -StaticData.cam_width)
                x_scale = (StaticData.cam_width + x) * 2.0f; // LEFT BOUND*/

            GameObject circle = Instantiate(StaticData.blendCircle, transform);
            circle.transform.localPosition = new Vector2(x, y);
            circle.transform.localScale = new Vector2(8.0f, 8.0f);
            Renderer render = circle.GetComponent<Renderer>();
            render.material.color = colors[1];
            render.sortingLayerName = "Midground_1";
        }
    }

}
