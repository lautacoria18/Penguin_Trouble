using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinguWalk : MonoBehaviour
{

    private Rigidbody2D Rigidbody2D;
    private float Horizontal;
    private Animator Animator;


    //Variables para el salto
    private float fuerzaSalto = 3.0f;
    private Collider2D collider;

    //Variables para el dash ?
    public bool Dash;
    public float Dash_T;
    public float Speed_Dash;

    //ojo
    float direction = 1;

    //Variables para el dash con buena colision

    public BoxCollider2D Collider2;
    public Vector2 StandingSize;
    public Vector2 DashSize;
    public Vector2 StandingOff;
    public Vector2 DashOff;
    public CapsuleCollider2D CapsuleCol;


    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        collider = gameObject.GetComponent<Collider2D>();

        //
        Collider2 = GetComponent<BoxCollider2D>();
        CapsuleCol = GetComponent<CapsuleCollider2D>();
        CapsuleCol.size = StandingSize;
        StandingSize = CapsuleCol.size;
        CapsuleCol.offset = StandingOff;


    }

    // Update is called once per frame
    void Update()
    {
        if (Horizontal != 0) {
            direction = Horizontal;
        }
        ProcesarMovimiento();
        Jump();
        CheckForGround();


    }

    private void DashMove() {

        if (Input.GetKey(KeyCode.Space))
        {

            Dash_T += 1 * Time.deltaTime;

            if (Dash_T < 0.35f)
            {
                Dash = true;
                Animator.SetBool("Dash", true);
                //transform.Translate(Vector3.right * Speed_Dash * Time.fixedDeltaTime);
                Rigidbody2D.AddForce(new Vector2(direction * 2, 0), ForceMode2D.Impulse);

                //
                CapsuleCol.direction = CapsuleDirection2D.Horizontal;
                CapsuleCol.size = DashSize;
                CapsuleCol.offset = DashOff;
                    
            }
            else
            {
                Dash = false;
                Animator.SetBool("Dash", false);
                CapsuleCol.size = StandingSize;
                CapsuleCol.direction = CapsuleDirection2D.Vertical;
                CapsuleCol.offset = StandingOff;
            }
        }
        else
        {
            Dash = false;
            Animator.SetBool("Dash", false);
            Dash_T = 0;
            CapsuleCol.size = StandingSize;
            CapsuleCol.direction = CapsuleDirection2D.Vertical;
            CapsuleCol.offset = StandingOff;
        }



    }

    private void ProcesarMovimiento() {

        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        Animator.SetBool("Running", Horizontal != 0.0f);

    }

    private void Jump() {
        Animator.SetFloat("jumpVelocity", Rigidbody2D.velocity.y);
        if (!collider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; };
        if (Input.GetKeyDown(KeyCode.W))
        {

            Rigidbody2D.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse);
           
        }

    }

    private void FixedUpdate() {


        Rigidbody2D.velocity = new Vector2(Horizontal, Rigidbody2D.velocity.y);
        DashMove();
    }

    private void CheckForGround()
    {
        if (collider.IsTouchingLayers(LayerMask.GetMask("Ground"))) {

            Animator.SetBool("isGrounded", true);
        }
        else
        {
            Animator.SetBool("isGrounded", false);
        }

    }



}
