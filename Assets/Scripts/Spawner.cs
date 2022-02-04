using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spikes;
    public GameObject wheel;
    public GameObject blueParry;

    public float time;

    void Start()
    {
        StartCoroutine(Border(spikes, time));

    }


    // Update is called once per frame
    void Update()
    {
        /*
        if (timeBtwSpawn <= 0)
        {
            Instantiate(spikes, transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
            if (startTimeBtwSpawn > minTime)
            {

                startTimeBtwSpawn -= decreaseTime;

            }


        }
        else {

            timeBtwSpawn -= Time.deltaTime;
        }
    */
    }




    IEnumerator Border(GameObject parry, float time)
    {
        

    
            yield return new WaitForSeconds(time);
        Instantiate(parry, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(6f);
        this.gameObject.SetActive(false);
        //StartCoroutine(Border(parry));   // This makes it loop itself as long as canBlink is true

    }
}