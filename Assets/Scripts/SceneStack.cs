using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneStack {
    private static Stack<int> sceneIndice = new Stack<int>();

    public static void LoadScene(int buildIndex)
    {
        sceneIndice.Push(buildIndex);
        SceneManager.LoadScene(buildIndex);
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
            int buildIndex = sceneIndice.Peek();
            SceneManager.LoadScene(buildIndex);
        }
    }

    public static void Reset()
    {
        sceneIndice.Clear();
    }
}
