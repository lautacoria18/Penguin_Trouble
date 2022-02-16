using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Stats : MonoBehaviour
{

    public Text deathB;
    public static int deathCount = 0;
    private string deathCountString = deathCount.ToString();


    // Start is called before the first frame update
    void Start()
    {
        deathB.text = PlayerPrefs.GetInt("DeathCount").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MainMenu()
    {
        
        SceneManager.LoadScene("MainMenu");
    }



}
