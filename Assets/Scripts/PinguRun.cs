using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PinguRun : MonoBehaviour
{

    private Rigidbody2D Rigidbody2D;
    private float Horizontal;
    private Animator Animator;

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


    public string sLevelToLoad;


    //
    public bool moveSlower;


    public static bool isDone = false;

    public GameObject obj;

    //Krill obtenido
    private bool krill;

    //Tiempo acumulado
    private float tiempo = 0f;




    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 75;
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        collider = gameObject.GetComponent<Collider2D>();

        //
        Scene level = SceneManager.GetActiveScene();
        if (PlayerPrefs.GetInt(level.name) == 1)
        {
            krill = true;
            GameObject krillObj = GameObject.FindGameObjectWithTag("Krill");
            Destroy(krillObj);
        }
        else
        {
            krill = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        tiempo = Time.deltaTime;
        PlayerPrefs.SetFloat("timePlayed", PlayerPrefs.GetFloat("timePlayed") + tiempo);
        if (!PauseMenu.GameIsPaused)
        {
            if (Horizontal != 0)
            {
                direction = Horizontal;
            }
            if (!isDone)
            {
                ProcesarMovimiento();
                Jump();
                CheckForGround();
                HealthSystem();
            }
            else {

                transform.Translate(Vector2.right * 0.01f);

            }
        }
        }

    
    private void ProcesarMovimiento()
    {

        Horizontal = Input.GetAxisRaw("Horizontal");

        Vector2 dir = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);

            Rigidbody2D.AddForce(Vector2.right * dir * 5f);

        Animator.SetBool("Running", Horizontal != 0.0f);

    }

    private void Jump()
    {
        Animator.SetFloat("jumpVelocity", Rigidbody2D.velocity.y);

        if (!canDobleJump)
        {
            if (!collider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; };

        }

        if (Input.GetKeyDown(KeyCode.W))
        {

            if (!isJumping && !collider.IsTouchingLayers(LayerMask.GetMask("Wall")))
            {
                SoundManager.PlaySound("jump");
                Rigidbody2D.velocity = (Vector2.up * 3f);
                //Rigidbody2D.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse);
                isJumping = true;
                canDobleJump = false;
                Animator.SetBool("DobleJump", false);
            }
        }



    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal, Rigidbody2D.velocity.y);
    }

    private void CheckForGround()
    {
        if (collider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {

            Animator.SetBool("isGrounded", true);
            Animator.SetBool("AirDash", false);
            Animator.SetBool("DobleJump", false);
            isJumping = false;
            canAirDash = false;
        }
        else
        {
            Animator.SetBool("isGrounded", false);
            isJumping = true;
        }

    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Spike")
        {
                reduceHealth(3);
        }
        else if (col.gameObject.tag == "Wheel")
        {
            reduceHealth(3);
        }
        else if (col.gameObject.tag == "Finish")
        {
            krillObtained();
                isDone = true;
            obj = GameObject.FindGameObjectWithTag("End");
            Destroy(obj);
            Invoke("NextLevel", 9f);
                      
        }

        else if (col.gameObject.tag == "Krill")
        {
            SoundManager.PlaySound("krill");
            krill = true;
            Destroy(col.gameObject);
            
        }

    }
    private void NextLevel()
    {


        ///
        int currentLevel = SceneManager.GetActiveScene().buildIndex;


        if (currentLevel >= PlayerPrefs.GetInt("levelsUnlocked"))
        {
            PlayerPrefs.SetInt("levelsUnlocked", currentLevel + 1);

        }

        isDone = false;
        SceneManager.LoadScene(sLevelToLoad);

    }


    void krillObtained()
    {
        Scene level = SceneManager.GetActiveScene();
        if (krill && PlayerPrefs.GetInt(level.name) != 1)
        {


            PlayerPrefs.SetInt(level.name, 1);

            PlayerPrefs.SetInt("krillsObtained", PlayerPrefs.GetInt("krillsObtained") + 1);
        }
    }




    private void GameOver()
    {
        SoundManager.PlaySound("death");
        Destroy(this.gameObject);
        isDone = false;
        FindObjectOfType<GameManager>().EndGame();

    }

    private void HealthSystem()
    {

        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        if (health <= 0)
        {

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

    public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir)
    {

        Debug.Log("Funciona?");

        float timer = 0;

        while (knockDur > timer)
        {

            timer += Time.deltaTime;


            Rigidbody2D.AddForce(new Vector2(0f, 5.0f), ForceMode2D.Impulse);

        }
        yield return 0;


    }

}
