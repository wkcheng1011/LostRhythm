using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TextButton : MonoBehaviour
{
    private Scene00 parent;

    public void SetParent(Scene00 p)
    {
        parent = p;
    }

    public void OnClick()
    {
        parent.OnButtonClick(this);
    }
}
