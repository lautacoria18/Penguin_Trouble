using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Level11Script : MonoBehaviour

{
    public AudioClip levelsSong;
    public AudioClip menuSong;

    public string currentScene;
    public static GameObject music1;
    public static GameObject music2;
    public static GameObject music3;
    public static GameObject music4;


    public AudioSource audio1;
    public AudioSource audio2;
    public AudioSource audio3;
    public AudioSource audio4;



    void Awake()
    {
        music1 = GameObject.FindGameObjectWithTag("Music");
        music2 = GameObject.FindGameObjectWithTag("MusicBoss");
        music3 = GameObject.FindGameObjectWithTag("MusicMM");
        music4 = GameObject.FindGameObjectWithTag("MusicSS");

        audio1 = music1.GetComponent<AudioSource>();
        audio2 = music2.GetComponent<AudioSource>();
        audio3 = music3.GetComponent<AudioSource>();
        audio4 = music4.GetComponent<AudioSource>();




    }

    void Update()
    {
        if (currentScene == "Level_1")
        {
            if (!audio1.isPlaying){

                audio1.Play();
            }
            if (audio3.isPlaying)
            {
                audio3.Stop();
            }
            if (audio2.isPlaying)
            {
                audio2.Stop();
            }
            if (audio4.isPlaying)
            {

                audio4.Stop();
            }
            //music1.SetActive(true);
            //music3.SetActive(false);

        }
        else if (currentScene == "MainMenu")
        {
            if (!audio3.isPlaying)
            {

                audio3.Play();
            }
            if (audio1.isPlaying)
            {
                audio1.Stop();
            }
            if (audio2.isPlaying)
            {
                audio2.Stop();
            }
            if (audio4.isPlaying)
            {

                audio4.Stop();
            }



        }
        else if (currentScene == "Boss1")
        {
             if (audio1.isPlaying)
            {

                audio1.Stop();
                }
            if (!audio2.isPlaying)
            {

                audio2.Play();
            }
            if (audio3.isPlaying)
            {
                audio3.Stop();
            }
            if (audio4.isPlaying)
            {

                audio4.Stop();
            }


        }
        else if (currentScene == "SecretLevel_1")
        {
            if (!audio4.isPlaying)
            {

                audio4.Play();
            }
            if (audio1.isPlaying)
            {

                audio1.Stop();
            }
            if (audio2.isPlaying)
            {

                audio2.Stop();
            }
            if (audio3.isPlaying)
            {
                audio3.Stop();
            }



        }
    }
}
