using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public GameObject mainMenu;


    public Text newGameB;
    public Text selectLevelB;
    public Text optionsB;

    void Awake()
    {

        Application.targetFrameRate = Options.fps;

        Screen.SetResolution(Options.W, Options.H, Options.screenMode);
    }

    // Start is called before the first frame update
    void Start()
    {
        CameraScript.canMoveHorizontal = true;
        CameraScript.returnToCurrent = false;

        if (Options.language == "Español") {

            newGameB.text = "Nuevo juego";
            selectLevelB.text = "Seleccionar nivel";
            optionsB.text = "Opciones";
        }
        else if (Options.language == "English"){

            newGameB.text = "New game";
            selectLevelB.text = "Select level";
            optionsB.text = "Options";

        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void newGame() {

        Difficult.level = "Level_1";
        Difficult.isNewGame = true;
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

    public void deleteData()
    {

        PlayerPrefs.DeleteAll();

    }


    public void statsScene()
    {

        SceneManager.LoadScene("Stats");

    }

    public void quitGame() {

        Application.Quit();
    }

}
