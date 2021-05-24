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
        Player.GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Dir *= -1.0f;
            if (Player.transform.localEulerAngles.y == 180) Player.transform.localEulerAngles = Vector3.zero;
            else if (Player.transform.localEulerAngles.y == 0) Player.transform.localEulerAngles = new Vector3(0, 180, 0);
        }

        if (Input.GetMouseButtonDown(1))
        {
            jump = true;
        }
        if (jump)
        {
            Player.GetComponent<Rigidbody2D>().gravityScale = -1;
            jump = false;
        }

        if (Player.transform.position.y > 2.7f)
        {
            Player.GetComponent<Rigidbody2D>().gravityScale = 1;
        }


        Player.transform.position += new Vector3(Dir, 0, 0) * Speed;
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Ground")
        {
            Debug.Log("¹Ù´Ú");
        }
    }
}
