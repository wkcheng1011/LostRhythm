using UnityEngine;

public class EventListener : MonoBehaviour
{
    public LevelLoader levelLoader;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            levelLoader.Back();
        }
    }
}
