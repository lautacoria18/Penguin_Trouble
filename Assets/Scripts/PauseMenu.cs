using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public Text resumeB;
    public Text restartB;
    public Text returnB;


    public GameObject pauseMenuUI;

    public GameObject pauseFirstButton;

    void Start() {

        if (Options.language == "Español")
        {

            resumeB.text = "Resumir";
            restartB.text = "Reiniciar";
            returnB.text = "Regresar al menu";
        }
        else if (Options.language == "English")
        {

            resumeB.text = "Resume";
            restartB.text = "Restart";
            returnB.text = "Main menu";

        }


    }
    // Update is called once per frame
    void Update()
    {
        if (!EndLevelScren.levelFinished)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {

                if (GameIsPaused)
                {

                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }


    void Pause()
    {


        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(pauseFirstButton);

    }

    public void Restart() {
        Debug.Log("restart");
        Time.timeScale = 1f;
        GameIsPaused = false;
        FindObjectOfType<GameManager>().Restart();
    }


    public void MainMenu() {
        Debug.Log("main menu");
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene("MainMenu");
    }
}
