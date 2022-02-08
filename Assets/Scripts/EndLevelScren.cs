using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndLevelScren : MonoBehaviour
{

    public static bool levelFinished = false;
    public GameObject EndLevelScreen;
    public string sLevelToLoad;

    void Start()
    {

    }

    void Update()
    {
        if (levelFinished)
        {

            Pause();

        }

    }

    public void NextLevel()
    {


        int currentLevel = SceneManager.GetActiveScene().buildIndex;


        if (currentLevel >= PlayerPrefs.GetInt("levelsUnlocked"))
        {
            PlayerPrefs.SetInt("levelsUnlocked", currentLevel + 1);

        }
   
        Resume();
        SceneManager.LoadScene(sLevelToLoad);

    }

    void Pause()
    {
        EndLevelScreen.SetActive(true);
        Time.timeScale = 0f;
        PauseMenu.GameIsPaused = true;
        
    }

    public void Resume()
    {

        EndLevelScreen.SetActive(false);
        Time.timeScale = 1f;
        PauseMenu.GameIsPaused = false;
        levelFinished = false;

    }

    public void Restart()
    {
        Time.timeScale = 1f;
        PauseMenu.GameIsPaused = false;
        FindObjectOfType<GameManager>().Restart();
        levelFinished = false;
    }


    public void MainMenu()
    {
        Time.timeScale = 1f;
        PauseMenu.GameIsPaused = false;
        levelFinished = false;
        SceneManager.LoadScene("MainMenu");

    }


}
