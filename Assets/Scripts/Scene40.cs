﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Scene40 : Pausable
{
    public static Scene40 instance;

    public LevelLoader levelLoader;
    public PauseScreen pauseScreen;

    public float beatTempo;
    public AudioSource audioSource;
    public AudioSource beatSource;

    private bool isPlaying = false;
    public BeatScroller beatScroller;
    public PlateObject plateObject;
    public float offset;

    public ProgressBar playerMp;
    public ProgressBar playerHp;
    public ProgressBar bossMp;
    public ProgressBar bossHp;

    private int score = 0;
    public Text scoreText;
    private int combo = 0;
    public Text comboText;

    public GameObject[] notePrefabs = new GameObject[3];

    private float timeAfterStart;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        int totalBeats = (int)Math.Floor(beatTempo / 60f * audioSource.clip.length / 4f);
        int totalNotes = totalBeats * Constants.DIFF_COEFF;

        int lastLane = 3;

        System.Random random = new System.Random();
        for (int i = 0; i < totalNotes * (8 / Constants.DIFF_COEFF); i += (16 / Constants.DIFF_COEFF))
        {
            int lane;
            do
            {
                int[] range = { lastLane > 2 ? -2 : -lastLane, lastLane < 4 ? 2 : 6 - lastLane };
                lane = lastLane + random.Next(range[0], range[1]);
            } while (lane == lastLane && !(random.Next(0, 9) == 0));

            int noteType = (int)Utils.Urandom(Constants.NOTE_PROB);

            GameObject obj = Instantiate(
                notePrefabs[noteType], 
                new Vector3(
                    280 + Constants.NOTE_SIZE / 2 + lane * Constants.NOTE_SIZE, 
                    Constants.NOTE_SIZE * (8 + i), 
                    0f
                ), 
                Quaternion.identity
            );

            obj.transform.SetParent(GameObject.Find("NoteHolder").transform);
            lastLane = lane;

            PlayerData.noteTotal[noteType]++;
        }

        BeatScroller.beatTempo = beatTempo;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlaying)
        {
            BeatScroller.hasStarted = true;
            timeAfterStart += Time.deltaTime;
            if (timeAfterStart >= 60f / beatTempo * 4 + offset)
            {
                isPlaying = true;
                audioSource.Play();
            }
        }

        if (playerHp.value == 0)
        {
            PlayerData.isPass = false;
            Finish();
        }

        if (audioSource.time == audioSource.clip.length || bossHp.value == 0)
        {
            PlayerData.isPass = true;
            Finish();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseScreen.active)
            {
                StartCoroutine(Resume());
            }
            else
            {
                plateObject.movable = false;
                BeatScroller.hasStarted = false;
                audioSource.Pause();
                pauseScreen.active = true;
            }
        }
    }
    public void NoteHit(Constants.NOTE_TYPE type, bool isHit)
    {
        if (type == Constants.NOTE_TYPE.BOMB && isHit || type != Constants.NOTE_TYPE.BOMB && !isHit)
        {
            combo = 0;
            playerHp.value -= 0.05f;
            playerMp.value -= 0.05f;
            bossMp.value += 0.05f;
            bossHp.value += 0.05f;
        }
        else
        {
            if (type == Constants.NOTE_TYPE.SPECIAL)
            {
                bossHp.value -= 0.05f;
                playerHp.value += 0.05f;
            }
            combo++;
            playerMp.value += 0.01f;
            beatSource.Play();
        }

        if (isHit) PlayerData.noteHit[(int)type]++;

        score += (int)(300f * (combo / 100f));

        scoreText.text = score.ToString();
        comboText.text = combo.ToString();
    }

    public override IEnumerator Resume()
    {
        yield return new WaitForSeconds(3);

        plateObject.movable = true;
        BeatScroller.hasStarted = true;
        audioSource.Play();
        pauseScreen.active = false;
    }

    public override void Finish()
    {
        PlayerData.HP = playerHp.value;
        PlayerData.MP = playerMp.value;

        levelLoader.LoadScene(7);
    }
}
