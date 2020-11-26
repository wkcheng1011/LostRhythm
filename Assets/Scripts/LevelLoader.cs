using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public LevelLoader instance;

    public Animator transition;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void LoadScene(int buildIndex)
    {
        StartCoroutine(_LoadScene(buildIndex));
    }

    IEnumerator _LoadScene(int buildIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSecondsRealtime(1);
        SceneStack.LoadScene(buildIndex);
    }

    public void Back()
    {
        StartCoroutine(_Back());
    }

    IEnumerator _Back()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSecondsRealtime(1);
        SceneStack.Back();
    }
}
