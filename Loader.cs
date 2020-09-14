using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject blendSquare;
    public GameObject square;
    public GameObject blendCircle;
    public GameObject circle;
    public Sprite squareSprite;

    void Awake()
    {
        StaticData.blendSquare = blendSquare;
        StaticData.square = square;
        StaticData.blendCircle = blendCircle;
        StaticData.circle = circle;
        StaticData.squareSprite = squareSprite;
        StaticData.cam_height = Camera.main.orthographicSize;
        StaticData.cam_width = Camera.main.orthographicSize * Camera.main.aspect;

        GameObject test = new GameObject("test");
        SpriteRenderer render = test.AddComponent<SpriteRenderer>();
        render.sprite = StaticData.squareSprite;
        Debug.Log(render.sprite.bounds.max - render.sprite.bounds.min);
    }
}
