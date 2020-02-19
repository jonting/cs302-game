// All lines written by Jonathan Ting.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls the hider player's functions.
public class Hider : MonoBehaviour
{
    // Indicates the time the seeker is frozen, since if the hider collides with the seeker during freezetime,
    // the seeker gets a point.
    public float freezeTime = 15f;
    // Indicates whether the hider is dead or alive to the game controller.
    public bool dead = false;

    private float timestamp;
    private bool early = true;

    // Start is called before the first frame update
    void Start()
    {
        // Records when the seeker's freeze time ends.
        timestamp = Time.time + freezeTime;
    }

    // Update is called once per frame
    void Update()
    {
        // Once freeze time ends, hider can now collide with the seeker for a point.
        if (timestamp <= Time.time)
            early = false;
    }

    // Detects a collision with the seeker.
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Seeker seeker = hitInfo.GetComponent<Seeker>();

        // If the hider collides with the seeker...
        if (seeker != null)
        {
            // If it's during the seeker's freeze time, the seeker gets a point.
            if (early)
            {
                dead = true;
                timestamp = 0;
            }
            // If it's outside the seeker's freeze time, the hider gets a point.
            else
            {
                seeker.dead = true;
                timestamp = 0;
            }
        }
    }
}
