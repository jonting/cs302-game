// All lines initally written by Philip Hicks, lines 11-61 were modified by Jonathan Ting
// to support movement using a wired Xbox 360 controller instead of mouse and keyboard.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Controls the movement of the seeker.
public class ControllerMovement : MonoBehaviour
{
    // Controls the speed of the seeker.
    public float speed = 2f;
    // Enables or disables movement.
    public bool enable = true;

    private Rigidbody2D rigidBody2D;
    private Vector2 move = Vector2.zero;
    private Vector2 velocity = Vector2.zero;

    private float joyX = 0f;
    private float joyY = 0f;
    private float heading = 0f;
    private bool facingRight = true;

    // Start is called before the first frame update.
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame.
    void Update()
    {
        // Left joystick controls movement.
        move.x = Input.GetAxis("HorizontalLeftStick");
        move.y = Input.GetAxis("VerticalLeftStick");

        // Right joystick controls look direction.
        joyX = Input.GetAxis("HorizontalRightStick");
        joyY = Input.GetAxis("VerticalRightStick");

        // Calculates direction and speed.
        heading = Mathf.Atan2(joyY, joyX);
        velocity = move * speed;

        // Applies look direction.
        if (enable)
            transform.rotation = Quaternion.Euler(0f, 0f, heading * Mathf.Rad2Deg);
    }

    void FixedUpdate()
    {
        if (enable)
        {
            // Moves the character by finding the target velocity.
            Vector2 targetVelocity = new Vector2(velocity.x * 10f, velocity.y * 10f);

            // Applies velocity to the character.
            rigidBody2D.velocity = targetVelocity;
        }
    }

    /*void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("hit: " + other.gameObject.name);
        if (other.gameObject.name == "RoomTransitionObject")
        {
            RTOControler script = (RTOControler)other.gameObject.GetComponent("RTOControler");
            Debug.Log(script.destination);
            //string sceneName = "Scenes/" + script.destination;
            StartCoroutine(LoadScene(script.destination));


            //StartCoroutine(LoadYourAsyncScene(script.destination));
        }

    }

    IEnumerator LoadScene(string name)
    {
        string sceneName = "Scenes/" + name;
        AsyncOperation load = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        Scene sceneToLoad = SceneManager.GetSceneByName(name);
        Debug.Log(sceneToLoad.name);
        SceneManager.MoveGameObjectToScene(this.gameObject, sceneToLoad);
        //yield return load;


        //AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Scenes/"+name);

        // Wait until the asynchronous scene fully loads
        while (!load.isDone)
        {
            yield return null;
        }
        SceneManager.UnloadSceneAsync("NetworkTest");
    }*/
}
