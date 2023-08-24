using System.Collections;
using System.Collections.Generic;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class DailyReward1 : MonoBehaviour
{
    [Header("UI MAP")]
    [SerializeField] private Button rewardBtn;
    [SerializeField] private TMP_Text koinMapText;

    [Header("UI REWARD")]
    [SerializeField] private Button claimBtn;
    [SerializeField] private TMP_Text claimBtnText;
    [SerializeField] public GameObject gomapUI;
    [SerializeField] public GameObject pickerWheelUI;
    [SerializeField] private Button backBtn;

    int coins;
    public int lastDate;
    string PlayFabId;
    void Start()
    {
        GetVirtualCurrencies();
        OnTime(PlayFabId);
        GetAppearance();
        GetDataUser();
        claimBtn.onClick.AddListener(() =>
        {
            GrantVirtualCurrency();
            Debug.Log("Claim Coins");
            claimBtnText.text = "Claimed";
            claimBtn.interactable = false;
            rewardBtn.interactable = false;
            UpdateData(PlayFabId);

        });
        backBtn.onClick.AddListener(() =>
        {
            gomapUI.SetActive(true);
            pickerWheelUI.SetActive(false);
        });
        rewardBtn.onClick.AddListener(() =>
        {
            gomapUI.SetActive(false);
            pickerWheelUI.SetActive(true);

        });
    }
    void GetVirtualCurrencies()
    {
        PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(), OnGetUserInventorySuccess, OnError);
    }

    void OnGetUserInventorySuccess(GetUserInventoryResult result)
    {
        coins = result.VirtualCurrency["CN"];
        koinMapText.text = coins.ToString();
        SendLeaderboard(coins);
    }

    void GrantVirtualCurrency()
    {
        var request = new AddUserVirtualCurrencyRequest
        {
            VirtualCurrency = "CN",
            Amount = 5
        };
        PlayFabClientAPI.AddUserVirtualCurrency(request, OnGrantVirtualCurrencySuccess, OnError);
    }

    void OnGrantVirtualCurrencySuccess(ModifyUserVirtualCurrencyResult result)
    {
        Debug.Log("Currency Granted!");
        GetVirtualCurrencies();
    }

    void SendLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "PlatformScore",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Successfull leaderboard sent");
    }
    void OnError(PlayFabError error)
    {
        Debug.Log("Error: " + error.ErrorMessage);
    }
    void OnTime(string playFabId)
    {
        PlayFabClientAPI.GetPlayerProfile(new GetPlayerProfileRequest()
        {
            PlayFabId = playFabId,
            ProfileConstraints = new PlayerProfileViewConstraints
            {
                ShowDisplayName = true,
                ShowCreated = true,
                ShowLastLogin = true
            }

        },
       OnSuccess,
        OnError);
    }

    void OnSuccess(GetPlayerProfileResult result)
    {
        DateTime timeLogin = (DateTime)result.PlayerProfile.LastLogin;
        lastDate = timeLogin.Day;
        string time = lastDate.ToString();
        var request = new UpdateUserDataRequest()
        {
            Data = new Dictionary<string, string>
            {
                { "waktu", time }
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnKirimData, OnError);
    }
    public void Back()
    {
        SceneManager.LoadScene(1);
    }

    void UpdateData(string playFabId)
    {
        PlayFabClientAPI.GetPlayerProfile(new GetPlayerProfileRequest()
        {
            PlayFabId = playFabId,
            ProfileConstraints = new PlayerProfileViewConstraints
            {
                ShowDisplayName = true,
                ShowCreated = true,
                ShowLastLogin = true
            }

        },
        SaveData, OnError);
    }
    void SaveData(GetPlayerProfileResult result)
    {
        DateTime timeLogin = (DateTime)result.PlayerProfile.LastLogin;
        lastDate = timeLogin.Day;
        string date = lastDate.ToString();
        var request = new UpdateUserDataRequest()
        {

            Data = new Dictionary<string, string>
            {
                { "reward", date }
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnKirimData, OnError);
    }
    void OnKirimData(UpdateUserDataResult result)
    {
        Debug.Log("data sudah terkirim");
    }
    void GetAppearance()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataReceived, OnError);

    }
    void GetDataUser()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), GetData, OnError);

    }
    void GetData(GetUserDataResult result)
    {
        Debug.Log("sukses ambil data");
        UpdateDataUser();
    }
    void UpdateDataUser()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), UpdateData, OnError);

    }
    void UpdateData(GetUserDataResult result)
    {
        Debug.Log("sukses upate data");
        if (result.Data["reward"].Value != result.Data["waktu"].Value)
        {
            Debug.Log("REWARD AKTIF");
            rewardBtn.interactable = true;
            claimBtn.interactable = true;
        }
        else
        {
            Debug.Log("REWARD TIDAK AKTIF");
            rewardBtn.interactable = false;
            claimBtn.interactable = false;
        }
    }
    void OnDataReceived(GetUserDataResult result)
    {
        if (!result.Data.ContainsKey("reward") && !result.Data.ContainsKey("waktu"))
        {
            var request = new UpdateUserDataRequest()
            {

                Data = new Dictionary<string, string>
                {
                    { "reward", "32" },
                    { "waktu", "32" }
                }
            };
            PlayFabClientAPI.UpdateUserData(request, OnKirimData, OnError);
            Debug.Log("sukses buat id reward dan time");
        }
        else if (!result.Data.ContainsKey("reward"))
        {
            var request = new UpdateUserDataRequest()
            {
                Data = new Dictionary<string, string>
                {
                    { "reward", "32" }
                }
            };
            PlayFabClientAPI.UpdateUserData(request, OnKirimData, OnError);
            Debug.Log("sukses buat id reward dan time");
        }
        else if (!result.Data.ContainsKey("waktu"))
        {
            var request = new UpdateUserDataRequest()
            {

                Data = new Dictionary<string, string>
                {
                    { "waktu", "32" }
                }
            };
            PlayFabClientAPI.UpdateUserData(request, OnKirimData, OnError);
            Debug.Log("sukses buat id reward dan time");
        }

        GetDataUser();
    }
}
