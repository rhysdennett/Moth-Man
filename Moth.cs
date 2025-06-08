using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Moth : MonoBehaviour
{
    public float x, y;
    public float speed;
    public string state; //move - dead

    Vector3 ip;

    Rigidbody2D rb;
    private void Awake()
    {
        Application.targetFrameRate = 60;

        rb = GetComponent<Rigidbody2D>();
        ip = transform.position;
    }
    void Start()
    {
        transform.position = ip;
        speed = 0.05f;
        x = 0; y = 0;
        state = "move";
    }

    // Update is called once per frame
    void Update()
    {
        //MOVEMENT
        if (state == "move")
        {
            if (Input.GetKey(KeyCode.W) && y < 7f) //transform.position += new Vector3(0, 0.07f);
            {
                if (y < 2) y += 0.5f;
                y += speed;
            }
            else if (y > 0) y -= speed * 4;
            if (Input.GetKey(KeyCode.S) && y > -7f) //transform.position -= new Vector3(0, 0.07f);
            {
                if (y > -2) y -= 0.5f;
                y -= speed;
            }
            else if (y < 0) y += speed * 4;
            if (Input.GetKey(KeyCode.D) && x < 7f) //transform.position += new Vector3(0.07f, 0);
            {
                if (x < 2) x += 0.5f;
                x += speed;
            }
            else if (x > 0) x -= speed * 4;
            if (Input.GetKey(KeyCode.A) && x > -7f) //transform.position -= new Vector3(0.07f, 0);
            {
                if (x > -2) x -= 0.5f;
                x -= speed;
            }
            else if (x < 0) x += speed * 4;
            rb.velocity = new Vector2(x, y);

            if (x < 0.5f && x > -0.5f) x = 0;
            if (y < 0.5f && y > -0.5f) y = 0;
        }

        if (state == "dead")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (state == "exit")
        {
            x = 0; y = 0;
            transform.position += new Vector3(0.02f, 0.02f);
        }
    }

    //COLLISION                                                                                                       
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Human")
        {
            state = "dead";
        }
    }
}
