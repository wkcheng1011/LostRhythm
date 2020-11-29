using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene41 : MonoBehaviour
{
    // Start is called before the first frame update
    public Text[] comboTexts;
    public Text rating;
    public AudioSource pass, fail;

    public LevelLoader levelLoader;

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            comboTexts[i].text = PlayerData.noteHit[i].ToString() + "x / " + PlayerData.noteTotal[i].ToString() + "x";
        }

        if (PlayerData.isPass)
        {
            rating.text = "Pass";
            pass.Play();
        } else
        {
            rating.text = "Fail";
            fail.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            levelLoader.LoadScene(6);
        }
    }
}
