// All lines written by Jonathan Ting.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spawns 2 new seekers and hiders for each scene.
public class CharacterSpawner : MonoBehaviour
{
    public GameObject seeker;
    public GameObject hider;

    // Holds the spawn coordinates for both the seeker and the hider. Different for each scene.
    public float seekerX = 0f;
    public float seekerY = 0f;
    public float hiderX = 0f;
    public float hiderY = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        // Instantiates an instance of both the seeker and the hider.
        Instantiate(seeker, new Vector3(seekerX, seekerY, 0), Quaternion.identity);
        Instantiate(hider, new Vector3(hiderX, hiderY, 0), Quaternion.identity);
    }
}
