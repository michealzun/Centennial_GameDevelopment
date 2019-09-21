using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class DoesntMatter : DefaultTrackableEventHandler {

    protected override void OnTrackingFound()
    {
        if (GetComponentInChildren<VideoPlayer>() != null)
        {
            GetComponentInChildren<VideoPlayer>().Play();
        }
    }
    

    protected override void OnTrackingLost()
    {
        if (GetComponentInChildren<VideoPlayer>() != null)
        {
            GetComponentInChildren<VideoPlayer>().Pause();
        }
    }

}
