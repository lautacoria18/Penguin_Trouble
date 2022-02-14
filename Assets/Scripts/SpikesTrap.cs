using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesTrap : MonoBehaviour
{

  
    public Rigidbody2D rb;
    public Rigidbody2D player;
public static bool mustRun = false;
    public bool run = mustRun;
    public static float walkSpeed;


 
// Start is called before the first frame update
void Start()
    {

     
        
        

        //rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);

    }

    // Update is called once per frame
    void Update()
    {
        
    }


  
}
