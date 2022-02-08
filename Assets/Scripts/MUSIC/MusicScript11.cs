using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript11 : MonoBehaviour
{

    public static MusicScript11 inst;





    void Awake()
    {



        if (MusicScript11.inst == null)
        {

            MusicScript11.inst = this;

            DontDestroyOnLoad(gameObject);



        }
        else
        {



            Destroy(gameObject);
        }




    }
}
