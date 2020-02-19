// All lines written by Jonathan Ting.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls the behavior of the projectile fired from the gun.
public class Bullet : MonoBehaviour
{
    public Rigidbody2D rigidBody2D;

    // Controls the speed of the bullet.
    public float speed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        // Velocity of the bullet goes straight from where the player is pointed.
        rigidBody2D.velocity = transform.right * speed;
    }

    // Marks the hider as dead if the bullet collides with the hider.
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Hider hider = hitInfo.GetComponent<Hider>();

        // Marks the hider as dead if collision with hider is detected.
        if(hider != null)
            hider.dead = true;
        
        // Bullet object is destroyed on collision.
        Destroy(gameObject);
    }
}
