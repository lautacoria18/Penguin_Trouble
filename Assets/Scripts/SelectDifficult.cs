using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectDifficult : MonoBehaviour
{
    public GameObject[] itemsEasyMode;
    public GameObject[] itemsHardMode;
    public static int difficult = 1;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (difficult == 1)
        {

            for (int i = 0; i < itemsEasyMode.Length; i++)
            {

                itemsEasyMode[i].SetActive(false);
            }

        }
        else if (difficult == 3) {

            for (int i = 0; i < itemsHardMode.Length; i++)
            {

                itemsHardMode[i].SetActive(true);
            }

        }


    }
}
