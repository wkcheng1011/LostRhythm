using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public static NoteObject instance;

    public Constants.NOTE_TYPE noteType = Constants.NOTE_TYPE.NORMAL;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if (gameObject.transform.position[1] < 20 && noteType != Constants.NOTE_TYPE.BOMB)
        {
            Scene40.instance.NoteHit(Constants.NOTE_TYPE.BOMB);
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log(collision);
        if (collision.CompareTag("Player"))
        {
            Scene40.instance.NoteHit(noteType);
            gameObject.SetActive(false);
        }
    }
}
