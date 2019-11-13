using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using PlayFab.DataModels;
using PlayFab.ProfilesModels;
using System.Collections.Generic;
using PlayFab.Json;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayfabLogin : MonoBehaviour
{
    public static PlayfabLogin PFC;
    private string userEmail;
    private string userPassword;
    private string username;
    //public GameObject loginPanel;
    //public GameObject addLoginPanel;
    //public GameObject recoverButton;
    //public GameObject panelMenu;
    public InputField email;
    public InputField password;
    public InputField username1;
    private void OnEnable()
    {

        #region Login
        if (PlayfabLogin.PFC == null)
        {
            PlayfabLogin.PFC = this;
        }
        else
        {
            if (PlayfabLogin.PFC != this)
            {
                Destroy(this.gameObject);
            }
        }
        DontDestroyOnLoad(this.gameObject);
    }
    public void Start()
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
         }*/
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
        //GetStats();
        //StartCloudHelloWorld();
    }
    private void OnLoginMobileSuccess(LoginResult result)
    {
        Debug.Log("Congratulations, you made your first successful API call!");
        //GetStats();
        //loginPanel.SetActive(false);
    }
    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("Congratulations, you made your first successful API call!");
        PlayerPrefs.SetString("EMAIL", userEmail);
        PlayerPrefs.SetString("PASSWORD", userPassword);
        PlayFabClientAPI.UpdateUserTitleDisplayName(new UpdateUserTitleDisplayNameRequest { DisplayName = username }, OnDisplayName, OnLoginFailure);
        //GetStats();
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
        emailIn = email.text;
    }
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
        //GetStats();
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
    }
    #endregion Login
}
