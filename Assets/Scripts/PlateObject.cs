using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateObject : MonoBehaviour
{
    public static PlateObject instance;

    private int lane = 3;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && lane > 0)
        {
            lane--;
            gameObject.transform.position += new Vector3(-100, 0, 0);
        } else if (Input.GetKeyDown(KeyCode.D) && lane < 7)
        {
            lane++;
            gameObject.transform.position += new Vector3(100, 0, 0);
        }
    }
}
