using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : MonoBehaviour
{
    public GameObject monkey;
    public Spawn monkeyspawn;

    [SerializeField] public float jumpPower;
    float speed = 1f;
    //[SerializeField] public Player player 추가 필요
    //[SerializeField] public 점수 score 추가 필요
    public Rigidbody2D rigid;
    public float horizontalVec;
    public bool leftSpawn = false;
    public bool isGround = false;
    
    public int hp = 1; // 몬스터의 체력. 타수에 따라 1또는 2로 설정.
    public int demage = 1; // 플레이어에게 주는 데미지
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        if(!leftSpawn) horizontalVec = -1.0f;
        else horizontalVec = 1.0f;
        monkeyspawn = FindObjectOfType<Spawn>();
    }
    void FixedUpdate()
    {

        rigid.velocity = new Vector2(monkeyspawn.dir,0) * speed;
        if (monkeyspawn.dir == 1.0f)
        {
            if (gameObject.transform.position.x > 18.0f)
                gameObject.SetActive(false);
        }
        else
        {
            if (gameObject.transform.position.x < -2.0f)
                gameObject.SetActive(false);
        }
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
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player") AttackPlayer(demage);
        if (other.gameObject.tag == "Bone")
        {
            Debug.Log("jsh ㅃ가");
            
            other.gameObject.SetActive(false);
        }
    }
}