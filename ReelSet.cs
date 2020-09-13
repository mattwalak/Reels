using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelSet : MonoBehaviour
{
    List<Reel> reels;
    int reel_height;

    // Generates a new reel as a child of this reel set
    private Reel genNewReel()
    {
        GameObject reelParent = new GameObject("reel parent " + reels.Count);
        reelParent.transform.position = Vector2.zero;
        reelParent.transform.SetParent(transform);
        GameObject reelObj = new GameObject("reel " + reels.Count);
        reelObj.transform.SetParent(reelParent.transform);
        Reel r = reelObj.AddComponent<Reel>();
        r.Init(1, reel_height);
        return r;
    }

    public void Init(int height)
    {
        transform.position = Vector2.zero;
        reel_height = height;
        reels = new List<Reel>();
        reels.Add(genNewReel());
    }

    public void PushReel()
    {
        reels.Add(genNewReel());

        // Reposition reels
        float scale = 1.0f / reels.Count;
        float stride_x = 2 * StaticData.cam_width / reels.Count;
        float min_x = -StaticData.cam_width + (stride_x / 2.0f);
        float stride_y = 2 * StaticData.cam_height / reels.Count;
        float min_y = -StaticData.cam_height + (stride_y / 2.0f);
        for(int i = 0; i < reels.Count; i++)
        {
            Vector2 new_pos = new Vector2(min_x + i*stride_x, min_y);
            Vector2 new_scale = new Vector2(scale, scale);
            reels[i].transform.parent.transform.localPosition = new_pos;
            reels[i].transform.parent.transform.localScale = new_scale;
        }
    }

    public void PopReel()
    {

    }

    public void ScrollReel(int index, float amount)
    {
        if (index >= reels.Count)
        {
            Debug.Log("Reel out of bounds");
        }
        else
        {
            reels[index].Scroll(amount);
        }
    }
}
