using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SimpleCloudHandler : MonoBehaviour, ICloudRecoEventHandler
{
    private CloudRecoBehaviour mCloudRecoBehaviour;
    private bool mIsScanning = false;
    private string mTargetMetaData = "";

    private void Start()
    {
        //registering this event handler at the cloud reco behaviour
        mCloudRecoBehaviour = GetComponent<CloudRecoBehaviour>();
        if (mCloudRecoBehaviour)
            mCloudRecoBehaviour.RegisterEventHandler(this);
    }

    private void OnGUI()
    {
        //Display current scanning status
        GUI.Box(new Rect(100, 100, 200, 50), mIsScanning ? "Scanning" : "Not scanning");

        //Display metadata of latest detected cloud-target
        GUI.Box(new Rect(100, 200, 200, 50), "Metadata: " + mTargetMetaData);

        //If not scanning , show button so that user can restart cloud scanning
        if (!mIsScanning)
        {
            if(GUI.Button(new Rect(100, 300,200,50), "Restart Scanning"))
            {
                //restart TargetFinder
                mCloudRecoBehaviour.CloudRecoEnabled = true;
            }
        }

    }

    public void OnInitError(TargetFinder.InitState initError)
    {
        Debug.Log("Cloud Reco init error " + initError.ToString());
    }

    public void OnInitialized()
    {
        Debug.Log("Cloud Reco initialized");
    }

    //handling a cloud target recogintion event
    public void OnNewSearchResult(TargetFinder.TargetSearchResult targetSearchResult)
    {
        //do something with the target metadata
        mTargetMetaData = targetSearchResult.MetaData;
        mCloudRecoBehaviour.CloudRecoEnabled = false;
    }

    public void OnStateChanged(bool scanning)
    {
        mIsScanning = scanning;
        if (scanning)
        {
            //clear all known trackables
            var tracker = TrackerManager.Instance.GetTracker<ObjectTracker>();
            tracker.TargetFinder.ClearTrackables(false);
        }
    }

    public void OnUpdateError(TargetFinder.UpdateState updateError)
    {
        Debug.Log("Cloud Reco update error " + updateError.ToString());
    }
}
