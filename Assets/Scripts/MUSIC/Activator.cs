using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour


{

    public GameObject music1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        music1.SetActive(true);
    }
}
