using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinguWalk : MonoBehaviour
{

    private Rigidbody2D Rigidbody2D;
    private float Horizontal;
    private Animator Animator;

    //Variables para el salto
    private float fuerzaSalto = 3.0f;
    private Collider2D collider;

    //Variables para el dash 
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

    public bool dashAndJump = false;

    //Matar enemigo
    private bool isJumping = false;

    //Vida
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    //Parry
    public bool canParryJump = false;



    //


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
        HealthSystem();


    }

    private void DashMove() {

        if (Input.GetKey(KeyCode.Space))
        {

            Dash_T += 1 * Time.deltaTime;

            if (Dash_T < 0.35f && !isJumping)
            {



                
                Dash = true;
                    Animator.SetBool("Dash", true);
                    //transform.Translate(Vector3.right * Speed_Dash * Time.fixedDeltaTime);
                    Rigidbody2D.AddForce(new Vector2(direction * 2, 0.01f), ForceMode2D.Impulse);

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

        Vector2 dir = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);

       //Si agrego un if puedo hacer que corra con una letra
            Rigidbody2D.AddForce(Vector2.right * dir * 5f);
        

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        Animator.SetBool("Running", Horizontal != 0.0f);

    }
    
    private void Jump() {
        Animator.SetFloat("jumpVelocity", Rigidbody2D.velocity.y);
        if (!collider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; };
        if (Input.GetKeyDown(KeyCode.W))
        {

            if (Dash)
            {

                Rigidbody2D.AddForce(new Vector2(0f, 3.5f), ForceMode2D.Impulse);
                dashAndJump = false;
            }

            else
            {
                Rigidbody2D.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse);
                isJumping = true;
            }
        }

    

    }

    private void FixedUpdate() {


        Rigidbody2D.velocity = new Vector2(Horizontal, Rigidbody2D.velocity.y);
        DashMove();
        FallDown();
       

    }

    private void CheckForGround()
    {
        if (collider.IsTouchingLayers(LayerMask.GetMask("Ground"))) {

            Animator.SetBool("isGrounded", true);
            isJumping = false;
            dashAndJump = true;
        }
        else
        {
            Animator.SetBool("isGrounded", false);
            isJumping = true;
        }

    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {

            if (isJumping)
            {
                Rigidbody2D.AddForce(new Vector2(0f, 5.0f), ForceMode2D.Impulse);
                Destroy(col.gameObject);
            }
            else
            {
                // aca falta recibir golpe y retroceder
                health--;



            }
        }
        else if (col.gameObject.tag == "Spike")
        {

            if (Dash)
            {

                reduceHealth(1);
                Rigidbody2D.AddForce(new Vector2(0f, 3.0f), ForceMode2D.Impulse);
                // StartCoroutine(Knockback(0.02f, 10, transform.position));
            }
            else
            {

                reduceHealth(2);
                StartCoroutine(Knockback(0.02f, 350, transform.position));
            }
        }


        else if (col.gameObject.tag == "Parry")


        {
            if (isJumping)
            {


                Rigidbody2D.velocity = (Vector2.up * 3f);


                StartCoroutine(Respawn(col.gameObject, 5f));
                /*
                   if (Input.GetKey(KeyCode.J))
                   {
                       Rigidbody2D.AddForce(new Vector2(0f, 4.0f), ForceMode2D.Impulse);
                   }
                   */
            }

        }
        else if (col.gameObject.tag == "Wheel") {

            reduceHealth(1);

        }

    }

    IEnumerator Respawn(GameObject obj, float timeToRespawn)
    {

        obj.SetActive(false);
        yield return new WaitForSeconds(timeToRespawn);
        obj.SetActive(true);
    }


    private void GameOver() {

        Destroy(this.gameObject);
        FindObjectOfType<GameManager>().EndGame();

    }

    private void FallDown() {

        if (Rigidbody2D.position.y < -1f)
        {

            health = 0;

        }

    }

    private void HealthSystem() {

        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        if (health <= 0) {

            GameOver();

        }


        for (int i = 0; i < hearts.Length; i++)
        {

            if (i < health)
            {
                hearts[i].sprite = fullHeart;

            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }


            if (i < numOfHearts)
            {
                hearts[i].enabled = true;

            }
            else
            {
                hearts[i].enabled = false;
            }

        }

    }

    public void reduceHealth(int amount)
    {

        health -= amount;
    }

    public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir) {

        Debug.Log("Funciona?");

        float timer = 0;

        while (knockDur > timer) {

            timer += Time.deltaTime;


            Rigidbody2D.AddForce(new Vector2(0f, 5.0f), ForceMode2D.Impulse);

        }
        yield return 0;


    }

}
