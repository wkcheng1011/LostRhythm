using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    public Scene40 parent;
    
    public PauseScreen instance;

    public TextButton btnContinue;
    public TextButton btnSettings;
    public TextButton btnQuit;

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
    // Start is called before the first frame update
    void Start()
    {
        active = false;

        btnContinue.SetCallback(OnButtonClick);
        btnSettings.SetCallback(OnButtonClick);
        btnQuit.SetCallback(OnButtonClick);
    }

    public void OnButtonClick(TextButton button)
    {
        switch (button.name)
        {
            case "Continue":
                StartCoroutine(parent.Resume());
                break;
            case "Settings":
            case "Quit":
                parent.Finish();
                break;
            default:
                break;
        }
    }
}
