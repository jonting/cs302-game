// All lines written by Jonathan Ting.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls the hider's camera movement.
public class SeekerCameraFollow : MonoBehaviour
{
    private GameObject player;

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's.
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10f);
    }
}
