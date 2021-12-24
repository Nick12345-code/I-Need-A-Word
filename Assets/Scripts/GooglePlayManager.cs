using UnityEngine;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi;
using GooglePlayGames;

public class GooglePlayManager : MonoBehaviour
{
    static GooglePlayManager instance;
    public static GooglePlayManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GooglePlayManager>();
            }
            return instance;
        }
    }

    public bool isConnectedToGooglePlayServices;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
    }

    void Start() => SignInToGooglePlayServices();

    void SignInToGooglePlayServices()
    {
        PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptOnce, (result) =>
        {
            switch (result)
            {
                case SignInStatus.Success:
                    isConnectedToGooglePlayServices = true;
                    break;
                default:
                    isConnectedToGooglePlayServices = false;
                    break;
            }
        });
    }

    public static void ShowLeaderboard()
    {
        // show specific leaderboard UI
        PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkIidiy_u4dEAIQCA");
    }
  
}
