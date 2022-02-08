using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level11Script : MonoBehaviour

{

    public string currentScene;
    public GameObject music1;
    public GameObject music2;
    public GameObject music3;


    public AudioSource audio1;
    public AudioSource audio2;
    public AudioSource audio3;


    // Start is called before the first frame update
    void Start()
    {
        music1 = GameObject.FindGameObjectWithTag("Music");
        music2 = GameObject.FindGameObjectWithTag("Music11");
        music3 = GameObject.FindGameObjectWithTag("MusicMM");

        //audio1 = music1.GetComponent<AudioSource>();
        //audio2 = music2.GetComponent<AudioSource>();
        //audio3 = music3.GetComponent<AudioSource>();

        Debug.Log(audio1.name);
    }

    // Update is called once per frame
    void Update()
    {

        if (currentScene == "Stage1")
        {
            if (!audio1.isPlaying)
            {
                audio1.Play();
            }
            
                audio2.Stop();
            
           
            
            

        }
        else if (currentScene == "Boss1")
        {
           if  (!audio2.isPlaying)
            {
                audio3.Play();
            }
            if (audio1 != null)
            {

                audio1.Stop();
            }
            if (audio3 != null)
            {

                audio3.Stop();
            }
        }

        else if (currentScene == "Menu")
        {
            if (!audio2.isPlaying)
            {
                audio2.Play();
            }

            audio1.Stop();
        }
     
    }
}
