using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SelectLevel : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject selectLevel;
    public Button[] buttons;
    int levelsUnlocked;

    public Text returnB;
    public Text bossB;

    void Start()
    {


        if (Options.language == "Español")
        {

            returnB.text = "Regresar al menú";
            bossB.text = "JEFE";
        }
        else if (Options.language == "English")
        {

            returnB.text = "Return";
            bossB.text = "BOSS";
        }


        levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked", 1);

        for (int i = 0; i < buttons.Length; i++)
        {

            buttons[i].interactable = false;
        }

        for (int i = 0; i < levelsUnlocked; i++)
        {

            buttons[i].interactable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void returnToMM() {

        SceneManager.LoadScene("MainMenu");
    }

   public void chooseLevel(string nivel)
    {
        Difficult.level = nivel;
       
        SceneManager.LoadScene("SelectDifficult");
        Difficult.isNewGame = false;
    }
    


}
