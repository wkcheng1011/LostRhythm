using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene50 : MonoBehaviour
{
    public LevelLoader levelLoader;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            levelLoader.LoadScene(0);
        }
    }
}
