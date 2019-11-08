using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using PlayFab.DataModels;
using PlayFab.ProfilesModels;
using System.Collections.Generic;
using PlayFab.Json;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayFabController : MonoBehaviour
{
    public static PlayFabController PFC;
    private string userEmail;
    private string userPassword;
    private string username;
    public GameObject loginPanel;
    public GameObject addLoginPanel;
    //public GameObject recoverButton;
    public GameObject panelMenu;
    public InputField email;
    public InputField password;
    public InputField username1;
    private void OnEnable()
    {

    #region Login
        if (PlayFabController.PFC == null)
        {
            PlayFabController.PFC = this;
        }
        else
        {
            if (PlayFabController.PFC != this)
            {
                Destroy(this.gameObject);
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }
   /* public void Start()
    {
       
        //Note: Setting title Id here can be skipped if you have set the value in Editor Extensions already.
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
            PlayFabSettings.TitleId = "A8C44"; // Please change this value to your own titleId from PlayFab Game Manager
        }
        //PlayerPrefs.DeleteAll();
        //var request = new LoginWithCustomIDRequest { CustomId = "GettingStartedGuide", CreateAccount = true };
        //PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
        if (PlayerPrefs.HasKey("EMAIL"))
        {
            userEmail = PlayerPrefs.GetString("EMAIL");
            userPassword = PlayerPrefs.GetString("PASSWORD");
            var request = new LoginWithEmailAddressRequest { Email = userEmail, Password = userPassword };
            PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
        }
       /* else
        {
#if UNITY_ANDROID
            var requestAndroid = new LoginWithAndroidDeviceIDRequest { AndroidDeviceId = ReturnMobileID(), CreateAccount = true };
            PlayFabClientAPI.LoginWithAndroidDeviceID(requestAndroid, OnLoginMobileSuccess, OnLoginMobileFailure);
#endif
#if UNITY_IOS
            var requestIOS = new LoginWithIOSDeviceIDRequest { DeviceId = ReturnMobileID(), CreateAccount = true };
            PlayFabClientAPI.LoginWithIOSDeviceID(requestIOS, OnLoginMobileSuccess, OnLoginMobileFailure);
#endif
        }
    }
    
    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Congratulations, you made your first successful API call!");
        PlayerPrefs.SetString("EMAIL", userEmail);
        PlayerPrefs.SetString("PASSWORD", userPassword);
        //loginPanel.SetActive(false);
        //recoverButton.SetActive(false);
        //panelMenu.SetActive(true);
        LoadSceneByIndex(1);
        GetStats();
        //StartCloudHelloWorld();
    }
    private void OnLoginMobileSuccess(LoginResult result)
    {
        Debug.Log("Congratulations, you made your first successful API call!");
        GetStats();
        //loginPanel.SetActive(false);
    }
    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("Congratulations, you made your first successful API call!");
        PlayerPrefs.SetString("EMAIL", userEmail);
        PlayerPrefs.SetString("PASSWORD", userPassword);
        PlayFabClientAPI.UpdateUserTitleDisplayName(new UpdateUserTitleDisplayNameRequest { DisplayName = username }, OnDisplayName, OnLoginFailure);
        GetStats();
        //loginPanel.SetActive(false);
        LoadSceneByIndex(1);
    }
    void OnDisplayName(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log(result.DisplayName + " is your new display name");
    }
    private void OnLoginFailure(PlayFabError error)
    {
        var registerRequest = new RegisterPlayFabUserRequest { Email = userEmail, Password = userPassword, Username = username };
        PlayFabClientAPI.RegisterPlayFabUser(registerRequest, OnRegisterSuccess, OnRegisterFailure);
    }
    private void OnLoginMobileFailure(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
    }
    private void OnRegisterFailure(PlayFabError error)
    {
        Debug.LogError(error.GenerateErrorReport());
    }
    public void GetUserEmail(string emailIn)
    {
        userEmail = emailIn;
        emailIn = email.text;    }
    public void GetUserPassword(string passwordIn)
    {
        userPassword = passwordIn;
        passwordIn = password.text;
    }
    public void GetUsername(string usernameIn)
    {
        username = usernameIn;
        usernameIn = username1.text;
    }
    public void OnClickLogin()
    {
        var request = new LoginWithEmailAddressRequest { Email = userEmail, Password = userPassword };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
    }
    public static string ReturnMobileID()
    {
        string deviceID = SystemInfo.deviceUniqueIdentifier;
        return deviceID;
    }
    public void OpenAddLogin()
    {
        Debug.Log("AddLogin");
        //addLoginPanel.SetActive(true);
       // loginPanel.SetActive(false);
    }
    public void OnClickAddLogin()
    {
        var addLoginRequest = new AddUsernamePasswordRequest { Email = userEmail, Password = userPassword, Username = username };
        PlayFabClientAPI.AddUsernamePassword(addLoginRequest, OnAddLoginSuccess, OnRegisterFailure);
    }
    private void OnAddLoginSuccess(AddUsernamePasswordResult result)
    {
        Debug.Log("Congratulations, you made your first successful API call!");
        GetStats();
        PlayerPrefs.SetString("EMAIL", userEmail);
        PlayerPrefs.SetString("PASSWORD", userPassword);
        //addLoginPanel.SetActive(false);
    }

    public void LogOut()
    {
        PlayFabSettings.TitleId = "";
    }

    public void LoadSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }*/
    #endregion Login


    public int playerHighScore;

    #region PlayerStats

    void Update()
    {
            //playerHighScore = GameController.myPoints;


        /*if (GameController.myPoints > player.StatValue)
        {
            player.StatValue = GameController.myPoints;
        }*/
    }
    
    public void GetStats()
    {
        PlayFabClientAPI.GetPlayerStatistics(
            new GetPlayerStatisticsRequest(),
            OnGetStats,
            error => Debug.LogError(error.GenerateErrorReport())
        );
    }
    void OnGetStats(GetPlayerStatisticsResult result)
    {
        Debug.Log("Received the following Statistics:");
        foreach (var eachStat in result.Statistics)
        {
            Debug.Log("Statistic (" + eachStat.StatisticName + "): " + eachStat.Value);
            switch (eachStat.StatisticName)
            { 
                case "PlayerHighScore":
                    playerHighScore = eachStat.Value;
                    break;
            }
        }
    }
    // Build the request object and access the API
    public void StartCloudUpdatePlayerStats()
    {
        PlayFabClientAPI.ExecuteCloudScript(new ExecuteCloudScriptRequest()
        {
            FunctionName = "UpdatePlayerStats", // Arbitrary function name (must exist in your uploaded cloud.js file)
            FunctionParameter = new {highScore = playerHighScore}, // The parameter provided to your function
            GeneratePlayStreamEvent = true, // Optional - Shows this event in PlayStream
        }, OnCloudUpdateStats, OnErrorShared);
    }
    // OnCloudHelloWorld defined in the next code block
    private static void OnCloudUpdateStats(ExecuteCloudScriptResult result)
    {
        // Cloud Script returns arbitrary results, so you have to evaluate them one step and one parameter at a time
        Debug.Log(PlayFab.PluginManager.GetPlugin<ISerializerPlugin>(PluginContract.PlayFab_Serializer).SerializeObject(result.FunctionResult));
        JsonObject jsonResult = (JsonObject)result.FunctionResult;
        object messageValue;
        jsonResult.TryGetValue("messageValue", out messageValue); // note how "messageValue" directly corresponds to the JSON values set in Cloud Script
        Debug.Log((string)messageValue);
    }
    private static void OnErrorShared(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
    }

    #endregion PlayerStats

    public GameObject leaderboardPanel;
    public GameObject listingPrefab;
    public Transform listingContainer;
    public static PlayerLeaderboardEntry player;
    #region Leaderboard



    //public InputField playerName;

    // Método que gera o prefab e pega a leaderboard do servidor quando for chamado.
    public void GetLeaderboarder()
    {
        var requestLeaderboard = new GetLeaderboardRequest { StartPosition = 0, StatisticName = "PlayerHighScore", MaxResultsCount = 10 };
        PlayFabClientAPI.GetLeaderboard(requestLeaderboard, OnGetLeaderboard, OnErrorLeaderboard);

    }

        void OnGetLeaderboard(GetLeaderboardResult Resultado)
        {
            leaderboardPanel.SetActive(true);
        //Debug.Log(Resultado.Leaderboard[0].StatValue);

       
        // Lista de repetição para ser chamada sempre que necessário.
        foreach (PlayerLeaderboardEntry player in Resultado.Leaderboard)
            {
            //player.DisplayName = GameController.myPlayername.text;

            // Gera um GameObject para ser uma lista temporaria que vai receber um prefab
            GameObject tempListing = Instantiate(listingPrefab, listingContainer);
            // Esse prefab vai exibir a lista do leaderboard e substituir o texto pelos valores do servidor.
                LeaderboardListing LL = tempListing.GetComponent<LeaderboardListing>();
                LL.playerNameText.text = player.DisplayName;
                LL.playerScoreText.text = player.StatValue.ToString();
                Debug.Log(player.DisplayName + ":" + player.StatValue);
            }
        }

   
    // Método para destruir a lista de prefab com o leaderboard quando for fechado o painel.
    public void CloseLeaderboardPanel()
    {
        leaderboardPanel.SetActive(false);
        for(int i = listingContainer.childCount -1; i>= 0; i--)
        {
            Destroy(listingContainer.GetChild(i).gameObject);
        }
       
    }

    // Função para caso de erro, listar qual foi o erro.
    void OnErrorLeaderboard(PlayFabError error)
        {
            Debug.LogError(error.GenerateErrorReport());
        }
    #endregion Leaderboard
}

