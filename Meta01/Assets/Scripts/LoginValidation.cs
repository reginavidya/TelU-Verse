using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginValidation : MonoBehaviour
{
    [SerializeField] GameObject PopUp;
    [SerializeField] TextMeshProUGUI MessageText;

    [Header("Login")]
    [SerializeField] TMP_InputField EmailLoginInput;
    [SerializeField] TMP_InputField PasswordLoginInput;
    [SerializeField] GameObject LoginPage;
    [SerializeField] Toggle rememberMe;

    [Header("Register")]
    [SerializeField] TMP_InputField UsernameInput;
    [SerializeField] TMP_InputField EmailRegisterInput;
    [SerializeField] TMP_InputField PasswordRegisterInput;
    [SerializeField] GameObject RegisterPage;

    [Header("Forgot Password")]
    [SerializeField] TMP_InputField EmailForgotInput;
    [SerializeField] GameObject ForgotPasswordPage;

    [Header("Show and Hide Password Sign Up")]
    [SerializeField] Image ShowPassImgIcon;
    [SerializeField] Image HidePassImgIcon;

    [Header("Show and Hide Password Login")]
    [SerializeField] Image ShowPassImgIcon1;
    [SerializeField] Image HidePassImgIcon1;
    [SerializeField] private GameManager gameManager;

    public static LoginValidation Instance;
    public static string userID;
    int sceneIndex;

    public void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.GetString("Email");
        PlayerPrefs.GetString("Sandi");
        if (PlayerPrefs.GetString("Email") != "" && PlayerPrefs.GetString("Sandi") != "")
        {
            LoginAuto();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void ShowPassBtnClick()
    {
        ShowPassImgIcon.enabled = false;
        HidePassImgIcon.enabled = true;
        ShowPassImgIcon1.enabled = false;
        HidePassImgIcon1.enabled = true;
        SetPasswordContentType(PasswordLoginInput, PasswordRegisterInput, TMP_InputField.ContentType.Password);
    }
    public void HidePassBtnClick()
    {
        HidePassImgIcon.enabled = false;
        ShowPassImgIcon.enabled = true;
        HidePassImgIcon1.enabled = false;
        ShowPassImgIcon1.enabled = true;
        SetPasswordContentType(PasswordLoginInput, PasswordRegisterInput, TMP_InputField.ContentType.Standard);
    }
    private void SetPasswordContentType(TMP_InputField tmp_if1, TMP_InputField tmp_if2, TMP_InputField.ContentType contetTypePass)
    {
        tmp_if1.contentType = contetTypePass;
        tmp_if1.DeactivateInputField();
        tmp_if1.ActivateInputField();

        tmp_if2.contentType = contetTypePass;
        tmp_if2.DeactivateInputField();
        tmp_if2.ActivateInputField();
    }
    public void RegisterUser()
    {
        var request = new RegisterPlayFabUserRequest
        {
            DisplayName = UsernameInput.text,
            Email = EmailRegisterInput.text,
            Password = PasswordRegisterInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnregisterSucces, OnErrorRegister);
    }
    public void Login()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = EmailLoginInput.text,
            Password = PasswordLoginInput.text,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true
            }
          
         };
        if (rememberMe.isOn == true)
        {
            Debug.Log("Data tersimpan");
            PlayerPrefs.SetString("Email", EmailLoginInput.text);
            PlayerPrefs.SetString("Sandi", PasswordLoginInput.text);
            
        }
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSucces, OnErrorLogin);
    }
    public void LoginAuto()
    {
        Debug.Log("remember me Active");
        var request = new LoginWithEmailAddressRequest
        {
            Email = PlayerPrefs.GetString("Email"),
            Password = PlayerPrefs.GetString("Sandi"),
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true
            }

        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSucces, OnErrorLogin);
    }

    public void RecoverUser()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = EmailForgotInput.text,
            TitleId = "54C14",
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnRecoverySucces, OnErrorRecovery);
    }

    private void OnErrorRecovery(PlayFabError result)
    {
        if (EmailForgotInput.text == "")
        {
            StartCoroutine(SendNotif());
            MessageText.text = "The Email Field is Empty";
            return;
        }
        else
        {
            StartCoroutine(SendNotif());
            MessageText.text = "No Email Found";
        }
    }
    private void OnErrorLogin(PlayFabError Error)
    {
        if (EmailLoginInput.text == "")
        {
            StartCoroutine(SendNotif());
            MessageText.text = "The Email Field is Empty";
            return;
        }
        if (PasswordLoginInput.text == "")
        {
            StartCoroutine(SendNotif());
            MessageText.text = "The Password Field is Empty";
            return;
        }
        if (PasswordLoginInput.text.Length < 8)
        {
            StartCoroutine(SendNotif());
            MessageText.text = "Your password must be at least 8 character long!";
            return;
        }
        else
        {
            StartCoroutine(SendNotif());
            MessageText.text = Error.ErrorMessage;
            Debug.Log(Error.GenerateErrorReport());
        }
    }
    private void OnErrorRegister(PlayFabError Error)
    {
        if (UsernameInput.text == "")
        {

            StartCoroutine(SendNotif());
            MessageText.text = "The Username Field is Empty";
            return;
        }
        if (EmailRegisterInput.text == "")
        {
            StartCoroutine(SendNotif());
            MessageText.text = "The Email Field is Empty";
            return;
        }
        if (PasswordRegisterInput.text == "")
        {
            StartCoroutine(SendNotif());
            MessageText.text = "The Password Field is Empty";
            return;
        }
        if (PasswordRegisterInput.text.Length < 8)
        {
            StartCoroutine(SendNotif());
            MessageText.text = "Your password must be at least 8 character long!";
            return;
        }
        else
        {
            StartCoroutine(SendNotif());
            MessageText.text = Error.ErrorMessage;
            Debug.Log(Error.GenerateErrorReport());
        }
    }

    private void OnRecoverySucces(SendAccountRecoveryEmailResult obj)
    {
        EmailForgotInput.text = "";
        OpenLoginPage();
        StartCoroutine(SendNotif());
        MessageText.text = "Recovery Mail Sent";
        Debug.Log("Recovery Mail Sent");
    }

    private void OnLoginSucces(LoginResult result)
    {
        EmailLoginInput.text = "";
        PasswordLoginInput.text = "";
        
        userID = result.PlayFabId;
        string name = null;
        if(result.InfoResultPayload != null)
        {
            name = result.InfoResultPayload.PlayerProfile.DisplayName;
        }

        if(gameManager != null)
        {
            gameManager.playerName = name;
        }
        Debug.Log("Login Success");
        SceneManager.LoadScene(1);
        getUserData();
    }
    private void OnregisterSucces(RegisterPlayFabUserResult Result)
    {
        UsernameInput.text = "";
        EmailRegisterInput.text = "";
        PasswordRegisterInput.text = "";
        StartCoroutine(SendNotif());
        MessageText.text = "New Account Is Created";
        Debug.Log("New Account Is Created");
        OpenLoginPage();
    }

    public void OpenLoginPage()
    {
        LoginPage.SetActive(true);
        RegisterPage.SetActive(false);
        ForgotPasswordPage.SetActive(false);
    }

    public void OpenRegisterPage()
    {
        LoginPage.SetActive(false);
        RegisterPage.SetActive(true);
        ForgotPasswordPage.SetActive(false);
    }

    public void OpenForgotPswdPage()
    {
        LoginPage.SetActive(false);
        RegisterPage.SetActive(false);
        ForgotPasswordPage.SetActive(true);
    }
    IEnumerator SendNotif()
    {
        PopUp.SetActive(true);
        yield return new WaitForSeconds(2);
        PopUp.SetActive(false);
    }

    public void getUserData()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest()
        {
            PlayFabId = userID,
            Keys = null
        }, result =>
        {
            Debug.Log("Got user data");
            if (result.Data == null)
            {
                return;
            }
        }, error =>
        {
            Debug.Log("Not receiving data \n " + error.GenerateErrorReport());
        });
    }
}