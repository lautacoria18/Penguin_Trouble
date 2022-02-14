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

    public static GameObject music3;


    public AudioSource audio1;
    //public AudioSource audio2;
   public AudioSource audio3;


    // Start is called before the first frame update
    void Awake()
    {
        music1 = GameObject.FindGameObjectWithTag("Music");
        //music2 = GameObject.FindGameObjectWithTag("Music11");
        music3 = GameObject.FindGameObjectWithTag("MusicMM");

        audio1 = music1.GetComponent<AudioSource>();
        audio3 = music3.GetComponent<AudioSource>();


        //SceneManager.sceneLoaded += OnSceneLoaded;
       

    }
    /*
        void OnEnable()
        {
            Debug.Log("OnEnable called");
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            Debug.Log("ghafadfg");
            if (scene.name == "Level_1")
            {
                audio1.Play();
                if (!audio3.isPlaying)
                {
                    audio3.Stop();
                }
                //music1.SetActive(true);
                //music3.SetActive(false);

            }
            else if (scene.name == "MainMenu")
            {
                audio3.Play();
                if (!audio1.isPlaying)
                {
                    audio1.Stop();
                }
                //music3.SetActive(true);
                //music1.SetActive(false);




            }
        }
        */
    // Update is called once per frame
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


        }
    }
}
