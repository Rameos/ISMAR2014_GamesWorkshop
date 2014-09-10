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
    #region PRIVATE_MEMBER_VARIABLES
 
    private TrackableBehaviour mTrackableBehaviour;
    
    #endregion // PRIVATE_MEMBER_VARIABLES

    public HintCollectorScript hintCollector;
    private GameObject torus;
    private GameObject camera;
    private Quaternion cameraRot;
    private Vector3 cameraPos;

    #region UNTIY_MONOBEHAVIOUR_METHODS
    
    void Start()
    {
        torus = GameObject.Find("torus");
        camera = Camera.main.gameObject;
        cameraRot = camera.transform.rotation;
        cameraPos = camera.transform.position;
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

        string targetName = mTrackableBehaviour.TrackableName;

        if(Application.loadedLevelName == "GPSscene"){
            torus.SetActive(false);

            if (targetName ==("stone1") || targetName==("stone2") || targetName==("stone3") || targetName==("stone4") || targetName==("stone5") || targetName == ("stone6") || targetName == ("stone7") || targetName == ("stone8"))
            {
                UIManagerGPS.Toggle1();
                hintCollector.found(1);
            }
            if (targetName == ("shield2"))
            {
                UIManagerGPS.Toggle2();
                hintCollector.found(2);
            }
            if (targetName == ("sign"))
            {
                UIManagerGPS.Toggle3();
                hintCollector.found(3);
            }
            if (targetName == ("princess"))
            {
                UIManagerGPS.ShowLoadingScreen();
                Application.LoadLevelAsync("Safepuzzle");
            }

        }
        if (Application.loadedLevelName == "Safepuzzle")
        {
            UIManager.HideCancelDialog();
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

        if (Application.loadedLevelName == ("Safepuzzle"))
        {
            UIManager.ShowCancelDialog();
        }

        if (Application.loadedLevelName == ("GPSscene") && !(PlayerPrefsX.GetBool("GPS_key1", false) && PlayerPrefsX.GetBool("GPS_key2", false) && PlayerPrefsX.GetBool("GPS_key3", false)))
        {            
            torus.SetActive(true);
            camera.transform.position = cameraPos;
            camera.transform.rotation = cameraRot;

        }
        else
        {
            UIManagerGPS.FinishedGPS();
        }

        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
    }

    #endregion // PRIVATE_METHODS
}
