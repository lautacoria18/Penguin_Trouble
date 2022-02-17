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

    public Text deathTB;
    public Text timeTB;
    public Text jumpTB;
    public static int deathCount = 0;
    private string deathCountString = deathCount.ToString();

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
        }
        else if (Options.language == "English")
        {

            deathTB.text = "Death count";
            timeTB.text = "Minutes played";
            jumpTB.text = "Jumps made";

        }


        deathB.text = PlayerPrefs.GetInt("DeathCount").ToString();



        totalTimeFloat = PlayerPrefs.GetFloat("timePlayed") / 60;
        totalTimeInt = (int)totalTimeFloat;
        timeB.text = totalTimeInt.ToString();


        jumpB.text = PlayerPrefs.GetInt("jumpsMade").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MainMenu()
    {
        
        SceneManager.LoadScene("MainMenu");
    }



}
