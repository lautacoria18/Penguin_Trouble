using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{

    public Text tyB;
    public Text stB;
    public Text returnB;

    void Start()
    {

        if (Options.language == "Español")
        {

            tyB.text = "Gracias por jugar <3 ! ";
            stB.text = "Capitulos 2 y 3 muy pronto!";
            returnB.text = "Regresar al menu";
        }
        else if (Options.language == "English")
        {

            tyB.text = "Thank you for playing <3 !";
            stB.text = "Stage 2 & 3 coming soon!";
            returnB.text = "Back to the menu";

        }
    }


    public void returnToMM()
    {

        SceneManager.LoadScene("MainMenu");
    }

}
