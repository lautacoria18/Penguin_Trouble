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


    //SecretLevel
    public string secretLevelToLoad;
    public Animator transitionAnim;


    //Moverse lento depende el nivel
    public bool moveSlower;

    //Activar trampa
    public Rigidbody2D spikesMove;

    //Tiempo acumulado
    private float tiempo = 0f;


    //Krill obtenido
    private bool krill;


    // Start is called before the first frame update
    void Start()
    {
        
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


        Scene level = SceneManager.GetActiveScene();

        
        if (PlayerPrefs.GetInt(level.name) == 1)
        {
            krill = true;
            GameObject krillObj = GameObject.FindGameObjectWithTag("Krill");
            Destroy(krillObj);
        }
        else {
            krill = false;

        }      
    }

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
        switch (col.gameObject.tag)
        {
            case "Spike":
                if (Dash)
                {

                    reduceHealth(3);
                    Rigidbody2D.AddForce(new Vector2(0f, 3.0f), ForceMode2D.Impulse);
                }
                else
                { 
                    reduceHealth(3);
                }
                break;

            case "Parry":
                if (isJumping)
                {
                    Rigidbody2D.velocity = (Vector2.up * 3f);
                    StartCoroutine(Respawn(col.gameObject, 5f));
                }
                break;

            case "Parry 2":
                if (isJumping)
                {
                    Rigidbody2D.velocity = (Vector2.up * 3f);
                    StartCoroutine(Respawn(col.gameObject, 5f));
                }
                break;

            case "Parry3":
                if (isJumping)
                {
                    SoundManager.PlaySound("bounce");
                    Rigidbody2D.velocity = (Vector2.up * 3f);
                }
                break;

            case "Parry4":
                if (isJumping)
                {
                    Rigidbody2D.velocity = (Vector2.up * 3f);
                    canAirDash = true;
                    Animator.SetBool("AirDash", true);
                }
                break;

            case "Parry5":
                if (isJumping)
                {
                    Rigidbody2D.velocity = (Vector2.up * 3f);
                    Animator.SetBool("DobleJump", true);
                    canDobleJump = true;
                }
                break;

            case "Parry6":
                if (isJumping)
                {
                    SoundManager.PlaySound("bounce");
                    Rigidbody2D.velocity = (Vector2.up * 5f);
                }
                break;

            case "Wheel":
                reduceHealth(3);
                break;

            case "Finish":
                krillObtained();
                EndLevelScren.levelFinished = true;
                levelWon();
                break;

            case "Patrol":
                spikesMove.velocity = new Vector2(-60f * Time.fixedDeltaTime, spikesMove.velocity.y);
                break;

            case "Patrol2":
                spikesMove.velocity = new Vector2(spikesMove.velocity.x, 30f * Time.fixedDeltaTime);
                break;

            case "Krill":
                SoundManager.PlaySound("krill");
                krill = true;
                Destroy(col.gameObject);
                break;

            case "SecretLevel":

                StartCoroutine(LoadScene());
                break;


            case "Parachute":
                Destroy(col.gameObject);
                Rigidbody2D.gravityScale = 0.03f;
                Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, -1f * Time.fixedDeltaTime);
                Animator.SetBool("parachute", true);
                break;

            case "Camera":

                CameraScript.canMoveHorizontal = true;
                CameraScript.returnToCurrent = false;
                break;

            case "SpikeFake":

                CameraScript.canMoveHorizontal = false;
                CameraScript.returnToCurrent = true;
                break;

            default:
                break;
        }
    }

    void levelWon()
    {

        string currentLevel = SceneManager.GetActiveScene().name;

        if (currentLevel == "SecretLevel_1")
        {
            PlayerPrefs.SetInt("secretLevel1", 1);
        }
        else if (currentLevel == "SecretLevel_2")
        {
            PlayerPrefs.SetInt("secretLevel2", 1);
        }
        else
        {
            regularLevelWon();
        }

    }
    void regularLevelWon() { 
        int currentLevelN = SceneManager.GetActiveScene().buildIndex;

        if (currentLevelN >= PlayerPrefs.GetInt("levelsUnlocked"))
        {
            PlayerPrefs.SetInt("levelsUnlocked", currentLevelN + 1);

        }
    }

    void krillObtained()
    {
        Scene level = SceneManager.GetActiveScene();
        if (krill && PlayerPrefs.GetInt(level.name) != 1) { 
        

        PlayerPrefs.SetInt(level.name, 1);

        PlayerPrefs.SetInt("krillsObtained", PlayerPrefs.GetInt("krillsObtained") +1 );
        }
    }


    IEnumerator Respawn(GameObject obj, float timeToRespawn)
    {

        obj.SetActive(false);
        yield return new WaitForSeconds(timeToRespawn);
        obj.SetActive(true);
    }


    private void GameOver() {

        PlayerPrefs.SetInt("DeathCount", PlayerPrefs.GetInt("DeathCount")+ 1);

        SoundManager.PlaySound("death");
        isDeath = true;
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

        float timer = 0;

        while (knockDur > timer) {

            timer += Time.deltaTime;
            Rigidbody2D.AddForce(new Vector2(0f, 5.0f), ForceMode2D.Impulse);

        }
        yield return 0;
    }

    IEnumerator LoadScene() {

        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(secretLevelToLoad);

    }

}
