using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    SpriteRenderer sr;
    public Human humanScript;
    public Human1 humanScript1;
    public SpriteRenderer Black;
    public bool thirdscene;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    //COLLISION
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            sr.color = Color.black;
            if (thirdscene)
            {
                humanScript1.goalLight = transform.position;
                humanScript1.state = "lamprout";
            }
            else
            {
                humanScript.goalLight = transform.position;
                humanScript.state = "lamprout";
            }
            Black.color = new Color32(0, 0, 0, 200);
        }
        if (collision.gameObject.tag == "Human")
        {
            sr.color = Color.white;
            if (thirdscene)
            {
                collision.gameObject.GetComponent<Human1>().goalLight = collision.gameObject.GetComponent<Human1>().ip;
                collision.gameObject.GetComponent<Human1>().state = "lampBack";
            }
            else
            {
                collision.gameObject.GetComponent<Human>().goalLight = collision.gameObject.GetComponent<Human>().ip;
                humanScript.state = "lampBack";
            }
            Black.color = new Color32(255, 255, 199, 255);
        }
    }
}
