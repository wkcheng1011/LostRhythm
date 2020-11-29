using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    public Pausable parent;
    
    public PauseScreen instance;

    public TextButton btnContinue;
    public TextButton btnSettings;
    public TextButton btnQuit;

    public Setting setting;

    public bool active
    {
        get {
            return gameObject.activeSelf;
        }
        set
        {
            gameObject.SetActive(value);
        }
    }
    public void OnButtonClick(TextButton button)
    {
        switch (button.name)
        {
            case "Continue":
                StartCoroutine(parent.Resume());

                setting.active = false;
                active = false;
                break;
            case "Settings":
                setting.active = true;
                break;
            case "Quit":
                parent.Finish();
                break;
            default:
                break;
        }
    }
}
