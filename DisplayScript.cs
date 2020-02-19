// All lines written by Jonathan Ting.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enables multi-monitor support. Activates when the first level loads.
public class DisplayScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Activates the hider's display.
        if (Display.displays.Length > 1)
            Display.displays[1].Activate();
        //Activates the seeker's display.
        if (Display.displays.Length > 2)
            Display.displays[2].Activate();
    }
}
