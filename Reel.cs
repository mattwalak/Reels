using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reel : MonoBehaviour
{
    List<Page> pages;
    int height; // In factors of cam_height
    float scroll_y; // In factors of cam_height

    List<Color> colors;

    /*
     * 0 = 1D perlin noise bars
     * 1 = random squares
     * 2 = random circles
     * 
     */
    public void Init(int type, int height_in)
    {
        colors = new List<Color>() { StaticData.RandomColor(), StaticData.RandomColor(), StaticData.RandomColor() };
        height = height_in;
        transform.position = new Vector2(0.0f, 0.0f);

        pages = new List<Page>();
        switch (type)
        {
            case 0:
                PageInit_0();
                break;
            case 1:
                PageInit_1();
                break;
            case 2:
                PageInit_2();
                break;
        }

        // Add cap / tail
        for(int i = 0; i < StaticData.MAX_REELS; i++)
        {
            GameObject cap = Instantiate(pages[i].gameObject);
            cap.transform.SetParent(transform);
            cap.transform.localPosition = new Vector2(0.0f, StaticData.cam_height*2*(height+i));

            GameObject tail = Instantiate(pages[pages.Count - (1 + i)].gameObject);
            tail.transform.SetParent(transform);
            tail.transform.localPosition = new Vector2(0.0f, -StaticData.cam_height * 2 * (1 + i));
        }
    }

    public void Scroll(float amount)
    {
        scroll_y += amount;
        if (scroll_y < 0)
        {
            scroll_y = height + scroll_y;
        }
        if (scroll_y >= height)
        {
            scroll_y = scroll_y % height;
        }

        transform.localPosition = new Vector2(0.0f, -scroll_y * StaticData.cam_height * 2);
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////// REEL INITIALIZERS //////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////

    // 1D perlin noise bars
    private void PageInit_0()
    {
        float perlin_y_left = UnityEngine.Random.Range(0f, 100f);
        float perlin_y_right = UnityEngine.Random.Range(0f, 100f);
        float perlin_stride = 0.25f;
        int sample_num = 0;

        for (int i = 0; i < height; i++)
        {
            GameObject p = new GameObject("Page " + i);
            p.transform.SetParent(transform);
            p.transform.localPosition = new Vector2(0.0f, StaticData.cam_height * 2 * i); ;
            pages.Add(p.AddComponent<Page>());

            List<float> lengths = new List<float>();
            for(int j = 0; j < 4; j++)
            {
                float left_sample = 2.0f*StaticData.cam_width*Mathf.PerlinNoise(sample_num * perlin_stride, perlin_y_left);
                left_sample *= 1.0f / 2.0f;
                float right_sample = 2.0f * StaticData.cam_width * Mathf.PerlinNoise(sample_num * perlin_stride, perlin_y_right);
                right_sample *= 1.0f / 2.0f;
                lengths.Add(left_sample);
                lengths.Add(right_sample);
                sample_num++;
            }

            pages[i].Init(0, colors, lengths);
        }
    }

    // Random rectangles
    private void PageInit_1()
    {
        int num_attempts = 3;
        float min_size = 3.0f;
        float max_size = 1.0f*StaticData.cam_height;
        float min_aspect = 1.5f; // width / height
        float max_aspect = 2.0f;

        for (int i = 0; i < height; i++)
        {
            GameObject p = new GameObject("Page " + i);
            p.transform.SetParent(transform);
            p.transform.localPosition = new Vector2(0.0f, StaticData.cam_height * 2 * i); ;
            pages.Add(p.AddComponent<Page>());

            // Generate square positions
            List<float> data = new List<float>();
            for (int j = 0; j < num_attempts; j++)
            {
                float x = UnityEngine.Random.Range(-StaticData.cam_width, StaticData.cam_width);
                float y = UnityEngine.Random.Range(-StaticData.cam_height, StaticData.cam_height);

                float scale_y = UnityEngine.Random.Range(min_size, max_size);
                float scale_x = scale_y * max_aspect;
                float aspect = UnityEngine.Random.Range(min_aspect, max_aspect);

                data.Add(x);
                data.Add(y);
                data.Add(scale_y * aspect);
                data.Add(scale_y);
            }

            pages[i].Init(1, colors, data);
        }
    }

    // Random circles
    private void PageInit_2()
    {
        int num_attempts = 2;
        float diameter = 8.0f;

        for (int i = 0; i < height; i++)
        {
            GameObject p = new GameObject("Page " + i);
            p.transform.SetParent(transform);
            p.transform.localPosition = new Vector2(0.0f, StaticData.cam_height * 2 * i); ;
            pages.Add(p.AddComponent<Page>());

            // Generate circle positions
          
            List<float> data = new List<float>();
            for (int j = 0; j < num_attempts; j++)
            {
                float x = UnityEngine.Random.Range(-StaticData.cam_width, StaticData.cam_width);
                float y = UnityEngine.Random.Range(-StaticData.cam_height + diameter/2.0f, StaticData.cam_height - diameter/2.0f);

                if (!StaticData.CircleIntersects(data, x, y, diameter+.5f))
                {
                    data.Add(x);
                    data.Add(y);
                    data.Add(diameter);
                }
            }

            pages[i].Init(2, colors, data);
        }
    }
    
}
