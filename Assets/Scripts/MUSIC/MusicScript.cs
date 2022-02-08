using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MusicScript : MonoBehaviour
{

    public static MusicScript inst;


   


    void Awake() {

    
        
            if (MusicScript.inst == null)
            {

                MusicScript.inst = this;

                DontDestroyOnLoad(gameObject);

          

        }
            else
            {

 
        
            Destroy(gameObject);
            }

     


    }
}
