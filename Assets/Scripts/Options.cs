using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    

    public Text instruction;
    public Text resolution;
    public GameObject confirmWindow;

    //Values
    public bool is60 = true;
    public static int currentFps = 75;
    public static int fps = 75;
    public static string currentText = "60 FPS";
    public static string text = "60 FPS";

    //Screen
    public bool is720 = true;
    public static int currentW = 1360;
    public static int W = 1360;
    public static int currentH = 768;
    public static int H = 768;
    public static string currentRes = "1360 x 768";
    public static string Res = "1360 x 768";



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


    }

}
