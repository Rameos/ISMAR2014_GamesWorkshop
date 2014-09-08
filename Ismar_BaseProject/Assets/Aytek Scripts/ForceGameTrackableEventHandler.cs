using UnityEngine;

public class ForceGameTrackableEventHandler : MonoBehaviour, ITrackableEventHandler
{
    public TrackableBehaviour mTrackableBehaviour;

    ForceGame forceGame;

    public Transform[] children;

    void Awake()
    {
        forceGame = GameObject.FindObjectOfType<ForceGame>();
        children = transform.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in children)
            t.gameObject.SetActive(false);

        gameObject.SetActive(true);
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
            forceGame.OnTrackableFound(mTrackableBehaviour.TrackableName, this);
        else if (newStatus == TrackableBehaviour.Status.NOT_FOUND)
            forceGame.OnTrackableLost(mTrackableBehaviour.TrackableName, this);
    }
}
