using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public enum RewardType
{
    DoubleCandies,
    GiveMoreCandies
}

public class RewardedAdDisplay : MonoBehaviour, IUnityAdsListener
{
    public string myGameIdAndroid = "4032249";
    public string myGameIdIOS = "4032248";
    public string myVideoPlacement = "rewardedVideo";
    public string myAdStatus = "";
    public bool adStarted;
    public bool adCompleted;   
    public RewardType rewardType;

    private bool testMode = true;
    ShowOptions options = new ShowOptions();

    private CandiesController candiesController;

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.AddListener(this);
    }

    private void Awake()
    {
        candiesController = FindObjectOfType<CandiesController>();
    }

    public void OnUnityAdsDidError(string message)
    {
        myAdStatus = message;
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        adCompleted = showResult == ShowResult.Finished;
        if (showResult == ShowResult.Finished)
        {
            if (rewardType == RewardType.DoubleCandies)
            {
                candiesController.DoubleCandies();
                candiesController.UpdateCandiesScore();
            }
            if (rewardType == RewardType.GiveMoreCandies)
            {
                candiesController.GiveMoreCandies();
                candiesController.UpdateCandiesScore();
            }
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        adStarted = true;
    }

    public void OnUnityAdsReady(string placementId)
    {
        if (!adStarted)
        {
            Advertisement.Show(myVideoPlacement, options);           
        }
    }

    public void CallAd() {
#if UNITY_IOS
        Advertisement.Initialize(myGameIdIOS, testMode);            
#else
        Advertisement.Initialize(myGameIdAndroid, testMode);
#endif
    }

    public bool GetAdCompleted()
    {
        return adCompleted;
    }
}
