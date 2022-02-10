using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_1 : MonoBehaviour
{
    public float speed;
    private Animator Animator;

    void Start()
    {

        Animator = GetComponent<Animator>();
    }


    void Update()
    {
        transform.Translate(Vector2.left * speed);

        if (!PinguRun.isDone)
        {
            if (transform.position.x > -3.5f)
            {
                speed = 0f;
                StartCoroutine(Border());
            }
        }
        else {

            speed = -0.03f;
            if (transform.position.x > -1.2f) {
                Animator.SetBool("boom", true);
                speed = -0.0f;
            }
        }
        

    }

    IEnumerator Border()
    {



        yield return new WaitForSeconds(5f);

        speed = 0.007f;
        yield return new WaitForSeconds(15f);
        speed = -0.007f;


    }






        }