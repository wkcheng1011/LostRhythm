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

    public GameObject arrow;
    public Dice dice;
    public int playerStartWayPoint = 0;

    public Dialog dialog1, dialog2, dialog3;
    public bool[] conditionForOnce = { true, true }, conditionForDialog = { true, false, false };

    public GameObject sword;
    public GameObject monster;

    void Start()
    {
        dialog1.CallDialog();
        characterMove.moveAllowed = false;
    }

    public void DialogContinue()
    {
        if (conditionForDialog[0]) { dialog1.NextSentence(); }
        if (conditionForDialog[1]) { dialog2.NextSentence(); }
        if (conditionForDialog[2]) { dialog3.NextSentence(); }
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
            }

            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
            {
                DialogContinue();
                if (dice.active) dice.Roll();
            }
        }

        arrow.SetActive(dice.active && !characterMove.moveAllowed);
        
        if (characterMove.waypointIndex > playerStartWayPoint + dice.diceSideThrown)
        {
            characterMove.moveAllowed = false;
            playerStartWayPoint = characterMove.waypointIndex - 1;
        }

        if (characterMove.waypointIndex == 4 && conditionForOnce[0])
        {
            conditionForDialog[1] = true;
            conditionForDialog[0] = false;
            dialog2.CallDialog();
            Event(); conditionForOnce[0] = false;
            sword.SetActive(false);
        }



        if (characterMove.waypointIndex == 7 && conditionForOnce[1])
        {
            conditionForDialog[1] = false;
            conditionForDialog[2] = true;
            dialog3.CallDialog();
            Event(); conditionForOnce[1] = false;
        }

        if (dialog3.dialogEndForObject)
        {
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
