using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour


{

    public GameObject audio;
    // Start is called before the first frame update
    void Start()
    {
        audio.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //music1.SetActive(true);
    }
}
