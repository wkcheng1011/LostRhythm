using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public static NoteObject instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if (gameObject.transform.position[1] < 20)
        {
            Scene40.instance.NoteHit(false);
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log(collision);
        if (collision.CompareTag("Player"))
        {
            Scene40.instance.NoteHit(true);
            gameObject.SetActive(false);
        }
    }
}
