using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenLamp : MonoBehaviour
{
    bool on;
    int timer;
    void Update()
    {
        if (on)
        {
            timer--;
            GetComponent<SpriteMask>().enabled = true;
            if (timer <= Random.Range(0f, 60.1f)) on = false;
        }
        else
        {
            timer++;
            GetComponent<SpriteMask>().enabled = false;
            if (timer >= Random.Range(100f, 300.1f)) on = true;
        }
    }
}
