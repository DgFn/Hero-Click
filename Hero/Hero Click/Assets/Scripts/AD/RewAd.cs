using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class RewAd : MonoBehaviour
{
    public GameObject Swin;
    private string RewardedUnitID = "ca-app-pub-6590088195898772/6597659444";

    private RewardedAd rewardedAd;

    private void Start()
    {
        OnEnable();
    }

    private void OnEnable()
    {
        rewardedAd = new RewardedAd(RewardedUnitID);
        AdRequest adRequest = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(adRequest);
        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
    }
    private void HandleUserEarnedReward(object sender, Reward e)
    {
        int coins = 2;
        FindObjectOfType<GiveMyMoney>().RewardMoney(coins);
        
        rewardedAd.OnUserEarnedReward -= HandleUserEarnedReward;

    }

    public void ShowAd()
    {
        if(rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
            Swin.SetActive(false);
            StartCoroutine(WaitReward());
            OnEnable();
        }
        else
        {
            OnEnable();
        }
        
    }
    IEnumerator WaitReward()
    {
        yield return new WaitForSeconds(300);
        Swin.SetActive(true);
    }

}
