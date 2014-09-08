/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Qualcomm Connected Experiences, Inc.
==============================================================================*/

using UnityEngine;

/// <summary>
/// A custom handler that implements the ITrackableEventHandler interface.
/// </summary>
public class DefaultTrackableEventHandler : MonoBehaviour,
                                            ITrackableEventHandler
{
    public HintCollectorScript hintCollector;

    #region PRIVATE_MEMBER_VARIABLES
 
    private TrackableBehaviour mTrackableBehaviour;
    
    #endregion // PRIVATE_MEMBER_VARIABLES



    #region UNTIY_MONOBEHAVIOUR_METHODS
    
    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    #endregion // UNTIY_MONOBEHAVIOUR_METHODS



    #region PUBLIC_METHODS

    /// <summary>
    /// Implementation of the ITrackableEventHandler function called when the
    /// tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();
        }
        else
        {
            OnTrackingLost();
        }
    }

    #endregion // PUBLIC_METHODS



    #region PRIVATE_METHODS


    private void OnTrackingFound()
    {
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
        Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

        // Enable rendering:
        foreach (Renderer component in rendererComponents)
        {
            component.enabled = true;
        }

        // Enable colliders:
        foreach (Collider component in colliderComponents)
        {
            component.enabled = true;
        }

        if (Application.loadedLevel == 1)
        {
            UIManager.HideCancelDialog();
        }

        if (Application.loadedLevel == 0)
        {
            if (mTrackableBehaviour.TrackableName.Equals("butt") || mTrackableBehaviour.TrackableName.Equals("stone1") || mTrackableBehaviour.TrackableName.Equals("stone2") || mTrackableBehaviour.TrackableName.Equals("stone3") || mTrackableBehaviour.TrackableName.Equals("stone4") || mTrackableBehaviour.TrackableName.Equals("stone5") || mTrackableBehaviour.TrackableName.Equals("stone6") || mTrackableBehaviour.TrackableName.Equals("stone7") || mTrackableBehaviour.TrackableName.Equals("stone8"))
            {
                UIManagerGPS.Toggle1();
                hintCollector.found(1);
            }
            if (mTrackableBehaviour.TrackableName.Equals("sign") || mTrackableBehaviour.TrackableName.Equals("back"))
            {
                UIManagerGPS.Toggle2();
                hintCollector.found(2);
            }
            if (mTrackableBehaviour.TrackableName.Equals("gulli") || mTrackableBehaviour.TrackableName.Equals("back"))
            {
                UIManagerGPS.Toggle3();
                hintCollector.found(3);
            }
            if (mTrackableBehaviour.TrackableName.Equals("chips") || mTrackableBehaviour.TrackableName.Equals("tarmac"))
            {
               UIManagerGPS.ShowLoadingScreen();
               Application.LoadLevelAsync("Safepuzzle");
            }

        }

        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
    }


    private void OnTrackingLost()
    {
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
        Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

        // Disable rendering:
        foreach (Renderer component in rendererComponents)
        {
            component.enabled = false;
        }

        // Disable colliders:
        foreach (Collider component in colliderComponents)
        {
            component.enabled = false;
        }
        
        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");

        if (Application.loadedLevel == 1)
        {
            UIManager.ShowCancelDialog();
        }
        
    }

    #endregion // PRIVATE_METHODS
}
