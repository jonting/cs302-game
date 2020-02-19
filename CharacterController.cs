// All lines written by Jonathan Ting.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controller for hider's movement.
public class CharacterController : MonoBehaviour
{
    // Controls how smoothed the movement is.
    [Range(0f, 0.5f)] public float movementSmoothing = 0.3f;

    private Rigidbody2D rigidBody2D;
    private Vector3 velocity = Vector3.zero;

    // Hider by default is facing right.
    private bool facingRight = true;

    void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Controls the movement of the the hider.
    public void Move(float xSpeed, float ySpeed)
    {
        // Moves the character by finding the target velocity in either the horizontal or vertical direction.
        Vector3 targetVelocity = new Vector2(xSpeed * 10f, ySpeed * 10f);

        // Smooths out the movement.
        rigidBody2D.velocity = Vector3.SmoothDamp(rigidBody2D.velocity, targetVelocity, ref velocity, movementSmoothing);

        // Flips the character if moving in one direction and facing the other way.
        if (xSpeed > 0 && !facingRight)
            Flip();
        else if (xSpeed < 0 && facingRight)
            Flip();
    }

    // Flips hider if moving in different direction.
    private void Flip()
    {
        // Labels the new direction character is facing.
        facingRight = !facingRight;

        // Flips character around.
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
}
