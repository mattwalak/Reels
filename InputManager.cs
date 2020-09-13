using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public int reel_height;

    private static readonly KeyCode[] alphaNums = new KeyCode[] { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9, KeyCode.Alpha0 };
    ReelSet reelSet;

    void Start()
    {
        GameObject reelSetObj = new GameObject("Reel Set");
        reelSet = reelSetObj.AddComponent<ReelSet>();
        reelSet.Init(reel_height);
    }

    void Update()
    {
        // Check for add / remove reel
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            reelSet.PopReel();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            reelSet.PushReel();
        }

        // Check for scroll up / down
        float scroll_force = 0.0f;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            scroll_force += .01f;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            scroll_force -= .01f;
        }

        // Apply scroll to each reel
        if (scroll_force != 0)
        {
            for (int i = 0; i < 10; i++)
            {
                if (Input.GetKey(alphaNums[i]))
                {
                    reelSet.ScrollReel(i, scroll_force);
                }
            }
        }

    }
}
