using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_1 : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed);
        if (rb.position.x > -3f) {
            speed = 0f;
            StartCoroutine(Border());
        }
        

    }

    IEnumerator Border()
    {



        yield return new WaitForSeconds(5f);

        speed = 0.005f;
        //StartCoroutine(Border(parry));   // This makes it loop itself as long as canBlink is true

    }


    /*public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Stop")
        {
            Debug.Log("Pasa?");
            speed = 0f;
        }

    }
    */
}