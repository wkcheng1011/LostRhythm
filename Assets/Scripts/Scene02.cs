using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene02 : MonoBehaviour
{
    public Scene02 instance;
    public LevelLoader levelLoader;
    public TextButton BackToMenu;
    // Start is called before the first frame update
    void Awake()
    {
        BackToMenu.SetCallback(OnButtonClick);
    }

    // Update is called once per frame
    public void OnButtonClick(TextButton button)
    {
        levelLoader.LoadScene(1);
    }
}
