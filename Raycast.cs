// All lines written by Jonathan Ting.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls hider's ability to transform into objects. Uses a raycast to detect objects to transform into.
public class Raycast : MonoBehaviour
{
    public CircleCollider2D circleCollider2D;
    public CircleCollider2D circleCollider2D_2;

    public bool isSeeker = false;

    private Camera playerCamera;
    private BoxCollider2D boxCollider2D;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D origBoxCollider2D;
    private Sprite origSprite;
    private Vector3 origScale;
    private Vector2 origBoxCollider;
    private Quaternion origRotation;
    private Vector3 mousePosition = Vector3.zero;
    private Vector2 rayPos = Vector2.zero;
    private RaycastHit2D ray;

    private float origRadius;
    private float origRadius2;
    private bool transformed = false;
    private bool rayColor = false;

    void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = Camera.main;

        // Stores original player variables.
        origScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        origRotation = new Quaternion(transform.localRotation.x, transform.localRotation.y, transform.localRotation.z, transform.localRotation.w);
        origBoxCollider = new Vector2(boxCollider2D.size.x, boxCollider2D.size.y);
        origRadius = circleCollider2D.radius;
        origRadius2 = circleCollider2D_2.radius;
        origSprite = spriteRenderer.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        // Updates the mouse cursor position which the ray is casted to.
        mousePosition = playerCamera.ScreenToWorldPoint(Input.mousePosition);
        rayPos = new Vector2(playerCamera.ScreenToWorldPoint(Input.mousePosition).x, playerCamera.ScreenToWorldPoint(Input.mousePosition).y);

        // Controls raycast and transforming.
        Raycasting();
        // Controls reverting character back to original form.
        Behaviors();
    }

    // Draws the raycast to select objects and reads key to transform into object deemed transformable.
    private void Raycasting()
    {
        // Cast a ray from player to mouse position.
        ray = Physics2D.Raycast(rayPos, Vector2.zero, 0f);

        // If it hits something...
        if (ray.collider != null)
        {
            // Upon pressing E, transforms Kirby to object ray is collding with.
            if (Input.GetKeyDown("e"))
            {
                Transform objTransform = ray.collider.GetComponent<Transform>();
                BoxCollider2D objCollider = ray.collider.GetComponent<BoxCollider2D>();
                SpriteRenderer objSprite = ray.collider.GetComponent<SpriteRenderer>();

                transform.localScale = new Vector3(objTransform.localScale.x, objTransform.localScale.y, objTransform.localScale.z);
                transform.localRotation = new Quaternion(objTransform.localRotation.x, objTransform.localRotation.y, objTransform.localRotation.z, objTransform.localRotation.w);
                boxCollider2D.size = new Vector2(objCollider.size.x, objCollider.size.y);
                circleCollider2D.radius = 0;
                circleCollider2D_2.radius = 0;
                spriteRenderer.sprite = objSprite.sprite;
            }
            
            // Makes debug line turn green if a valid object is detected.
            rayColor = true;
        }
        // Makes debug line turn red if a valid object is not detected.
        else
            rayColor = false;

        // Visualizes ray line for debugging, green for collision, red for no collision.
        if (rayColor == false)
            Debug.DrawLine(transform.position, mousePosition, Color.red);
        else
            Debug.DrawLine(transform.position, mousePosition, Color.green);
    }

    // Controls other key functions for hider.
    private void Behaviors()
    {
        // Transforms player back to original Kirby upon pressing R.
        if (Input.GetKeyDown("r"))
        {
            transformed = true;
            transform.localScale = origScale;
            transform.localRotation = origRotation;
            boxCollider2D.size = origBoxCollider;
            circleCollider2D.radius = origRadius;
            circleCollider2D_2.radius = origRadius2;
            spriteRenderer.sprite = origSprite;
        }

        if (Input.GetKeyDown("f"))
        {
            transformed = false;
            isSeeker = !isSeeker;
        }
    }
}
