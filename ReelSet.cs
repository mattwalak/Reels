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
        r.Init(StaticData.next_reel_type, reel_height);
        StaticData.next_reel_type = (StaticData.next_reel_type + 1) % StaticData.NUM_REEL_TYPES;
        return r;
    }

    private void repositionReels()
    {
        float scale = 1.0f / reels.Count;
        float stride_x = 2 * StaticData.cam_width / reels.Count;
        float min_x = -StaticData.cam_width + (stride_x / 2.0f);
        float stride_y = 2 * StaticData.cam_height / reels.Count;
        float min_y = -StaticData.cam_height + (stride_y / 2.0f);
        for (int i = 0; i < reels.Count; i++)
        {
            Vector2 new_pos = new Vector2(min_x + i * stride_x, min_y);
            Vector2 new_scale = new Vector2(scale, scale);
            reels[i].transform.parent.transform.localPosition = new_pos;
            reels[i].transform.parent.transform.localScale = new_scale;
        }
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
        if(reels.Count == StaticData.MAX_REELS)
        {
            Debug.Log("Can't add any more reels");
        }
        else
        {
            reels.Add(genNewReel());
            repositionReels();
        }
    }

    public void PopReel()
    {
        if(reels.Count == 1)
        {
            Debug.Log("Can't pop with 1 reel");
        }
        else
        {
            Destroy(reels[reels.Count - 1].gameObject);
            reels.RemoveAt(reels.Count - 1);
            repositionReels();
        }
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
