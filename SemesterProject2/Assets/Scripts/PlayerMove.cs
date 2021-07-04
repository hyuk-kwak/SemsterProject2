using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject Player;
    PauseBtn pauseBtn;
    //public GameObject[] Bullet;
    Animator PlayerMotion;
    public enum Player_State
    {
        Idle,
        Attack,
        Skill_1,
        Skill_2,
        Hitted,
        Dead
    }
    Player_State State;
    public bool isWalk = true;
    public bool isAttack = false;
    public bool isSkill_1 = false;
    public bool isSkill_2 = false;

    public int Hp = 3;
    public float Dir = 1.0f;
    float Speed = 0.05f;
    public bool isJump = false;

    float Timer = 0.4f;
    public float Skill1_Timer = -1.0f;
    public float Skill2_Timer = -1.0f;
    public float HitTimer = 0.5f;
    public float Dead_Timer = 1.0f;
    public Vector2 AttackCol;
    public Vector2 NormalCol;

    public Monkey enemy_monkey;
    public Kangaroo enemy_kangaroo;
    public Eagle enemy_eagle;
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
        State = Player_State.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        // �Ǵ޸� State ���
        if (Hp < 0.5f) State = Player_State.Dead;
        //���� (�ų����� ���� �Ǵ� �׾��� �� ���� �Ұ���)
        if (State != Player_State.Skill_2 || State != Player_State.Dead)
        {
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
        // Idle State
        if (State == Player_State.Idle)
        {
            Debug.Log("Idle");
            //��ų ��� //��ų �Ǵ� ���� ��� ���ӽð� && ��Ÿ��
            if (isAttack || isSkill_1 || isSkill_2)
            {
                Timer -= Time.deltaTime;
                if (isAttack)
                {
                    State = Player_State.Attack;
                    Debug.Log("IsAttack1");
                    PlayerMotion.SetInteger("motion", 1);
                }
                else if (isSkill_1)
                {
                    State = Player_State.Skill_1;
                    PlayerMotion.SetInteger("motion", 2);
                    Skill1_Timer -= Time.deltaTime;
                }
                else if (isSkill_2)
                {
                    State = Player_State.Skill_2;
                    PlayerMotion.SetInteger("motion", 3);
                    Skill2_Timer -= Time.deltaTime;
                }
                else if (Timer < 0.0f)
                {

                    PlayerMotion.SetInteger("motion", 0);
                    isAttack = false;
                    isSkill_1 = false;
                    isSkill_2 = false;
                    Timer = 0.4f;
                    State = Player_State.Idle;
                }
            }
        }
        // Hitted State
        else if(State == Player_State.Hitted)
        {
            HitTimer -= Time.deltaTime;
            if(HitTimer > 0.0f)
            {
                //����������
                Player.GetComponent<SpriteRenderer>().color = new Color(0.75f, 0, 0);
            }
            else
            {
                //�� ���󺹱�
                Player.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
                // �˹� ������ State = Player_State.Idle;
                State = Player_State.Idle;
            }
        }
        // Dead State
        else if(State == Player_State.Dead)
        {
            Dead_Timer -= Time.deltaTime;
            if(Dead_Timer < 0.0f)
            {
                Player.SetActive(false);
            }
        }
        // ��ų 1 or 2 ȹ��� Skillx_Timer = -10.0f �� ����r

        //������ȯ
        if (State != Player_State.Hitted)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                Dir *= -1.0f;
                if (Player.transform.localEulerAngles.y == 180) Player.transform.localEulerAngles = Vector3.zero;
                else if (Player.transform.localEulerAngles.y == 0) Player.transform.localEulerAngles = new Vector3(0, 180, 0);
            }
            //�÷��̾��̵�
            pauseBtn = GameObject.Find("Pause Button").GetComponent<PauseBtn>();
            if (pauseBtn.isPause == false)
            {
                //�÷��̾� �̵�
                Player.transform.position += new Vector3(Dir, 0, 0) * Speed;
            }
           
            if (isAttack) Player.GetComponent<BoxCollider2D>().size = AttackCol;
            else Player.GetComponent<BoxCollider2D>().size = NormalCol;
        }
    }
    void OnCollisionEnter2D(Collision2D enemy)
    {
        if (isAttack)
        {
            if (enemy.gameObject.tag == "monkey" )
            {
                //enemy_monkey.Hitted(1);
                //enemy.gameObject.SetActive(false);
                //Destroy(enemy.gameObject);
            }
            else if(enemy.gameObject.tag == "kangaroo")
            {
                //enemy_kangaroo.Hitted(1);
            }
            else if(enemy.gameObject.tag == "eagle")
            {
                //enemy_eagle.Hitted(1);
            }
        }
        //���Ϳ� �ε�ġ��
        if (State == Player_State.Idle || State == Player_State.Skill_1 || State == Player_State.Skill_2)
        {
            if(enemy.gameObject.tag == "monkey" || enemy.gameObject.tag == "kangaroo" || enemy.gameObject.tag == "eagle")
            {
                State = Player_State.Hitted;
                //�˹� �ð����ϱ�
                HitTimer = 0.5f;
                //�Ǵޱ�
                Hp -= 1;
            }
        }
    }
}
