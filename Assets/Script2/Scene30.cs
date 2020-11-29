using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene30 : Pausable
{
    public Scene30 instance;

    public LevelLoader levelLoader;

    public Move characterMove;
    public PauseScreen pauseScreen;

    public Dice dice;
    public int playerStartWayPoint = 0;
    public Dialog dialog1, dialog2;
    
    public bool condition1, condition2, conditionForDialog1, conditionForDialog2;

    public GameObject sword;
    public GameObject monster;

    void Start()
    {
        dialog1.CallDialog();
        characterMove.moveAllowed = false;
    }

    public void DialogContinue()
    {
        if (conditionForDialog1) { dialog1.NextSentence(); }
        if (conditionForDialog2) { dialog2.NextSentence(); }
    }

    void Event()
    {
        characterMove.moveAllowed = false;
        dice.diceSideThrown = 0;
    }
    void Update()
    {
        if (Dialog.dialogEnd)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseScreen.active = !pauseScreen.active;
                // Time.timeScale = pauseScreen.active ? 0.0f : 1.0f;
            }

            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                DialogContinue();
                if (dice.active) dice.Roll();
            }
        }

        if (characterMove.waypointIndex > playerStartWayPoint + dice.diceSideThrown)
        {
            characterMove.moveAllowed = false;
            playerStartWayPoint = characterMove.waypointIndex - 1;
        }

        if (characterMove.waypointIndex == 4 && condition1)
        {
            conditionForDialog2 = true;
            conditionForDialog1 = false;
            dialog2.CallDialog();
            Event(); condition1 = false;
            sword.SetActive(false);
        }


        if (characterMove.waypointIndex == 7 && condition2)
        {
            Event(); condition2 = false;
            monster.SetActive(false);
            levelLoader.LoadScene(6);
        }
    }

    public void MovePlayer()
    {
        characterMove.moveAllowed = true;
    }

    public override void Finish()
    {
        levelLoader.Back();
    }

    public override IEnumerator Resume()
    {
        yield return true;
    }
}
