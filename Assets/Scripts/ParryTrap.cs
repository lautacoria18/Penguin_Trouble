using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryTrap : MonoBehaviour
{

    public static bool canBlink = true;
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        //SpawnAndRespawn();
        
        canBlink = true;
        StartCoroutine(Border());

        

    }

    // Update is called once per frame
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
            StartCoroutine(Border());   // This makes it loop itself as long as canBlink is true
        }
    }


}
