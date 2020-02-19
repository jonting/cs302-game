// All lines written by Jonathan Ting.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Reads in input from keyboard for hider's movement, interacts with Character Controller script.
public class PlayerMovement : MonoBehaviour
{
    // Controls the speed at which the hider moves.
    [Range(0f, 100f)] public float runSpeed = 40f;
    
    private CharacterController characterController;

    private float xSpeed = 0f;
    private float ySpeed = 0f;

    void Awake()
    {
        // Connects with the hider's character controller.
        characterController = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Update()
    {
        // Reads in input from the movement keys.
        xSpeed = Input.GetAxisRaw("Horizontal") * runSpeed;
        ySpeed = Input.GetAxisRaw("Vertical") * runSpeed;
    }

    void FixedUpdate()
    {
        // Moves the hider based on the input from the movement keys.
        characterController.Move(xSpeed * Time.fixedDeltaTime, ySpeed * Time.fixedDeltaTime);
    }
}
