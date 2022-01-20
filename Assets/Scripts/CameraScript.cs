using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject Pingu;

    void Update()
    {
        Vector3 position = transform.position;
        position.x = Pingu.transform.position.x;
        transform.position = position;
        
    }
}
