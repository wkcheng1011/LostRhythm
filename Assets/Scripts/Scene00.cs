using UnityEngine;

public class Scene00 : MonoBehaviour
{
    public Scene00 instance;

    public LevelLoader levelLoader;

    public TextButton NewGame;
    public TextButton Continue;
    public TextButton Settings;
    public TextButton Credits;
    public TextButton Quit;

    public AudioSource hit;

    public Setting optionMenu;

    void Awake()
    {
        NewGame.SetCallback(OnButtonClick);
        Continue.SetCallback(OnButtonClick);
        Settings.SetCallback(OnButtonClick);
        Credits.SetCallback(OnButtonClick);
        Quit.SetCallback(OnButtonClick);

        Continue.interactable = SessionData.SaveFileExist;
    }

    public void OnButtonClick(TextButton button)
    {
        hit.Play();
        switch (button.name)
        {
            case "NewGame":
                levelLoader.LoadScene(3);
                break;
            case "Continue":
                break;
            case "Settings":
                optionMenu.active = true;
                break;
            case "Credits":
                break;
            case "Quit":
                levelLoader.Back();
                break;
            default:
                break;
        }
    }
}
