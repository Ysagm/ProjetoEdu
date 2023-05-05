using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AddsManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string _androidGameId;
    [SerializeField] string _iOSGameId;
    [SerializeField] bool _testMode = true;
    private string _gameId;

    [SerializeField] string _androidInterstitialId = "Interstitial_Android";
    [SerializeField] string _iOsInterstitialId = "Interstitial_iOS";
    string _InterstitialUnitId;

    void Awake()
    {
        #if UNITY_IOS
                _gameId = _iOSGameId;
                _InterstitialUnitId = _iOsInterstitialId;
        #elif UNITY_ANDROID
                _gameId = _androidGameId;
                _InterstitialUnitId = _androidInterstitialId;
        #endif
        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(_gameId, _testMode, this);
        }
    }


    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
        LoadAd(_InterstitialUnitId);
    }
 
    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
//--------------------------------------------------------------------------------------------------
    public void ShowInterstitial(){
        ShowAd(_InterstitialUnitId);
    }
//--------------------------------------------------------------------------------------------------
     // Load content to the Ad Unit:
    void LoadAd(string _adUnityId)
    {
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        Debug.Log("Loading Ad: " + _InterstitialUnitId);
        Advertisement.Load(_InterstitialUnitId, this);
    }
 
    // Show the loaded content in the Ad Unit:
    void ShowAd(string _adUnityId)
    {
        // Note that if the ad content wasn't previously loaded, this method will fail
        Debug.Log("Showing Ad: " + _InterstitialUnitId);
        Advertisement.Show(_InterstitialUnitId, this);
    }
 
    // Implement Load Listener and Show Listener interface methods: 
    public void OnUnityAdsAdLoaded(string _adUnityId)
    {
        // Optionally execute code if the Ad Unit successfully loads content.
    }
 
    public void OnUnityAdsFailedToLoad(string _adUnityId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit: {_adUnityId} - {error.ToString()} - {message}");
        // Optionally execute code if the Ad Unit fails to load, such as attempting to try again.
    }
 
    public void OnUnityAdsShowFailure(string _adUnityId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {_adUnityId}: {error.ToString()} - {message}");
        // Optionally execute code if the Ad Unit fails to show, such as loading another ad.
    }
 
    public void OnUnityAdsShowStart(string _adUnityId) { }
    public void OnUnityAdsShowClick(string _adUnityId) { }

    public void OnUnityAdsShowComplete(string _adUnityId, UnityAdsShowCompletionState showCompletionState) 
    { 
        LoadAd(_adUnityId);
    }
}
