﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Init : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Session.saveFileExist = SaveFileManager.Check(false);
        SceneStack.LoadScene("Scene00_Main");
    }
}
