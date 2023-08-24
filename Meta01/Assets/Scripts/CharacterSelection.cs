/*using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;
using Newtonsoft.Json;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characters;
    private int selectedCharacter;

    public PlayerBlueprint[] players;
    public Button buyButton;
    public Button playButton;

    public Text coinsValueText;
    private int coins;
    private int cash;
    public TMP_Text priceAvatar;

    void Start()
    {
        GetDataUser();
        UpdateUI();
        GetVirtualCurrencies();
        selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        characters = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            characters[i] = transform.GetChild(i).gameObject;
        }

        foreach (GameObject go in characters)
        {
            go.SetActive(false);
        }

        if (characters[selectedCharacter])
        {
            characters[selectedCharacter].SetActive(true);
        }

        foreach (PlayerBlueprint player in players)
        {
            if (player.price == 0 || player.isUnlocked == true)
            {
                player.isUnlocked = true;
            }
            else
            {
                player.isUnlocked = false;
            }
        }
    }

    void Update()
    {
        UpdateUI();
        GetDataUser();
    }

    public void NextCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
    }

    public void PreviousCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter = characters.Length - 1;
        }
        characters[selectedCharacter].SetActive(true);
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
    }

    public void StartGame()
    {
        SaveAppearance();
        GetAppearance();
        SceneManager.LoadScene(3);
        Debug.Log("avatar has been selected");
    }

    public void GetAppearance()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataReceived, OnError);
    }

    void OnDataReceived(GetUserDataResult result)
    {
        Debug.Log("Received user data");
    }

    public void SaveAppearance()
    {
        var request = new UpdateUserDataRequest()
        {
            Data = new Dictionary<string, string>
            {
                {"ID", characters[selectedCharacter].name}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
    }

    void OnDataSend(UpdateUserDataResult result)
    {
        Debug.Log("Successfull user data send");
    }

    private void OnError(PlayFabError Error)
    {
        Debug.Log(Error.GenerateErrorReport());
    }

    public void Back()
    {
        SceneManager.LoadScene(1);
    }

    public void GetVirtualCurrencies()
    {
        PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(), OnGetUserInventorySuccess, OnError);
    }

    void OnGetUserInventorySuccess(GetUserInventoryResult result)
    {
        coins = result.VirtualCurrency["CN"];
        coinsValueText.text = "Coins: " + coins.ToString();
    }

    public void SaveCharacters1()
    {
        List<PlayerBlueprint> characters = new List<PlayerBlueprint>();
        PlayerBlueprint player = players[selectedCharacter];
        bool unplayer = player.isUnlocked;
        unplayer = true;
        PlayerPrefs.SetString("unlock", unplayer.ToString());
        PlayerPrefs.SetString("nama", player.names);
        Unlock1();
        foreach (var item in players)
        {
            characters.Add(item.ReturnClass());
        }
        var request = new UpdateUserDataRequest()
        {
            Data = new Dictionary<string, string>
            {
                {"Characters", JsonConvert.SerializeObject(characters)}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);

    }
    
    void Unlock1()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), GetData, OnError);
    }
    void GetData(GetUserDataResult result)
    {
        string dataUnlock1 = PlayerPrefs.GetString("unlock");
        string nama1 = PlayerPrefs.GetString("nama");
        var request = new UpdateUserDataRequest()
        {

            Data = new Dictionary<string, string>
                {
                    { "unlock1", dataUnlock1 },
                     {"nama1",nama1 }
                }
        };
        PlayFabClientAPI.UpdateUserData(request, OnKirimData, OnError);
    }
    void GetDataUser()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), GetAllData, OnError);

    }
    void GetAllData(GetUserDataResult result)
    {
        Debug.Log("sukses ambil data");
        UpdateDataUser();
    }
    void OnKirimData(UpdateUserDataResult result)
    {
        Debug.Log("data sudah terkirim");
    }

    public void UnlockPlayer()
    {
        GrantVirtualCurrency();
        SaveCharacters1();
    }
 
    void GrantVirtualCurrency()
    {
        PlayerBlueprint player = players[selectedCharacter];
        if (player.names == characters[selectedCharacter].name)
        {
            buyButton.gameObject.SetActive(false);
            player.isUnlocked = true;
        }
        cash = coins - player.price;
        Debug.Log("Remaining: " + cash);
        coinsValueText.text = "Coins: " + cash.ToString();

        var request = new SubtractUserVirtualCurrencyRequest
        {
            VirtualCurrency = "CN",
            Amount = player.price
        };
        PlayFabClientAPI.SubtractUserVirtualCurrency(request, OnGrantVirtualCurrencySuccess, OnError);
    }
  
    void OnGrantVirtualCurrencySuccess(ModifyUserVirtualCurrencyResult result)
    {
        Debug.Log("Currency Granted!");
        GetVirtualCurrencies();
    }

    void UpdateDataUser()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), TerimaData, OnError);
        Debug.Log("update data");

    }
    void TerimaData(GetUserDataResult result)
    {
        Debug.Log("cek data");
       *//* PlayerBlueprint player = players[selectedCharacter];
        if (result.Data["unlock1"].Value != "True" && result.Data["nama1"].Value != "cewek 1" || result.Data["nama1"].Value != "cowok1")
        {
            buyButton.interactable = true;
            playButton.interactable = false;
        }
        else if(result.Data["unlock1"].Value == "True" && result.Data["nama1"].Value == "cewek 1" || result.Data["nama1"].Value != "cowok1")
        {
            if (player.names == result.Data["nama1"].Value)
            {
                buyButton.gameObject.SetActive(false);
                playButton.interactable = true;
                buyButton.interactable = false;
            }
        }
        else if (result.Data["unlock1"].Value == "True" && result.Data["nama1"].Value != "cewek 1" || result.Data["nama1"].Value == "cowok1")
        {
            
            if(player.names == result.Data["nama1"].Value)
            {
                buyButton.gameObject.SetActive(false);
                playButton.interactable = true;
                buyButton.interactable = false;
            }
        }*//*
    }

    public void UpdateUI()
    {
        PlayerBlueprint player = players[selectedCharacter];
        priceAvatar.text = "Buy " + player.price.ToString();
        if (player.isUnlocked)
        {
            buyButton.gameObject.SetActive(false);
            playButton.interactable = true;
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            if (player.price <= coins)
            {
                buyButton.interactable = true;
            }
            else
            {
                buyButton.interactable = false;
                playButton.interactable = false;
            }
        }
    }
}*/
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;
using Newtonsoft.Json;


public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characters;
    private int selectedCharacter;

    public PlayerBlueprint[] players;
    public Button buyButton;
    public Button playButton;

    public Text coinsValueText;
    private int coins;
    private int cash;
    public TMP_Text priceAvatar;
    int sceneIndex;

    void Start()
    {
        GetVirtualCurrencies();
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        characters = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            characters[i] = transform.GetChild(i).gameObject;
        }

        foreach (GameObject go in characters)
        {
            go.SetActive(false);
        }

        if (characters[selectedCharacter])
        {
            characters[selectedCharacter].SetActive(true);
        }

        foreach (PlayerBlueprint player in players)
        {
            if (player.price == 0 || player.isUnlocked == true)
            {
                player.isUnlocked = true;
            }
            else
            {
                player.isUnlocked = false;
            }
        }
    }

    void Update()
    {
        UpdateUI();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(sceneIndex - 1);
        }
    }

    public void NextCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
    }

    public void PreviousCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter = characters.Length - 1;
        }
        characters[selectedCharacter].SetActive(true);
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
    }

    public void StartGame()
    {
        SaveAppearance();
        GetAppearance();
        SceneManager.LoadScene(3);
        Debug.Log("avatar has been selected");
    }

    public void GetAppearance()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataReceived, OnError);
    }

    void OnDataReceived(GetUserDataResult result)
    {
        Debug.Log("Received user data");
    }

    public void SaveAppearance()
    {
        var request = new UpdateUserDataRequest()
        {
            Data = new Dictionary<string, string>
            {
                {"ID", characters[selectedCharacter].name}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
    }

    void OnDataSend(UpdateUserDataResult result)
    {
        Debug.Log("Successfull user data send");
    }

    private void OnError(PlayFabError Error)
    {
        Debug.Log(Error.GenerateErrorReport());
    }

    public void Back()
    {
        SceneManager.LoadScene(1);
    }

    public void GetVirtualCurrencies()
    {
        PlayFabClientAPI.GetUserInventory(new GetUserInventoryRequest(), OnGetUserInventorySuccess, OnError);
    }

    void OnGetUserInventorySuccess(GetUserInventoryResult result)
    {
        coins = result.VirtualCurrency["CN"];
        coinsValueText.text = "Coins: " + coins.ToString();
    }

    public void SaveCharacters()
    {
        List<PlayerBlueprint> characters = new List<PlayerBlueprint>();
        PlayerBlueprint player = players[selectedCharacter];
        player.isUnlocked = true;
        foreach (var item in players)
        {
            characters.Add(item.ReturnClass());
        }
        var request = new UpdateUserDataRequest()
        {
            Data = new Dictionary<string, string>
            {
                {"Characters", JsonConvert.SerializeObject(characters)}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);

    }
    public void UnlockPlayer()
    {
        GrantVirtualCurrency();
        SaveCharacters();
    }

    void GrantVirtualCurrency()
    {
        PlayerBlueprint player = players[selectedCharacter];
        if (player.names == characters[selectedCharacter].name)
        {
            buyButton.gameObject.SetActive(false);
            player.isUnlocked = true;
        }
        cash = coins - player.price;
        Debug.Log("Remaining: " + cash);
        coinsValueText.text = "Coins: " + cash.ToString();

        var request = new SubtractUserVirtualCurrencyRequest
        {
            VirtualCurrency = "CN",
            Amount = player.price
        };
        PlayFabClientAPI.SubtractUserVirtualCurrency(request, OnGrantVirtualCurrencySuccess, OnError);
    }

    void OnGrantVirtualCurrencySuccess(ModifyUserVirtualCurrencyResult result)
    {
        Debug.Log("Currency Granted!");
        GetVirtualCurrencies();
    }

    public void UpdateUI()
    {
        PlayerBlueprint player = players[selectedCharacter];
        priceAvatar.text = "Buy " + player.price.ToString();
        if (player.isUnlocked)
        {
            buyButton.gameObject.SetActive(false);
            playButton.interactable = true;
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            if (player.price <= coins)
            {
                buyButton.interactable = true;
            }
            else
            {
                buyButton.interactable = false;
                playButton.interactable = false;
            }
        }
    }
}