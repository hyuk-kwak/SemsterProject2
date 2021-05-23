using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMove : MonoBehaviour
{
    public int moveSpeed;
    public Vector3 moveVec;
    public Vector3 currentVec;

    void Start()
    {
        currentVec = transform.position;
    }
    void Update()
    {
        
        moveVec = new Vector3(128, 0, 0);
        transform.position += Vector3.left * Time.deltaTime * moveSpeed;
        if (transform.position.x <= currentVec.x - moveVec.x)
        {

            transform.position +=  moveVec;
            
        }


    }
}
