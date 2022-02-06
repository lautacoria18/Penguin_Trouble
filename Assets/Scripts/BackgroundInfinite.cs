using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundInfinite : MonoBehaviour
{
    // Start is called before the first frame update

    private BoxCollider2D collider;
    private Rigidbody2D rb;

    private float width;
    private float scrollSpeed = -2f;



    void Start()
    {

        collider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        width = collider.size.x;
        collider.enabled = false;


        rb.velocity = new Vector2(scrollSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!PinguRun.isDone)
        {
            if (transform.position.x < -width)
            {
                Vector2 resetPosition = new Vector2(width * 2f, 0);
                transform.position = (Vector2)transform.position + resetPosition;
            }
            //StartCoroutine(Border());
        }
        else {
            rb.velocity = new Vector2(0f, 0);
            Debug.Log("Se termino todo");

        }
    }

/*
    IEnumerator Border()
    {



        yield return new WaitForSeconds(10f);
        isDone = true;

        Debug.Log("TERMINO EL NIVEL");
        //StartCoroutine(Border(parry));   // This makes it loop itself as long as canBlink is true

    }
    */
}
