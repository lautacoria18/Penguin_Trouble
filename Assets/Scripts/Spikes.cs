using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private PinguWalk player;

    void Start() {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PinguWalk>();


    }

    void OnTrigger2D(Collider2D col) {

        if (col.CompareTag("Player")) {

            player.reduceHealth(2);
            Debug.Log("Anda?");

        }
    }
}
