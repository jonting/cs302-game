// All lines written by Jonathan Ting.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls the hider player's functions.
public class Seeker : MonoBehaviour
{
    // Controls the amount of time the seeker is initially frozen at the start of each round.
    public float freezeTime = 15f;
    // Keeps track of the number of coins the seeker holds.
    public int coinCount = 0;
    // INdicates the number of coins needed for the seeker to win the round.
    public int numberOfCoinsNeeded = 2;
    // Indicates whether the seeker is dead or alive to the game controller.
    public bool dead = false;

    private GameObject hiderObject;
    private Hider hider;
    private ControllerMovement controllerMovement;
    private CircleCollider2D circleCollider2D;

    private float timestamp = 0f;

    // Start is called before the first frame update
    void Start()
    {
        controllerMovement = GetComponent<ControllerMovement>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        controllerMovement.enable = false;
        // Records when the seeker's freeze time ends.
        timestamp = Time.time + freezeTime;
    }

    // Update is called once per frame
    void Update()
    {
        hiderObject = GameObject.FindGameObjectWithTag("Player2");
        hider = hiderObject.GetComponent<Hider>();
        
        // If the seeker collects the number of coins needed, the hider dies and the seeker wins the round.
        if (coinCount >= numberOfCoinsNeeded)
        {
            // Number of coins is reset for the next round.
            coinCount = 0;
            hider.dead = true;
        }

        // Controls the freeze time in which the seeker can't move and if the hider gets too close, the seeker wins the round.
        if (timestamp <= Time.time)
        {
            circleCollider2D.isTrigger = false;
            circleCollider2D.radius = 0.2f;
            controllerMovement.enable = true;
            timestamp = 0;
        }
    }
}
