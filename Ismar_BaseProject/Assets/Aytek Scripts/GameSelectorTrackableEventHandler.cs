using UnityEngine;

public class GameSelectorTrackableEventHandler : MonoBehaviour, ITrackableEventHandler
{
    GameSelector gameSelector;
    TrackableBehaviour mTrackableBehaviour;

    void Awake()
    {
        gameSelector = GameObject.FindObjectOfType<GameSelector>();
    }

    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();

        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        Debug.Log(newStatus);

        if (newStatus == TrackableBehaviour.Status.TRACKED)
            gameSelector.OnTrackableFound(mTrackableBehaviour.TrackableName);
    }
}
