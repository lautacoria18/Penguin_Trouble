using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Stats : MonoBehaviour
{

    public Text deathB;
    public Text timeB;
    public Text jumpB;
    public Text krillsB;

    public Text deathTB;
    public Text timeTB;
    public Text jumpTB;
    public Text krillTB;
    public Text returnTB;



    private float totalTimeFloat;
    private int totalTimeInt;


    // Start is called before the first frame update
    void Start()
    {


        if (Options.language == "Español")
        {

            deathTB.text = "Contador de muertes";
            timeTB.text = "Minutos jugados";
            jumpTB.text = "Saltos realizados";
            krillTB.text = "krills obtenidos";
            returnTB.text = "regresar al menu";
        }
        else if (Options.language == "English")
        {

            deathTB.text = "Death count";
            timeTB.text = "Minutes played";
            jumpTB.text = "Jumps made";
            krillTB.text = "krills obtained";
            returnTB.text = "return";

        }


        deathB.text = PlayerPrefs.GetInt("DeathCount").ToString();



        totalTimeFloat = PlayerPrefs.GetFloat("timePlayed") / 60;
        totalTimeInt = (int)totalTimeFloat;
        timeB.text = totalTimeInt.ToString();


        jumpB.text = PlayerPrefs.GetInt("jumpsMade").ToString();


        krillsB.text = PlayerPrefs.GetInt("krillsObtained").ToString();
    }


    public void MainMenu()
    {
        
        SceneManager.LoadScene("MainMenu");
    }



}
