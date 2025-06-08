using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mouse : MonoBehaviour
{
    public SpriteRenderer mouse, start, tutuorial;
    void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
        if (mouse.bounds.Intersects(start.bounds))
        {
            if (Input.GetMouseButtonDown(0)) SceneManager.LoadScene("First level");
        }
        if (mouse.bounds.Intersects(tutuorial.bounds))

        {
            if (Input.GetMouseButtonDown(0)) SceneManager.LoadScene("Tutorial");
        }
    }
}
