using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMove : MonoBehaviour
{
    public GameObject Player;
    Animator PlayerMotion;
    bool isWalk = true;
    bool isAttack = false;
    bool isSkill_1 = false;
    bool isSkill_2 = false;

    float Dir = 1.0f;
    float Speed = 0.05f;
    public bool jump = false;

    float Timer = 0.0f;

    private void Awake()
    {
        PlayerMotion = Player.GetComponent<Animator>();
    }
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
        // 스킬
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("공격");
                isAttack = true;
                PlayerMotion.SetInteger("motion", 1);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                isSkill_1 = true;
                PlayerMotion.SetInteger("motion", 2);
                Debug.Log("스킬1");
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                isSkill_2 = true;
                PlayerMotion.SetInteger("motion", 3);
                Debug.Log("스킬2");
            }
        }
        if(isAttack || isSkill_1 || isSkill_2)
        {
            Timer += Time.deltaTime;
            if(Timer > 0.4f)
            {
                PlayerMotion.SetInteger("motion", 0);
                isAttack = false;
                isSkill_1 = false;
                isSkill_2 = false;
                Timer = 0.0f;
            }
        }

        Player.transform.position += new Vector3(Dir, 0, 0) * Speed;
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Ground")
        {
            Debug.Log("바닥");
        }
    }
}
