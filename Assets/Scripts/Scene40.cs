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
    public bool hasStarted;
    public BeatScroller beatScroller;

    private int score = 0;
    public Text scoreText;

    private int combo = 0;
    public Text comboText;

    public GameObject notePrefab;

    private float timeAfterStart;
    private int hitNotes, missNotes, totalNotes;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        totalNotes = 192;

        int lastLane = 3;

        System.Random random = new System.Random();
        for (int i = 0; i < totalNotes * 9 / 8; i++)
        {

            if (i % 9 == 0) continue;

            int lane;
            do
            {
                int[] range = { lastLane > 2 ? -2 : -lastLane, lastLane < 4 ? 2 : 6 - lastLane };
                lane = lastLane + random.Next(range[0], range[1]);
            } while (lane == lastLane && !(random.Next(0, 9) == 0));

            GameObject obj = Instantiate(notePrefab, new Vector3(640 - 350 + lane * 100, 800 + i * 100, 0f), Quaternion.identity);

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
            if (timeAfterStart >= 60f / beatTempo * 4)
            {
                audioSource.Play();
            }
        }
        if (missNotes + hitNotes == totalNotes)
        {
            Application.Quit();
        }
    }

    public void NoteHit(bool hit)
    {
        if (!hit)
        {
            combo = 0;
            missNotes++;
        } else
        {
            combo++;
            hitNotes++;
        }
        score += (int)(300 * combo / 100f);

        scoreText.text = score.ToString();
        comboText.text = combo.ToString();
    }
}
