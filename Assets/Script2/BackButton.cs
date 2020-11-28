using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{

    public Button backButton;
    public GameObject optionMenu;
    // Start is called before the first frame update
    void Start()
    {
        backButton.onClick.AddListener(Test);

    }

    void Test() {
        Time.timeScale = 1;
        optionMenu.SetActive(false);

    }

}
