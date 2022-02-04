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

    void Start()
    {

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


   public void chooseLevel(string nivel)
    {

        SceneManager.LoadScene(nivel);
    }
    


}
