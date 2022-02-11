using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Difficult : MonoBehaviour
{
    public static string level;


    public Text returnB;
    public Text easyB;
    public Text normalB;
    public Text hardB;
    // Start is called before the first frame update
    void Start()
    {
        {
            if (Options.language == "Español")
            {

                returnB.text = "Regresar al menú";
                easyB.text = "Facil";
                normalB.text = "Normal";
                hardB.text = "Dificil";
            }
            else if (Options.language == "English")
            {

                returnB.text = "Return";
                easyB.text = "Easy";
                normalB.text = "Normal";
                hardB.text = "Hard";
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }


    public void loadLevel(int dif)
    {
        SelectDifficult.difficult = dif;
        SceneManager.LoadScene(level);
    }


    public void returnToSelect(){

            SceneManager.LoadScene("SelectLevel");
}

}
