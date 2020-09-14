using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticData
{
    // Global relevance
    public static GameObject blendSquare;
    public static GameObject square;
    public static GameObject blendCircle;
    public static GameObject circle;
    public static Sprite squareSprite;
    public static float cam_width;
    public static float cam_height;
    public const int MAX_REELS = 10;

    // Decide next reel type
    public static int next_reel_type = 0;
    public const int NUM_REEL_TYPES = 3;

    public static Color RandomColor()
    {
        return Color.HSVToRGB(UnityEngine.Random.Range(0.0f, 1.0f), .7f, 1.0f);
        // return new Color(UnityEngine.Random.Range(0.0f, 1.0f), UnityEngine.Random.Range(0.0f, 1.0f), UnityEngine.Random.Range(0.0f, 1.0f), 1.0f);
    }

    // Returns list if intersection [x, y, scale_x, scale_y] or null if no intersection
    public static List<float> RectIntersect()
    {
        return null;
    }

    // Returns true if intersects, false otherwise
    public static bool CircleIntersects(List<float> data, float x, float y, float diameter)
    {
        int num_circles = data.Count / 3;
        for(int i = 0; i < num_circles; i++)
        {
            float dist = Mathf.Sqrt(Mathf.Pow(x - data[i*3 + 0], 2) + Mathf.Pow(y - data[i*3 + 1], 2));
            if (dist < diameter)
                return true;
        }
        return false;
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////// REEL INITIALIZERS //////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    

}
