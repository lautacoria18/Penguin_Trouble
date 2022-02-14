using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicScript11 : MonoBehaviour
{

    public static MusicScript11 inst;

    public AudioClip levelsSong;
    public AudioClip menuSong;

    public static AudioSource audioSc;



    void Awake()
    {

        audioSc = GetComponent<AudioSource>();
        levelsSong = Resources.Load<AudioClip>("Nivel");
        menuSong = Resources.Load<AudioClip>("Menu");
        audioSc.clip = menuSong;

        if (MusicScript11.inst == null)
        {

            MusicScript11.inst = this;

            DontDestroyOnLoad(gameObject);

            Scene level = SceneManager.GetActiveScene();

            //PlaySongBySceneName(level.name);

            Debug.Log(level.name);
            audioSc.Play();
        }
        else
        {



            Destroy(gameObject);
        }

    }

 
    private void PlaySongBySceneName(string levelName)
    {

        switch (levelName)
        {
            case "Level_2":
                audioSc.clip = levelsSong;
                audioSc.Play();
                break;
            case "MainMenu":
                audioSc.clip = menuSong;
                audioSc.Play();
                break;
            case "Level_1":
                audioSc.clip = levelsSong;
                audioSc.Play();
                break;
            case "SelectDifficult":
                audioSc.clip = menuSong;
                audioSc.Play();
                break;
            default:
                // Do whatever
                break;
        }

        // audioSource.Play();

    }
}
