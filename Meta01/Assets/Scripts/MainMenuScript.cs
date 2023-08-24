using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tentangPage;
    public GameObject backKembali;
    public GameObject mainMenu;
    public GameObject keluarApk;
    public GameObject halamanAbout;
    public GameObject halamanHelp;
    public GameObject infoTask;
    public GameObject arVR;
    public GameObject arRadius;
    public GameObject helpAR;
    public GameObject helpVR;
    public GameObject vrLagi;
    public GameObject backARVR;
    public GameObject BackMenu;
    public GameObject popUp;
    public GameObject cLose;
    public GameObject copiedLink;
    public GameObject popUpClose;
    public GameObject arPanel;
    public GameObject mode;
    public TMP_Text koin;
    public TMP_Text username;
    public Button logout;
    public Button ok;
    public Button cancel;
    public Button backMode; 
    int coins;
    string nama;
    string PlayFabId;
    public void Start()
    {
        backMode.onClick.AddListener(() =>
        {
            mode.SetActive(false);
        });
        logout.onClick.AddListener(() =>
        {
            popUpClose.SetActive(true);

        });
        ok.onClick.AddListener(() =>
        {
            PlayFabClientAPI.ForgetAllCredentials();
            Debug.Log("Logout Account");
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene(0);
        });

        cancel.onClick.AddListener(() =>
        {
            popUpClose.SetActive(false);
        });
        GetVirtualCurrencies();
        GetPlayerProfile(PlayFabId);

       
    }
    void GetVirtualCurrencies()
    {
        PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(), OnGetUserInventorySuccess, OnError);
    }

    void OnGetUserInventorySuccess(GetUserInventoryResult result)
    {
        coins = result.VirtualCurrency["CN"];
        koin.text = coins.ToString();
    }
    void GetPlayerProfile(string playFabId)
    {
        PlayFabClientAPI.GetPlayerProfile(new GetPlayerProfileRequest()
        {
            PlayFabId = playFabId,
            ProfileConstraints = new PlayerProfileViewConstraints()
            {
                ShowDisplayName = true
            }
        },
       DisplayName, OnError);
    }
    void DisplayName(GetPlayerProfileResult result)
    {
        nama = result.PlayerProfile.DisplayName;
        username.text = nama;
    }
    void OnError(PlayFabError error)
    {
        Debug.Log("Error: " + error.ErrorMessage);
    }
    public void MulaiGame()
    {
        SceneManager.LoadScene(2);
    }
    public void Back()
    {
        tentangPage.SetActive(false);
        backKembali.SetActive(true);

    }
    public void About()
    {
        tentangPage.SetActive(true);
        backKembali.SetActive(false);
        Debug.Log("Open About");
    }

    public void Help()
    {
        halamanHelp.SetActive(true);
        helpAR.SetActive(false);
        Debug.Log("Open Help");
    }

    public void Info()
    {
        halamanHelp.SetActive(false);
        infoTask.SetActive(true);
    }

    public void Contoh()
    {
        infoTask.SetActive(false);
        arVR.SetActive(true);
    }

    public void BackMainMenu()
    {
        arVR.SetActive(false);
        backKembali.SetActive(true);

    }

    public void Ar()
    {
        arVR.SetActive(false);
        helpAR.SetActive(true);
    }

    public void Selanjutnya()
    {
        helpAR.SetActive(false);
        arRadius.SetActive(true);
    }

    public void Radius()
    {
        arRadius.SetActive(false);
        arPanel.SetActive(true);
    }

    public void LanjutVR()
    {
        arPanel.SetActive(false);
        arVR.SetActive(true);
    }

    public void Vr()
    {
        arVR.SetActive(false);
        helpVR.SetActive(true);
    }

    public void Close()
    {
        helpVR.SetActive(false);
        arVR.SetActive(true);
    }

    public void PopUP()
    {
        helpVR.SetActive(false);
        popUp.SetActive(true);
    }

    public void Copied()
    {
        helpVR.SetActive(false);
        copiedLink.SetActive(true);
    }

    public void ClosePopup()
    {
        copiedLink.SetActive(false);
        arVR.SetActive(true);
    }

    public void VrLagi()
    {
        popUp.SetActive(false);
        vrLagi.SetActive(true);
    }

    public void BackARVR()
    {
        vrLagi.SetActive(false);
        arVR.SetActive(true);
    }
    public void GPSMode()
    {
        SceneManager.LoadScene(2);
        Debug.Log("masuk mode GPS");
    }
    public void NoGPSMode()
    {
        SceneManager.LoadScene(4);
        Debug.Log("Masuk mode explore");
    }
    public void BackMode()
    {
        mode.SetActive(false);
    }
}
