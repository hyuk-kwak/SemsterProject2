using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour
{
    public int moveSpeed;
    Vector3 movePos;
    float timeCheck;

    void Start()
    {
        timeCheck = 0;
        movePos = new Vector3(1, 0, 0);
    }
    void Update()
    {
        timeCheck += Time.deltaTime;

        transform.position += movePos * Time.deltaTime * moveSpeed;
        
        
        if (timeCheck >= 20)
        {
            movePos *= -1;
            timeCheck = 0;
        }


    }
}
