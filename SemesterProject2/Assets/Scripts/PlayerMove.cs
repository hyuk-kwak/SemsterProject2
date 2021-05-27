using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject Player;
    //public GameObject[] Bullet;
    Animator PlayerMotion;
    public bool isWalk = true;
    public bool isAttack = false;
    public bool isSkill_1 = false;
    public bool isSkill_2 = false;


    public float Dir = 1.0f;
    float Speed = 0.05f;
    public bool isJump = false;

    float Timer = 0.0f;
    public float Skill1_Timer = 0.0f;
    public float Skill2_Timer = 0.0f;
    public Vector2 AttackCol;
    public Vector2 NormalCol;



    private void Awake()
    {
        PlayerMotion = Player.GetComponent<Animator>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        Player.GetComponent<Rigidbody2D>().gravityScale = 1;
        AttackCol= Player.GetComponent<BoxCollider2D>().size + new Vector2(0.3f,0);
        NormalCol= Player.GetComponent<BoxCollider2D>().size;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Dir *= -1.0f;
            if (Player.transform.localEulerAngles.y == 180) Player.transform.localEulerAngles = Vector3.zero;
            else if (Player.transform.localEulerAngles.y == 0) Player.transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        //점프
        {
            if (Input.GetKeyDown(KeyCode.Space))
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
            if (Input.GetKeyDown(KeyCode.Q))
            {
                isAttack = true;
            }
            else if (Input.GetKeyDown(KeyCode.W) && Skill2_Timer > 3.0f )
            {
                isSkill_1 = true;
                Skill1_Timer = 0.0f;
            }
            else if (Input.GetKeyDown(KeyCode.E) && Skill2_Timer > 5.0f )
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
        {
            Player.transform.position += new Vector3(Dir, 0, 0) * Speed;
            if (isAttack) Player.GetComponent<BoxCollider2D>().size = AttackCol;
            else Player.GetComponent<BoxCollider2D>().size = NormalCol;
        }
    }
    void OnCollisionEnter2D(Collision2D enemy)
    {
        if( isAttack && ( enemy.gameObject.tag == "monkey" || enemy.gameObject.tag == "kangeroo"))
        {
            enemy.gameObject.SetActive(false);
            //Destroy(enemy.gameObject);
        }
    }
}
