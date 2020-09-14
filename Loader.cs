using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject blendSquare;
    public GameObject square;
    public GameObject blendCircle;

    void Awake()
    {
        StaticData.blendSquare = blendSquare;
        StaticData.square = square;
        StaticData.blendCircle = blendCircle;
        StaticData.cam_height = Camera.main.orthographicSize;
        StaticData.cam_width = Camera.main.orthographicSize * Camera.main.aspect;
    }
}
