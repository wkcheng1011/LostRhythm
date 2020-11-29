using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Move : MonoBehaviour
{

    public Transform[] waypoints;
    

    [SerializeField]
    private float moveSpeed = 1f;

    public int waypointIndex = 0;

    public bool moveAllowed = false;
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveAllowed)
        {
            Go();
            animator.SetBool("IsWalking", true);

        }
        else { animator.SetBool("IsWalking", false); }
    }

    private void Go()
    {
        if (waypointIndex <= waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                waypoints[waypointIndex].transform.position,
                moveSpeed * Time.deltaTime);

            if (transform.position == waypoints[waypointIndex].transform.position)
                waypointIndex += 1;
        }
    }
}
