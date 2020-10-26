using UnityEngine;

public class EventListener : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneStack.Back();
        }
    }
}
