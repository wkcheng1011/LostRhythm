using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingScript : MonoBehaviour
{
    public AudioMixer AudioMixer;
    public Dropdown resolutionDropdown;
    Resolution[] resolutions;
    public GameObject fullscreenToggle;

    public void SetVolume(float volume)
    {
        AudioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
    }

    private void Start()
    {
        fullscreenToggle.GetComponent<Toggle>().isOn = Screen.fullScreen;
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = PlayerPrefs.GetInt("Resolution", 0);

        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int index)
    {
        Resolution resolution = resolutions[index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool condition)
    {
        Screen.fullScreen = condition;
    }

    public void OnSave()
    {
        gameObject.SetActive(false);
    }

    public void OnCancel()
    {
        gameObject.SetActive(false);
    }
}
