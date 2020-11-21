using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateObject : MonoBehaviour
{
    public static PlateObject instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        float x = gameObject.transform.position[0];
        bool isAccel = Input.GetKey(KeyCode.LeftShift);
        bool isDecel = Input.GetKey(KeyCode.RightShift);

        Vector3 displacement = transform.right * Time.deltaTime * Constants.PLATE_SPEED * (isAccel ? 1.5f : isDecel ? 0.5f : 1f);

        if (Input.GetKey(KeyCode.A) && x > 0)
        {
            gameObject.transform.position -= displacement;
        } else if (Input.GetKey(KeyCode.D) && x < 1280)
        {
            gameObject.transform.position += displacement;
        }
    }
}
