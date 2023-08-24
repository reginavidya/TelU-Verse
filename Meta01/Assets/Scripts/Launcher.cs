using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;

public class Launcher : MonoBehaviour
{
    public static Launcher Instance;
    [SerializeField] TMP_Text errorText;
    [SerializeField] GameObject startGameButton;
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject rowPrefab;
    [SerializeField] Transform rowsParent;
    [SerializeField] GameObject leaderboard;
    [SerializeField] GameObject mode;
    int sceneIndex;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(sceneIndex - 1);
        }
    }
    public void StartGame()
    {
        mode.SetActive(true);
        Debug.Log("Pilih Mode");
    }

    public void Back()
    {
        MenuManager.Instance.OpenMenu("title");
    }

    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "PlatformScore",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }

    void OnLeaderboardGet(GetLeaderboardResult result)
    {
        foreach(Transform item in rowsParent)
        {
            Destroy(item.gameObject);
        }

        foreach(var item in result.Leaderboard)
        {
            GameObject newGO = Instantiate(rowPrefab, rowsParent);
            Text[] texts = newGO.GetComponentsInChildren<Text>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();
        }
        Debug.Log("Leaderboard All Player");
    }

    public void GetLeaderboardAroundPlayer()
    {
        var request = new GetLeaderboardAroundPlayerRequest
        {
            StatisticName = "PlatformScore",
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, OnLeaderboardAroundPlayerGet, OnError);
    }

    void OnLeaderboardAroundPlayerGet(GetLeaderboardAroundPlayerResult result)
    {
        foreach (Transform item in rowsParent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in result.Leaderboard)
        {
            GameObject newGO = Instantiate(rowPrefab, rowsParent);
            Text[] texts = newGO.GetComponentsInChildren<Text>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();

            if (item.PlayFabId == LoginValidation.userID)
            {
                texts[0].color = Color.cyan;
                texts[1].color = Color.cyan;
                texts[2].color = Color.cyan;
            }
        }
        Debug.Log("Leaderboard Around Player");
    }

    private void OnError(PlayFabError Error)
    {
        Debug.Log(Error.GenerateErrorReport());
    }
}
