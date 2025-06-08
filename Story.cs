using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story : MonoBehaviour
{
    public Transform first, second, third;
    public int part = 0;
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) part++;
        if (part == 0) first.position = Vector3.zero; 
        else if (part == 1) { second.position = Vector3.zero; first.position = new Vector3(20, 20); }
        else if (part == 2) { third.position = Vector3.zero; second.position = new Vector3(20, 20); }
        else if (part == 3) Application.Quit();
    }
}
