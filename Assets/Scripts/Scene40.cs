using System.Collections;
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

    private bool isPlaying = false;
    public BeatScroller beatScroller;
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

    private int hitNotes, missNotes, totalNotes;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        int totalBeats = (int)Math.Floor(beatTempo / 60f * audioSource.clip.length / 4f);
        totalNotes = totalBeats * Constants.DIFF_COEFF;

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

            GameObject obj = Instantiate(
                notePrefabs[(int)Utils.Urandom(Constants.NOTE_PROB)], 
                new Vector3(
                    280 + Constants.NOTE_SIZE / 2 + lane * Constants.NOTE_SIZE, 
                    Constants.NOTE_SIZE * (8 + i), 
                    0f
                ), 
                Quaternion.identity
            );

            obj.transform.SetParent(GameObject.Find("NoteHolder").transform);
            lastLane = lane;
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
            //BeatScroller.hasStarted = false;
            //Application.Quit();
        }

        if (audioSource.time == audioSource.clip.length)
        {
            BeatScroller.hasStarted = false;
            Application.Quit();
        }
    }

    public void NoteHit(Constants.NOTE_TYPE type)
    {
        switch (type)
        {
            case Constants.NOTE_TYPE.BOMB:
                combo = 0;
                missNotes++;
                playerHp.value -= 0.1f;
                playerMp.value -= 0.1f;
                bossMp.value += 0.05f;
                bossHp.value += 0.05f;
                break;
            case Constants.NOTE_TYPE.SPECIAL:
                combo++;
                bossHp.value -= 0.1f;
                goto case Constants.NOTE_TYPE.NORMAL;
            case Constants.NOTE_TYPE.NORMAL:
                combo++;
                hitNotes++;
                playerMp.value += 0.1f;
                playerHp.value += 0.05f;

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
