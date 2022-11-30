using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class InterAD : MonoBehaviour
{
    private InterstitialAd interstitialAd;

    private string interstitialUitID = "ca-app-pub-6590088195898772/9565575898";

    private void Start()
    {
        OnEnable();
    }

    private void OnEnable()
    {
        interstitialAd = new InterstitialAd(interstitialUitID);
        AdRequest adRequest = new AdRequest.Builder().Build();
        interstitialAd.LoadAd(adRequest);
    }

    public void ShowAd()
    {
        if(interstitialAd.IsLoaded())
        {
            interstitialAd.Show();
            OnEnable();
        }
        else
        {
            OnEnable();
        }
    }

}
