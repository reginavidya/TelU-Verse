using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UrlButton : MonoBehaviour
{
    public GameObject popUpDamar;
    public GameObject popUpGKU;
    public GameObject keluarPopUp;
    public TMP_Text copiedDamar;
    public TMP_Text copiedGKU;
    public GameObject keluar;

    public void Tutup()
    {
        keluar.SetActive(false);
    }
    public void Keluar()
    {
        SceneManager.LoadScene(1);
    }
    public void KeluarGKU()
    {
        popUpGKU.SetActive(false);
        keluarPopUp.SetActive(true);

    }

    public void KeluarDamar()
    {
        popUpDamar.SetActive(false);
        keluarPopUp.SetActive(true);

    }

    public void OpenURLGKU()
    {
        Application.OpenURL("https://hubs.mozilla.com/LUJKN8b/lobby-gku");
        Debug.Log("is this working");
    }

    public void CopyGKU()
    {
        popUpGKU.SetActive(true);
        GUIUtility.systemCopyBuffer = "https://hubs.mozilla.com/LUJKN8b/lobby-gku";
        copiedGKU.text = "Copied!";
    }
    public void OpenURLDamar()
    {
        Application.OpenURL("https://hubs.mozilla.com/mtiH4n9/gedung-damar");
        Debug.Log("Open Damar");
    }

    public void CopyDamar()
    {
        popUpDamar.SetActive(true);
        GUIUtility.systemCopyBuffer = "https://hubs.mozilla.com/mtiH4n9/gedung-damar";
        copiedDamar.text = "Copied!";
        Debug.Log("Copied");
    }
}
