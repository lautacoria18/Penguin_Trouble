using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryTrap : MonoBehaviour
{

    public static bool canBlink = true;
    public GameObject obj;

    void Start()
    {

        canBlink = true;
        StartCoroutine(Border());

        

    }

    void Update()
    {

    }


    IEnumerator Border()
    {
        if (canBlink)
        {
            obj.SetActive(true);
            yield return new WaitForSeconds(2f);
            obj.SetActive(false);
            StartCoroutine(Border());   
        }
    }


}
