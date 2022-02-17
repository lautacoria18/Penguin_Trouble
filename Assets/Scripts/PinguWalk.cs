using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PinguWalk : MonoBehaviour
{
    
    private Rigidbody2D Rigidbody2D;
    private float Horizontal;
    private Animator Animator;

  

    private bool isDeath = false;

    //Variables para el salto
    private float fuerzaSalto = 3.0f;
    private Collider2D collider;
    public bool canDobleJump = false;

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
    public bool canAirDash = false;


    //
    public int iLevelToLoad;
    public string sLevelToLoad;

    public bool useIntegerToLoadLevel = false;

    //
    public bool moveSlower;


    //levels
    public static List<string> levels = new List<string>();


    public Rigidbody2D spikesMove;


    private float tiempo = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
        //tiempo += Time.deltaTime;
        //PlayerPrefs.SetFloat("timePlayed", tiempo);
        Application.targetFrameRate = 75;
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

        tiempo = Time.deltaTime;
        PlayerPrefs.SetFloat("timePlayed", PlayerPrefs.GetFloat("timePlayed") + tiempo);
        if (!PauseMenu.GameIsPaused)
        {
            if (!isDeath)
            {
                if (Horizontal != 0)
                {
                    direction = Horizontal;
                }
                ProcesarMovimiento();
                Jump();
                CheckForGround();
                HealthSystem();

            }
        }
    }

    private void DashAndJump() {

        //if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.W) && !isJumping) {
            if (Dash && (Input.GetKey(KeyCode.W) || Input.GetKey("joystick button 0")) && !isJumping) { 
            Rigidbody2D.AddForce(new Vector2(0f, 0.5f), ForceMode2D.Impulse);

        }

    }

    IEnumerator changeDash() {

        yield return new WaitForSeconds(0.08f);
        canAirDash = false;
    }

    private void DashMove() {

        if (Input.GetKey(KeyCode.Space) || Input.GetKey("joystick button 1"))
        {

            Dash_T += 1 * Time.deltaTime;

            if (Dash_T < 0.35f && canAirDash && isJumping)
            {

                Dash = true;
                Animator.SetBool("AirDash", false);
                Animator.SetBool("Dash", true);
                //transform.Translate(Vector3.right * direction * Speed_Dash * Time.fixedDeltaTime);
                Rigidbody2D.velocity = new Vector2(direction * 2, Rigidbody2D.velocity.y);
                //Rigidbody2D.AddForce(new Vector2(direction * 8.0f, 0.01f), ForceMode2D.Impulse);
                Rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

                CapsuleCol.direction = CapsuleDirection2D.Horizontal;
                CapsuleCol.size = DashSize;
                CapsuleCol.offset = DashOff;
                StartCoroutine(changeDash());

            }
            else if (Dash_T < 0.35f && !isJumping)
            {
                Dash = true;
                Animator.SetBool("Dash", true);
                //transform.Translate(Vector3.right * direction * Speed_Dash * Time.fixedDeltaTime);
                Rigidbody2D.velocity = new Vector2(direction * 2, Rigidbody2D.velocity.y);
                //Rigidbody2D.AddForce(new Vector2(direction * 2, 0.01f), ForceMode2D.Force);
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
                Rigidbody2D.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
                canAirDash = false;
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
            //canAirDash = false;
            Rigidbody2D.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
        }



    }


     private void ProcesarMovimiento() {

        Horizontal = Input.GetAxisRaw("Horizontal");


        Vector2 dir = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);

        //Si agrego un if puedo hacer que corra con una letra
        if (moveSlower) {
            Rigidbody2D.AddForce(Vector2.right * dir * 30f);
        }
        else
        {
            Rigidbody2D.AddForce(Vector2.right * dir * 40f);
        }

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        Animator.SetBool("Running", Horizontal != 0.0f);

    }
    
    private void Jump() {

        Animator.SetFloat("jumpVelocity", Rigidbody2D.velocity.y);

        if (!canDobleJump)
        {
            if (!collider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; };
            
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown("joystick button 0") )
        {
            if ((!isJumping && !collider.IsTouchingLayers(LayerMask.GetMask("Wall")) ) || canDobleJump )
            {
                PlayerPrefs.SetInt("jumpsMade", PlayerPrefs.GetInt("jumpsMade") + 1);
              
                SoundManager.PlaySound("jump");
                Rigidbody2D.velocity = (Vector2.up * 3f);
                //Rigidbody2D.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse);
                isJumping = true;
                canDobleJump = false;
                Animator.SetBool("DobleJump", false);
            }
        }

    

    }

    private void FixedUpdate() {


        Rigidbody2D.velocity = new Vector2(Horizontal, Rigidbody2D.velocity.y);
        DashMove();
        FallDown();
        DashAndJump();

    }

    private void CheckForGround()
    {
        if (collider.IsTouchingLayers(LayerMask.GetMask("Ground"))) {

            Animator.SetBool("isGrounded", true);
            Animator.SetBool("AirDash", false);
            Animator.SetBool("DobleJump", false);
            isJumping = false;
            dashAndJump = true;
            canAirDash = false;
            canDobleJump = false;
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

                reduceHealth(3);
                Rigidbody2D.AddForce(new Vector2(0f, 3.0f), ForceMode2D.Impulse);
                // StartCoroutine(Knockback(0.02f, 10, transform.position));
            }
            else
            {

                reduceHealth(3);
                //StartCoroutine(Knockback(0.02f, 350, transform.position));
            }
        }


        else if (col.gameObject.tag == "Parry" || col.gameObject.tag == "Parry 2")


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
        else if (col.gameObject.tag == "Parry3" && isJumping)
        {
            SoundManager.PlaySound("bounce");
            Rigidbody2D.velocity = (Vector2.up * 3f);

        }
        else if (col.gameObject.tag == "Parry4" && isJumping)
        {

            Rigidbody2D.velocity = (Vector2.up * 3f);
            canAirDash = true;
            Animator.SetBool("AirDash", true);

        }
        else if (col.gameObject.tag == "Parry5" && isJumping)
        {

            Rigidbody2D.velocity = (Vector2.up * 3f);
            Animator.SetBool("DobleJump", true);
            canDobleJump = true;

        }
        else if (col.gameObject.tag == "Wheel")
        {

            reduceHealth(3);

        }
        else if (col.gameObject.tag == "Finish") {

            //Invoke("NextLevel", 1f);
            EndLevelScren.levelFinished = true;
            

        }
        else if (col.gameObject.tag == "Parry6" && isJumping)
        {

            Rigidbody2D.velocity = (Vector2.up * 5f);

        }
        else if (col.gameObject.tag == "Patrol")
        {
            Debug.Log("Toca");
            spikesMove.velocity = new Vector2(-60f * Time.fixedDeltaTime, spikesMove.velocity.y);

        }
        else if (col.gameObject.tag == "Krill")
        {
            SoundManager.PlaySound("krill");
            Destroy(col.gameObject);

        }

    }



    IEnumerator Respawn(GameObject obj, float timeToRespawn)
    {

        obj.SetActive(false);
        yield return new WaitForSeconds(timeToRespawn);
        obj.SetActive(true);
    }


    private void GameOver() {
        //Stats.deathCount++;
        PlayerPrefs.SetInt("DeathCount", PlayerPrefs.GetInt("DeathCount")+ 1);
        //PlayerPrefs.SetFloat("timePlayed", PlayerPrefs.GetFloat("timePlayed") + tiempo);
        Rigidbody2D.velocity = new Vector2(0f, 0f);
        Rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY;
        Rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX;
        SoundManager.PlaySound("death");
        isDeath = true;

        //Animator.SetBool("isDeath", true);

        Destroy(this.gameObject);
        FindObjectOfType<GameManager>().EndGame();

    }

    private void FallDown() {

        if (Rigidbody2D.position.y < -2f)
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
