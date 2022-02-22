using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSpike : MonoBehaviour
{

    public float walkSpeed;
    public bool mustPatrol;

    public Rigidbody2D rb;
    public Transform groundCheckPos;
    private bool mustTurn;
    public LayerMask groundLayer;


    public static bool canBlink = true;
    public GameObject[] obj;
    public GameObject objS;

    public bool isVertical;

    void Start() {

        mustPatrol = true;

        obj = GameObject.FindGameObjectsWithTag("Parry 2");
        canBlink = true;
        foreach (GameObject objS in obj)
        {
            StartCoroutine(Border(objS));
        }
    }

    void Update() {


        if (mustPatrol) {

            Patrol();
        }
    }


    void Patrol() {

        if (isVertical)
        {

            rb.velocity = new Vector2(rb.velocity.x, walkSpeed);
        }
        else { 
            rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }
    }

    void Flip()
    {
        if (isVertical)
        {
            
            walkSpeed *= -1;
        }

        else
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            walkSpeed *= -1;
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Hitbox") {

            Flip();
        }


    }


    IEnumerator Border(GameObject parry)
    {
        if (canBlink)
        { 

            yield return new WaitForSeconds(2f);
            parry.SetActive(false);
            yield return new WaitForSeconds(2f);
            parry.SetActive(true);
            StartCoroutine(Border(parry)); 
        }
    }


}
