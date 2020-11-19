using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene00 : MonoBehaviour
{
    public GameObject NewGame;
    public GameObject Continue;
    public GameObject Settings;
    public GameObject Credits;
    public GameObject Quit;

    void Awake()
    {
        NewGame.GetComponent<TextButton>().SetParent(this);
        Continue.GetComponent<TextButton>().SetParent(this);
        Settings.GetComponent<TextButton>().SetParent(this);
        Credits.GetComponent<TextButton>().SetParent(this);
        Quit.GetComponent<TextButton>().SetParent(this);

        Continue.GetComponent<Button>().interactable = SessionData.SaveFileExist;
    }

    public void OnButtonClick(TextButton button)
    {
        switch (button.name)
        {
            case "NewGame":
                SceneStack.LoadScene("Scene40_Rhythm");
                break;
            case "Continue":
                break;
            case "Settings":
                SceneStack.LoadScene("Scene01_Settings");
                break;
            case "Credits":
                SceneStack.LoadScene("Scene02_Credits");
                break;
            case "Quit":
                Application.Quit();
                break;
            default:
                break;
        }
    }
}
