using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SelectLevel : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject selectLevel;

    List<string> levelsBeaten = new List<string>();

    void Start()
    {
        levelsBeaten = PinguWalk.levels;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void chooseLevel(string nivel)
    {
        if (levelsBeaten.Contains(nivel))
        {

            SceneManager.LoadScene(nivel);
        }
        else {
            Debug.Log("No ganaste el nivel pipi");
        }

    }
}
