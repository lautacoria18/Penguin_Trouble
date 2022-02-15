 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    

 void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() {

        if (PinguRun.isDone) {

            this.spriteRenderer.enabled = true;
        }
        else {
            this.spriteRenderer.enabled = false;

        }
    }

    
}
