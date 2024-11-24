using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    [SerializeField] private Toggle volumeToggle;

    bool isVolumeOpen;

    // Ayar kaydetme yönetemleri
    // PlayerPrefs - Settings
    // Custom save system

    private void Start()
    {
        if (PlayerPrefs.HasKey("isVolumeOn"))
        {
            int iOn = PlayerPrefs.GetInt("isVolumeOn");
            bool isOn = Convert.ToBoolean(iOn);

            volumeToggle.isOn = isOn;
        }
    }

    public void VolumeChanged()
    {
        isVolumeOpen = volumeToggle.isOn;
        Debug.Log(isVolumeOpen);


        int isOn = Convert.ToInt32(isVolumeOpen);

        PlayerPrefs.SetInt("isVolumeOn", isOn);
    }

    public void PlayClick()
    {
        SceneManager.LoadScene(1);

    }


    public void ExitClick()
    {
        // Editörde çalışmaz. Yalnızca build alındığında çalışır
        Application.Quit();

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif

    }

}
