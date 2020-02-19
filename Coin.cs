// All lines written by Jonathan Ting.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manages behavior of the two coin objectives.
public class Coin : MonoBehaviour
{
    private GameObject gameControllerObject;
    private GameObject seekerObject;
    private GameController gameController;
    private Seeker seeker;

    // Start is called before the first frame update
    void Start()
    {
        // Finds the game controller object.
        gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Finds the seeker object who interacts with the coins.
        seekerObject = GameObject.FindGameObjectWithTag("Player");
        seeker = seekerObject.GetComponent<Seeker>();
    }

    //Adds to the number of coins in the game controller upon collision by a seeker.
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Seeker seeker = hitInfo.GetComponent<Seeker>();

        //If a seeker collides with the coins, the number of coins the seeker has is incremented and the coin is deleted.
        if (seeker != null)
        {
            seeker.coinCount++;
            Destroy(gameObject);
        }
    }
}
