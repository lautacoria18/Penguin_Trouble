using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public GameObject Pingu;
    public Transform target;
    public bool canMoveHorizontal;
    public bool disableMoveVertical;

    void Update()
    {
        if (canMoveHorizontal)
        {
            Vector3 position = transform.position;
            position.x = Pingu.transform.position.x;
            transform.position = position;
        }

        if(!disableMoveVertical)
        transform.position = new Vector3 (
            transform.position.x,
            Mathf.Clamp(target.position.y, 0f, 10f),
            transform.position.z);

            
    }
}
