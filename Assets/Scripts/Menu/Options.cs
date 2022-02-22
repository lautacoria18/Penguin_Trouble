using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    
    public static string language = "English";


    public Text instruction;
    public Text resolution;
    public Text buttonScreen;
    public Text buttonLanguage;

    public Text resLang;
    public Text screenLang;
    public Text languageLang;
    public Text applyLang;
    public Text backToMenuLang;

    //Values
    public bool is60 = true;
    public static int currentFps = 75;
    public static int fps = 75;


    //Resolution
    public static bool is720 = true;
    public static int W = 1360;
    public static int H = 768;



    //Screen
    public static bool isFull = true;

    public static bool screenMode = true;





    void Start() {

        setResolution2();
        setLanguage();
        setScreen();

    }




    public void changeResolution() {

        if (is720)
        {
            is720 = false;

        }
        else {

            is720 = true;

        }
        setResolution2();
    }

    public void setResolution2() {

        if (is720)
        {

            resolution.text = "1360 x 768";
            W = 1360;
            H = 768;
            Screen.SetResolution(W, H, isFull);
        }
        else {
            resolution.text = "1920 x 1080";
            W = 1920;
            H = 1080;
            Screen.SetResolution(W, H, isFull);
        }


    }

    public void changesScreen() {

        if (isFull)
        {
            isFull = false;

        }
        else {
            isFull = true;
        }
        setScreen();
    }


    public void setScreen() {

        if (isFull)
        {
            buttonScreen.text = "Full";
            Screen.SetResolution(W, H, true);
        }
        else {
            buttonScreen.text = "Windowed";
            Screen.SetResolution(W, H, false);
        }


    }

    public void changeLanguage() {

        if (language == "English")
        {
            language = "Español";
        }
        else if (language == "Español") {
            language = "English";
        }
        setLanguage();

    }

    public void setLanguage()
    {
        if (language == "Español")
        {
            language = "Español";
            buttonLanguage.text = "Español";
            resLang.text = "Resolución";
            screenLang.text = "Pantalla";
            languageLang.text = "Lenguaje";
            applyLang.text = "Aplicar cambios";
            backToMenuLang.text = "Regresar al menú";
        }
        else if (language == "English")
        {
            language = "English";
            buttonLanguage.text = "English";
            resLang.text = "Resolution";
            screenLang.text = "Screen";
            languageLang.text = "Language";
            applyLang.text = "Apply Changes";
            backToMenuLang.text = "Back to the Menu";



        }
    }


    public void returnToMM(){



        SceneManager.LoadScene("MainMenu");

    }


}
