using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesRunner : MonoBehaviour
{

    public float speed;
    public bool isVertical;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isVertical)
        {
            transform.Translate(Vector2.left * speed);
        }
        else {
            transform.Translate(Vector2.down * speed);
        }
    }
}
