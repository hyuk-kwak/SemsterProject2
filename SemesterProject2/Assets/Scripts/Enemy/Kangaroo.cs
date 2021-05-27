using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kangaroo : MonoBehaviour
{
    [SerializeField] public float jumpPower;
    public Spawn kangaroospawn;
    //[SerializeField] public Player player 추가 필요
    //[SerializeField] public 점수 score 추가 필요
    public Rigidbody2D rigid;
    public float verticalVec;
    public float speed =1.2f;
    public bool isGround = false;
    public int hp = 2; // 몬스터의 체력. 타수에 따라 1또는 2로 설정.
    public int demage; // 플레이어에게 주는 데미지
    void Start()
    {
        kangaroospawn = FindObjectOfType<Spawn>();
        rigid = GetComponent<Rigidbody2D>();
        verticalVec = 1.0f;
    }
    void FixedUpdate()
    {
       
        rigid.velocity = new Vector2(kangaroospawn.dir, 0) * speed;

        Vector2 jumpVec = isGround? new Vector2(0,verticalVec) : Vector2.zero; 
        rigid.AddForce(jumpVec * jumpPower,ForceMode2D.Impulse);

        if (kangaroospawn.dir == 1.0f)
        {
            if(gameObject.transform.position.x > 18.0f)
                 gameObject.SetActive(false);
        }
        else
        {
            if (gameObject.transform.position.x < -2.0f)
                gameObject.SetActive(false);
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.transform.tag == "Ground") isGround = true;
        if(collision.transform.tag == "Player") AttackPlayer(demage);

    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.transform.tag == "Ground") isGround = false;
    }

    void Attacked(int amount)
    { // 데미지를 받으면서 대각선 우측 방향으로 튀어오름. hp가 0아래로 내려가면 죽으면서 포인트 올려줌.
        hp -= amount;
        if(hp <= 0) {
            Destroy(gameObject);
            // 포인트 업 함수 추가 필요.
        }
        Vector2 moveVec = new Vector2(1f, 1f);
        rigid.velocity = moveVec * speed;
        rigid.AddForce(moveVec,ForceMode2D.Impulse); // 우상단으로 힘 가함.
    }
    void AttackPlayer(int demage)
    {
        //player.피깎기()
    }
}