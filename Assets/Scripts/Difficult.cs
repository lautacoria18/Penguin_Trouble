using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Difficult : MonoBehaviour
{
    public static string level;

    // Start is called before the first frame update
    void Start()
    {

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
