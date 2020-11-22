﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Scene40 : MonoBehaviour
{
    public static Scene40 instance;

    public float beatTempo;
    public AudioSource audioSource;
    public AudioSource beatSource;

    public ProgressBar audioProgress;

    private bool hasStarted = false;
    private bool hasEnded = false;
    public BeatScroller beatScroller;
    public float offset;

    private int score = 0;
    public Text scoreText;

    private int combo = 0;
    public Text comboText;

    public GameObject[] notePrefabs = new GameObject[3];

    private float timeAfterStart;

    private int hitNotes, missNotes, totalNotes;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        totalNotes = 192;

        int lastLane = 3;

        System.Random random = new System.Random();
        for (int i = 0; i < totalNotes * 8; i += 2)
        {
            int lane;
            do
            {
                int[] range = { lastLane > 2 ? -2 : -lastLane, lastLane < 4 ? 2 : 6 - lastLane };
                lane = lastLane + random.Next(range[0], range[1]);
            } while (lane == lastLane && !(random.Next(0, 9) == 0));

            GameObject obj = Instantiate(notePrefabs[random.Next(0, 3)], new Vector3(280 + Constants.NOTE_SIZE / 2 + lane * Constants.NOTE_SIZE, Constants.NOTE_SIZE * (8 + i), 0f), Quaternion.identity);

            obj.transform.SetParent(GameObject.Find("NoteHolder").transform);
            lastLane = lane;
        }

        BeatScroller.beatTempo = beatTempo;

    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted && Input.GetKeyDown(KeyCode.Space))
        {
            hasStarted = true;
            BeatScroller.hasStarted = hasStarted;
        }
        if (hasStarted && !audioSource.isPlaying)
        {
            timeAfterStart += Time.deltaTime;
            if (timeAfterStart >= 60f / beatTempo * 4 + offset)
            {
                audioSource.Play();
            }
        }
        if (!hasEnded && !audioSource.isPlaying)
        {
            hasStarted = false;
            hasEnded = true;
            Application.Quit();
        }
        audioProgress.setValue(audioSource.time / audioSource.clip.length);
    }

    public void NoteHit(Constants.NOTE_TYPE type)
    {
        switch (type)
        {
            case Constants.NOTE_TYPE.BOMB:
                combo = 0;
                missNotes++;
                break;
            case Constants.NOTE_TYPE.SPECIAL:
                combo++;
                goto case Constants.NOTE_TYPE.NORMAL;
            case Constants.NOTE_TYPE.NORMAL:
                combo++;
                hitNotes++;

                beatSource.Play();
                break;
            default:
                break;
        }

        score += (int)(300f * (combo / 100f));

        scoreText.text = score.ToString();
        comboText.text = combo.ToString();
    }
}
