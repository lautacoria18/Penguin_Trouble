using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScriptMM : MonoBehaviour
{
    public static MusicScriptMM inst;





    void Awake()
    {



        if (MusicScriptMM.inst == null)
        {

            MusicScriptMM.inst = this;

            DontDestroyOnLoad(gameObject);



        }
        else
        {



            Destroy(gameObject);
        }




    }
}
