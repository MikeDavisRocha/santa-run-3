using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdDisplay : MonoBehaviour
{
    public string myGameIdAndroid = "4032249";
    public string myGameIdIOS = "4032248";
    public string myVideoPlacement = "video";
    public bool adStarted;
    private bool testMode = true;

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_IOS
        Advertisement.Initialize(myGameIdIOS, testMode);            
#else
        Advertisement.Initialize(myGameIdAndroid, testMode);
#endif
    }

    // Update is called once per frame
    void Update()
    {
        if (Advertisement.isInitialized && Advertisement.IsReady(myVideoPlacement) && !adStarted)
        {
            Advertisement.Show(myVideoPlacement);
            adStarted = true;
        }
    }
}
