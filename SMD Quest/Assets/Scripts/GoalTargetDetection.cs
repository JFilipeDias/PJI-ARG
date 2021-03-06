﻿using UnityEngine;
using Vuforia;

public class GoalTargetDetection : MonoBehaviour, ITrackableEventHandler
{
    [HideInInspector]
    public bool isTracked;
    private TrackableBehaviour mTrackableBehaviour;


    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }


    public void OnTrackableStateChanged(
                                   TrackableBehaviour.Status previousStatus,
                                   TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            isTracked = true;
        }
        else if(previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            isTracked = false;
        }
    }
}
