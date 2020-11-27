using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class settingScript : MonoBehaviour
{
    public AudioMixer AudioMixer;
    public Dropdown resolution;
    Resolution[] resolutions;
    GameObject fullscreenToggle;


    public void SetVolume(float volume) {
        AudioMixer.SetFloat("volume",volume);
    }

    private void Start()
    {
        fullscreenToggle = GameObject.Find("FullScreen");
        fullscreenToggle.GetComponent<Toggle>().isOn = Screen.fullScreen;
        resolutions = Screen.resolutions;
        resolution.ClearOptions();
        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++) {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

        }
        resolution.AddOptions(options);
        if (PlayerPrefs.HasKey("Resolution")) resolution.value = PlayerPrefs.GetInt("Resolution");
        else resolution.value = 0;
        resolution.RefreshShownValue();
        
        
    }
    public void SetResolution(int index) {
        
        Resolution resolution = resolutions[index];
        Screen.SetResolution(resolution.width, resolution.height,Screen.fullScreen);
        PlayerPrefs.SetInt("Resolution", index);
    }
    public void SetQuality(int qualityIndex) {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool condition) {
        Screen.fullScreen = condition;
    }
}
