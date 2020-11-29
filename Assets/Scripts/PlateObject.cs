using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateObject : MonoBehaviour
{
    public static PlateObject instance;

    public bool movable
    {
        get; set;
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        movable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (movable)
        {
            float x = gameObject.transform.position[0];
            bool isAccel = Input.GetKey(KeyCode.RightShift);
            bool isDecel = Input.GetKey(KeyCode.LeftShift);

            Vector3 displacement = transform.right * Time.deltaTime * Constants.PLATE_SPEED * (isAccel ? 1.5f : isDecel ? 0.5f : 1f);

            if (Input.GetKey(KeyCode.A) && x > 300)
            {
                gameObject.transform.position -= displacement;
            }
            else if (Input.GetKey(KeyCode.D) && x < 1000)
            {
                gameObject.transform.position += displacement;
            }
        }
    }
}
