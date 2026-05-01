using System;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class GoogleAdsManager : MonoBehaviour
{
    public static GoogleAdsManager Instance;

    [Header("Scriptable")]
    [SerializeField] private AdsConfig adsConfig;
    //[SerializeField] private InAppConfig inAppConfig;


    private InterstitialAd interstitialAd;
    private RewardedAd rewardedAd;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        MobileAds.Initialize(initStatus =>
        {
            Debug.Log("AdMob Initialized");

            LoadInterstitialAd();
            LoadRewardedAd();
        });

    }

    private void OnEnable()
    {
        AdsAction.ShowInterstitialAds += ShowInterstitial;
    }

    private void OnDisable()
    {
        AdsAction.ShowInterstitialAds -= ShowInterstitial;
    }

   
    // ===============================
    // INTERSTITIAL
    // ===============================

    private void LoadInterstitialAd()
    {
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
            interstitialAd = null;
        }

        AdRequest request = new AdRequest();

        InterstitialAd.Load(adsConfig.interstitialAdUnitId, request,
            (InterstitialAd ad, LoadAdError error) =>
            {
                if (error != null)
                {
                    Debug.LogError("Interstitial Load Failed: " + error);
                    return;
                }

                interstitialAd = ad;

                interstitialAd.OnAdFullScreenContentClosed += () =>
                {
                    LoadInterstitialAd(); // preload next
                };

                interstitialAd.OnAdFullScreenContentFailed += (AdError err) =>
                {
                    LoadInterstitialAd();
                };
            });
    }

    private void ShowInterstitial()
    {
        //if (inAppConfig.removeAds == ProductStatus.PURCHASED) return;

        if (interstitialAd != null && interstitialAd.CanShowAd())
        {
            interstitialAd.Show();
        }
        else
        {
            Debug.Log("Interstitial not ready");
        }
    }

    // ===============================
    // REWARDED
    // ===============================

    private void LoadRewardedAd()
    {
        if (rewardedAd != null)
        {
            rewardedAd.Destroy();
            rewardedAd = null;
        }

        AdRequest request = new AdRequest();

        RewardedAd.Load(adsConfig.rewardedAdUnitId, request,
            (RewardedAd ad, LoadAdError error) =>
            {
                if (error != null)
                {
                    Debug.LogError("Rewarded Load Failed: " + error);
                    return;
                }

                rewardedAd = ad;

                rewardedAd.OnAdFullScreenContentClosed += () =>
                {
                    LoadRewardedAd(); // preload next
                };

                rewardedAd.OnAdFullScreenContentFailed += (AdError err) =>
                {
                    LoadRewardedAd();
                };
            });
    }

    private void ShowRewarded(Action onRewardEarned)
    {
        if (rewardedAd != null && rewardedAd.CanShowAd())
        {
            rewardedAd.Show((Reward reward) =>
            {
                Debug.Log("Reward Earned");
                onRewardEarned?.Invoke();
            });
        }
        else
        {
            Debug.Log("Rewarded not ready");
        }
    }

    public bool IsRewardedReady()
    {
        return rewardedAd != null && rewardedAd.CanShowAd();
    }
}