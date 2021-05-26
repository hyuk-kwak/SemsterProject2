using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject Player;
    Animator PlayerMotion;
    public bool isWalk = true;
    public bool isAttack = false;
    public bool isSkill_1 = false;
    public bool isSkill_2 = false;

    float Dir = 1.0f;
    float Speed = 0.05f;
    public bool isJump = false;

    float Timer = 0.0f;
    public float Skill1_Timer = 0.0f;
    public float Skill2_Timer = 0.0f;
  
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
        //점프
        {
            if (Input.GetMouseButtonDown(1))
            {
                isJump = true;
            }
            if (isJump)
            {
                Player.GetComponent<Rigidbody2D>().gravityScale = -1;
                isJump = false;
            }

            if (Player.transform.position.y > 2.7f)
            {
                Player.GetComponent<Rigidbody2D>().gravityScale = 1;
            }
        }
        // 스킬
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                isAttack = true;
            }
            else if (Input.GetKeyDown(KeyCode.S) && Skill2_Timer > 5.0f )
            {
                isSkill_1 = true;
                Skill1_Timer = 0.0f;
            }
            else if (Input.GetKeyDown(KeyCode.D) && Skill2_Timer > 30.0f )
            {
                isSkill_2 = true;
                Skill2_Timer = 0.0f;
            }
        }
        //스킬 또는 공격 모션 지속시간 && 쿨타임
        {
            if (isAttack || isSkill_1 || isSkill_2)
            {
                Timer += Time.deltaTime;
                if (isAttack)
                {
                    PlayerMotion.SetInteger("motion", 1);
                }
                else if (isSkill_1)
                {
                    PlayerMotion.SetInteger("motion", 2);
                    Skill1_Timer += Time.deltaTime;
                }
                else if (isSkill_2)
                {
                    PlayerMotion.SetInteger("motion", 3);
                    Skill2_Timer += Time.deltaTime;
                }
                if (Timer > 0.4f)
                {
                    PlayerMotion.SetInteger("motion", 0);
                    isAttack = false;
                    isSkill_1 = false;
                    isSkill_2 = false;
                    Timer = 0.0f;
                }
            }
        }

        // 스킬 1 or 2 획득시 Skillx_Timer = 100.0f 로 설정

        //플레이어 이동
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
