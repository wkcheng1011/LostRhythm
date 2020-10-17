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

    bool saveFileExist = false;

    // Start is called before the first frame update
    void Start()
    {
        NewGame.GetComponent<TextButton>().setParent(this);
        Continue.GetComponent<TextButton>().setParent(this);
        Settings.GetComponent<TextButton>().setParent(this);
        Credits.GetComponent<TextButton>().setParent(this);
        Quit.GetComponent<TextButton>().setParent(this);

        Continue.GetComponent<Button>().interactable = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onButtonClick(TextButton button)
    {
        Debug.Log("Clicked " + button.name);
        switch (button.name)
        {
            case "NewGame":
                SceneManager.LoadScene("Scene10_SelectChar");
                break;
            case "Continue":
                break;
            case "Settings":
                SceneManager.LoadScene("Scene01_Settings");
                break;
            case "Credits":
                SceneManager.LoadScene("Scene02_Credits");
                break;
            case "Quit":
                Application.Quit();
                break;
            default:
                break;
        }
    }
}
