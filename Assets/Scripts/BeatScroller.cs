using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public static BeatScroller instance;

    public static float beatTempo;
    public static bool hasStarted;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        beatTempo /= 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            return;
        }
        transform.position -= new Vector3(0f, 2 * beatTempo * Time.deltaTime * Constants.NOTE_SIZE, 0f);
    }
}
