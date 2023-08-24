using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;
using Newtonsoft.Json;

public class CharactersMap : MonoBehaviour
{
    public GameObject[] characters;
    private int selectedCharacter;

    void Start()
    {
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
    }

    public void GetAppearance()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataReceived, OnError);
    }

    void OnDataReceived(GetUserDataResult result)
    {
        Debug.Log("Received user data");
    }

    private void OnError(PlayFabError Error)
    {
        Debug.Log(Error.GenerateErrorReport());
    }

    public void Back()
    {
        SceneManager.LoadScene(1);
    }
    public void OnAnimationStateChange(MoveAvatar.AvatarAnimationState animationState)
    {

        switch (animationState)
        {

            case MoveAvatar.AvatarAnimationState.Walk:
            case MoveAvatar.AvatarAnimationState.Run:
                characters[selectedCharacter].GetComponent<Animator>().SetBool("isMoving", true);
                break;
            case MoveAvatar.AvatarAnimationState.Idle:
                characters[selectedCharacter].GetComponent<Animator>().SetBool("isMoving", false);
                break;

        }

    }
}
