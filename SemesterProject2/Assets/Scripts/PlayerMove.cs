using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMove : MonoBehaviour
{
    public GameObject Player;
    

    float Dir = 1.0f;
    float Speed = 0.1f;
    public bool jump = false;


    // Start is called before the first frame update
    void Start()
    {
        //Player.transform.position = new Vector3(0.0f,0.0f,0);
        Player.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Dir *= -1.0f;
        }

       // if (Input.GetMouseButtonDown(1))
        //{
         //   jump = true;
        //}
        if (jump)
        {
            Player.GetComponent<Rigidbody2D>().gravityScale = -1;

            if (Player.transform.position.y > 1.0f)
            {
                Player.GetComponent<Rigidbody2D>().gravityScale = 1;
            }
            else if(Player.transform.position.y < 0.0f)
            {
                jump = false;
                Player.GetComponent<Rigidbody2D>().gravityScale = 0;
            }
        }
        Player.transform.position += new Vector3(Dir, 0, 0) * Speed;
    }
}
