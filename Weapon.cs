// All lines written by Jonathan Ting.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls the seeker's gun.
public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;

    public float cooldown = 10f;

    private float timestamp = 0f;
    private float trigger = 0f;

    // Update is called once per frame
    void Update()
    {
        // Reads in input from the Xbox 360 controller's right trigger.
        trigger = Input.GetAxis("FireTrigger");

        // Fires a bullet if the trigger is activated, then triggers a cooldown where the gun cannot be fired again for a very short time.
        if (trigger > 0 && timestamp <= Time.time)
        {
            timestamp = Time.time + cooldown;
            Shoot();
        }
    }

    // Instantiates a new bullet at the fire point object (which is right in-front of the seeker).
    void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
