using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecretLevelMusicScript : MonoBehaviour
{
    public static SecretLevelMusicScript inst4;

    public AudioClip secretLevel1Song;

    public AudioSource audioSc;
    // Start is called before the first frame update
    void Awake()
    {

        audioSc = GetComponent<AudioSource>();


        secretLevel1Song = Resources.Load<AudioClip>("SecretLevel1");
        audioSc.clip = secretLevel1Song;

        if (SecretLevelMusicScript.inst4 == null)
        {

            SecretLevelMusicScript.inst4 = this;

            DontDestroyOnLoad(gameObject);


            audioSc.Play();

        }
        else
        {



            Destroy(gameObject);
        }

    }
}
