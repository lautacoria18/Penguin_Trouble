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
    public static string currentText = "60 FPS";
    public static string text = "60 FPS";

    //Resolution
    public bool is720 = true;
    public static int currentW = 1360;
    public static int W = 1360;
    public static int currentH = 768;
    public static int H = 768;
    public static string currentRes = "1360 x 768";
    public static string Res = "1360 x 768";


    //Screen
    public bool isFull = true;

    public static bool currentScreenMode = true;
    public static bool screenMode = true;
    public static string currentScreenText = "Fullscreen";
    public static string ScreenText  = "Fullscreen";


    private bool hasBeenChanged = false;


    void Start() {

        //fps
        instruction.text = text;
        

        if (text == "60 FPS")
        {

            is60 = true;

        }
        else {
            is60 = false;
        }

        resolution.text = Res;

        if (Res == "1360 x 768")
        {

            is720 = true;

        }
        else
        {
            is720 = false;
        }

        buttonScreen.text = ScreenText;


        if (ScreenText == "Fullscreen")
        {

            isFull = true;

        }
        else
        {
            isFull = false;
        }


        setLanguage();

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void changeText()
    {

        if (is60)
        {

            instruction.text = "30 FPS";
            currentText = "30 FPS";
            currentFps = 45;
            is60 = false;
        }
        else
        {
            instruction.text = "60 FPS";
            currentText = "60 FPS";
            currentFps = 75;
            is60 = true;


        }
    }
    public void changeResolution() {

        if (is720)
        {
            resolution.text = "1920 x 1080";
            currentRes = "1920 x 1080";
            currentW = 1920;
            currentH = 1080;
            is720 = false;


        }
        else {
            resolution.text = "1360 x 768";
            currentRes = "1360 x 768";
            currentW = 1360;
            currentH = 768;
            is720 = true;
        }
    }

    public void changesScreen() {

        if (isFull)
        {

            buttonScreen.text = "Windowed";
            currentScreenText = "Windowed";
            currentScreenMode = false;
            isFull = false;
        }
        else {
            buttonScreen.text = "Fullscreen";
            currentScreenText = "Fullscreen";
            currentScreenMode = true;
            isFull = true;

        }


    }

    public void changeLanguage() {

        if (language == "English")
        {
            language = "Español";
            buttonLanguage.text = "Español";
            resLang.text = "Resolución";
            screenLang.text = "Pantalla";
            languageLang.text = "Lenguaje";
            applyLang.text = "Aplicar cambios";
            backToMenuLang.text = "Regresar al menú";
}
        else if (language == "Español") {
            language = "English";
            buttonLanguage.text = "English";
            resLang.text = "Resolution";
            screenLang.text = "Screen";
            languageLang.text = "Language";
            applyLang.text = "Apply Changes";
            backToMenuLang.text = "Back to the Menu";

        }

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

        public void applyChanges()
    {
        fps = currentFps;
        Application.targetFrameRate = fps;
        text = currentText;
        instruction.text = text;


        //
        W = currentW;
        H = currentH;
        Screen.SetResolution(W, H, true);
        Res = currentRes;
        resolution.text = Res;

        //
        screenMode = currentScreenMode;
        Screen.SetResolution(W, H, screenMode);
        ScreenText = currentScreenText;
        buttonScreen.text = ScreenText;


        hasBeenChanged = true;


    }

    public void returnToMM(){


        if (!hasBeenChanged) {

            setTextToDefault();
 
        }

        SceneManager.LoadScene("MainMenu");

    }

    public void setTextToDefault() {


        instruction.text = text;
        currentText = text;
        currentFps = fps;

        resolution.text = Res;
        currentRes = Res;
        currentW = W;
        currentH = H;

        buttonScreen.text = ScreenText;
        currentScreenText = ScreenText;
        currentScreenMode = screenMode;




    }

}
