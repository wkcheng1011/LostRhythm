using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Init : MonoBehaviour
{
    public AudioMixer _audioMixer;

    // Start is called before the first frame update
    void Start()
    {
        Setting.audioMixer = _audioMixer;
        Setting.SetVolume(PlayerPrefs.GetFloat("volume", 0.5f));
        SceneStack.Reset();
        SceneStack.LoadScene(1);
    }
}
