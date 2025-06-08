using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Human1 : MonoBehaviour
{
    public Vector3 goalLight,ip;
    public Transform point1, point2, pointLamp1,pointLamp2;
    public string state; //patrol - lamprout - chaselamp - lampBack - chasemoth
    bool oneWay, lampWay;
    void Start()
    {
        ip = transform.position;
        goalLight = ip;
        state = "patrol";
        oneWay = true;
        lampWay = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(state == "patrol")
        {
            if (oneWay)
            {
                transform.position = Vector3.Lerp(transform.position, point1.position, 0.02f);
                if((point1.position.y - transform.position.y) > -1) oneWay = false;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, point2.position, 0.02f);
                if ((point2.position.y - transform.position.y) < 1) oneWay = true;
            }
        }
        if (state == "lamprout")
        {
            if (lampWay)
            {
                transform.position = Vector3.Lerp(transform.position, pointLamp1.position, 0.02f);
                if (((pointLamp1.position.y - transform.position.y) < 1) && ((pointLamp1.position.y - transform.position.y) > -1)) lampWay = false;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, pointLamp2.position, 0.02f);
                if ((pointLamp2.position.x - transform.position.x) > -1f) state = "chaselamp";
            }
        }
        if(state == "chaselamp")
        {
            transform.position = Vector3.Lerp(transform.position, goalLight, 0.02f);
        }
        if(state == "lampBack")
        {
            if (lampWay)
            {
                transform.position = Vector3.Lerp(transform.position, pointLamp1.position, 0.02f);
                if ((pointLamp1.position.x - transform.position.x) < 1f) state = "patrol";
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, pointLamp2.position, 0.02f);
                if ((pointLamp2.position.y - transform.position.y) < 1f) lampWay = true;
            }
        }
    }
}
