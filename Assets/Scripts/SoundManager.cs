using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{


    public static AudioClip playerJump, playerDeath, playerBounce;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        playerJump = Resources.Load<AudioClip>("Jump");
        playerDeath = Resources.Load<AudioClip>("Death");
        playerBounce = Resources.Load<AudioClip>("Bounce");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        


    }


    public static void PlaySound(string clip) {

        switch (clip) {

            case "jump":
                audioSrc.PlayOneShot(playerJump);
                break;
            case "death":
                audioSrc.PlayOneShot(playerDeath);
                break;
            case "bounce":
                audioSrc.PlayOneShot(playerBounce);
                break;

        }
    }
}
