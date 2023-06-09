using System.Collections.Generic;
using HmsPlugin;
using UnityEngine;
using HuaweiMobileServices.Ads;
using System;

public class AdsManager : MonoBehaviour
{
    public void isLevelComplete()
    {
        HMSAdsKitManager.Instance.ShowInterstitialAd();   
    }

    private void update()
    {
        if(GameManager.Instance.isFinished)
        {
            isLevelComplete();
        }
    }
}