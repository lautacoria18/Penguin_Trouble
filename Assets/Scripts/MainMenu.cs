using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void newGame() {

        SceneManager.LoadScene("Level_1");

    }

    public void selectLevel()
    {

        SceneManager.LoadScene("SelectLevel");

    }
}
