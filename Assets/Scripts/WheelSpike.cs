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
    void Start() {

        mustPatrol = true;

    }

    void Update() {


        if (mustPatrol) {

            Patrol();
        }
    }


    void Patrol() {

        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);

    }

    void Flip()
    {
        //mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Hitbox") {

            Debug.Log("Funciona esto?");

            Flip();
        }


    }




}
