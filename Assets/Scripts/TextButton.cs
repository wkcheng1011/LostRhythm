using System;
using UnityEngine;
using UnityEngine.UI;

public class TextButton : MonoBehaviour
{
    private Action<TextButton> callback;

    public void SetCallback(Action<TextButton> action)
    {
        callback = action;
    }

    public void OnClick()
    {
        callback(this);
    }

    public bool interactable
    {
        get
        {
            return gameObject.GetComponent<Button>().interactable;
        }
        set
        {
            gameObject.GetComponent<Button>().interactable = value;
        }
    }
}
