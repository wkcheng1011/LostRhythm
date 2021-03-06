﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    private static GameObject character, optionMenu;
    public static int diceSideThrown = 0;
    public static int playerStartWayPoint = 0;
    public Dialog dialog1, dialog2;
    public bool condition1 = true, condition2 = true, conditionForDialog1 = true, conditionForDialog2 = false;
    public Button continueButton;

    void Start()
    {
        dialog1.CallDialog();
        character = GameObject.Find("Character");
        optionMenu = GameObject.Find("OptionMenu");
        optionMenu.SetActive(false);
        character.GetComponent<Move>().moveAllowed = false;

        continueButton.onClick.AddListener(DialogContinue);
    }
    void DialogContinue()
    {
        if (conditionForDialog1) { dialog1.NextSentence(); }
        if (conditionForDialog2) { dialog2.NextSentence(); }
    }

    void Event()
    {
        character.GetComponent<Move>().moveAllowed = false;
        diceSideThrown = 0;
    }
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Escape) && Dialog.dialogEnd)
        {
            optionMenu.SetActive(true);
            Time.timeScale = 0;
        }

        if (character.GetComponent<Move>().waypointIndex > playerStartWayPoint + diceSideThrown)
        {
            character.GetComponent<Move>().moveAllowed = false;
            playerStartWayPoint = character.GetComponent<Move>().waypointIndex - 1;
        }

        if (character.GetComponent<Move>().waypointIndex == 4 && condition1)
        {
            conditionForDialog2 = true;
            conditionForDialog1 = false;
            dialog2.CallDialog();
            Event(); condition1 = false;
            GameObject.Find("Sword").SetActive(false);
        }


        if (character.GetComponent<Move>().waypointIndex == 7 && condition2)
        {
            Event(); condition2 = false;
            GameObject.Find("Monster").SetActive(false);
            SceneManager.LoadScene(5);
        }
    }

    public static void MovePlayer()
    {
        character.GetComponent<Move>().moveAllowed = true;
    }
}
