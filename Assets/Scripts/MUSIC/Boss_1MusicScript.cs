using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Boss_1MusicScript : MonoBehaviour
{
    public static Boss_1MusicScript inst3;

    public AudioClip levelsSong;
    public AudioClip menuSong;
    public AudioClip boss1Song;

    public AudioSource audioSc;



    void Awake()
    {

        audioSc = GetComponent<AudioSource>();

        levelsSong = Resources.Load<AudioClip>("Nivel");
        menuSong = Resources.Load<AudioClip>("Menu");
        boss1Song = Resources.Load<AudioClip>("Boss1");
        audioSc.clip = boss1Song;

        if (Boss_1MusicScript.inst3 == null)
        {

            Boss_1MusicScript.inst3 = this;

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
}
