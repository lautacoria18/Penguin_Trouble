using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject mainMenu;

    void Awake()
    {

        Application.targetFrameRate = Options.fps;

        Screen.SetResolution(Options.W, Options.H, true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void newGame() {

        Difficult.level = "Level_1";
        SceneManager.LoadScene("SelectDifficult");

    }

    public void selectLevel()
    {

        SceneManager.LoadScene("SelectLevel");

    }
     public void options()
        {

            SceneManager.LoadScene("Options");

        }
    }
