using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticData
{
    // Global relevance
    public static GameObject blendSquare;
    public static GameObject square;
    public static GameObject blendCircle;
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

    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////// REEL INITIALIZERS //////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    

}
