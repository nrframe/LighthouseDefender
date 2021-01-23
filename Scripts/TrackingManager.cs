using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TrackingManager : MonoBehaviour
{
    private ARTrackedImageManager myTrackedImageManager;

    [SerializeField] private GameObject lighthouseObject;

    private GameObject placedLighthouse;

    private int counter = 0;

    private void Awake()
    {
         myTrackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    private void Update()
    {

            if (myTrackedImageManager.trackables.count == 1 && counter == 0)
            {
            PlaceLighthouse();
            }
    }

    public void PlaceLighthouse()
    {
        foreach(var trackedImage in myTrackedImageManager.trackables)
        {
            placedLighthouse = Instantiate(lighthouseObject, trackedImage.transform.position, Quaternion.identity);
        }
        counter++;
    }

    public void ResetTracking()
    {
        counter = 0;
    }
}


