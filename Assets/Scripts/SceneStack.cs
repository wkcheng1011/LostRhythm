using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneStack {
    private static Stack<string> sceneIndice = new Stack<string>();

    public static void LoadScene(string sceneName)
    {
        sceneIndice.Push(sceneName);
        SceneManager.LoadScene(sceneName);
    }

    public static void Back()
    {
        if (sceneIndice.Count <= 1)
        {
            Application.Quit();
        }
        else
        {
            sceneIndice.Pop();
            string sceneName = sceneIndice.Peek();
            SceneManager.LoadScene(sceneName);
        }
    }

    public static void Reset()
    {
        sceneIndice.Clear();
    }
}
