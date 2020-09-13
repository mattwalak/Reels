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
     * 1 = 1D perlin noise bars
     * 
     * 
     */
    public void Init(int type, int height_in)
    {
        colors = new List<Color>() { new Color(1.0f, 0.0f, 0.0f, 1.0f), new Color(1.0f, 1.0f, 0.0f, 1.0f)};
        height = height_in;
        transform.position = new Vector2(0.0f, 0.0f);

        pages = new List<Page>();
        switch (type)
        {
            case 1:
                PageInit_1();
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
    private void PageInit_1()
    {
        float perlin_y = UnityEngine.Random.Range(0f, 100f);
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
                lengths.Add(8f*Mathf.PerlinNoise(sample_num * perlin_stride, perlin_y));
                sample_num++;
            }

            pages[i].Init(1, colors, lengths);
        }
    }
















    
}
