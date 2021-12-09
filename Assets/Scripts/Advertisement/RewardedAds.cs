using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

[RequireComponent(typeof(Button))]
public class RewardedAds : MonoBehaviour, IUnityAdsListener
{
    GameData gameData;
    [SerializeField] int iqReward = 20;
    #if UNITY_IOS
    private string gameId = "4487727";
    #elif UNITY_ANDROID
    private string gameId = "4487726";
    #endif

    Button myButton;
    public string mySurfacingId = "Rewarded_Android";

    private void Awake() => gameData = SaveSystem.Load();

    void Start()
    {
        myButton = GetComponent<Button>();

        // Set interactivity to be dependent on the Placement�s status:
        myButton.interactable = Advertisement.IsReady(mySurfacingId);

        // Map the ShowRewardedVideo function to the button�s click listener:
        if (myButton) myButton.onClick.AddListener(ShowRewardedVideo);

        // Initialize the Ads listener and service:
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, true);
    }

    // Implement a function for showing a rewarded video ad:
    void ShowRewardedVideo()
    {
        Advertisement.Show(mySurfacingId);
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, activate the button: 
        if (placementId == mySurfacingId)
        {
            myButton.interactable = true;
        }
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            gameData.iqTotal += iqReward;
        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }
}