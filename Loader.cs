using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject square;

    void Start()
    {
        StaticData.square = square;
        StaticData.cam_height = Camera.main.orthographicSize;
        StaticData.cam_width = Camera.main.orthographicSize * Camera.main.aspect;
    }
}
