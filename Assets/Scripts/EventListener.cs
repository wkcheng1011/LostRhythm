using UnityEngine;

public class EventListener : MonoBehaviour
{
    public LevelLoader levelLoader;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameObject.scene.buildIndex < 5) {
                levelLoader.Back();
            } else if (gameObject.scene.buildIndex == 7)
            {
                levelLoader.LoadScene(5);
            }
        }
    }
}
