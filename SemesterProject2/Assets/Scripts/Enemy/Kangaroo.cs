using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kangaroo : MonoBehaviour
{
    public GameObject kangaroo;
    public Spawn kangaroospawn;
    public Score score;
    float speed = 0.01f;
    public Rigidbody2D rigid;
    public float horizontalVec;
    public bool leftSpawn = false;
    public bool isGround = false;
    public float hitTimer = 0f;
    public bool Hitted = false;
    public int hp = 2; // 몬스터의 체력. 타수에 따라 1또는 2로 설정.
    public int damage = 1; // 플레이어에게 주는 데미지
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        if (!leftSpawn) speed = -speed;
        kangaroospawn = FindObjectOfType<Spawn>();
        score = FindObjectOfType<Score>();
    }
    void FixedUpdate()
    {
        float newXPos = transform.position.x;
        float newYPos = transform.position.y;
        if (!Hitted)
        {
            newXPos = transform.position.x + speed;
            newYPos = transform.position.y + 10 * Mathf.Abs(Mathf.Sin(Time.deltaTime));
            // sin의 절댓값 -> 포물선 운동의 반복. 앞에 곱해지는 값으로 뛰는 높이 결정.
            transform.position = new Vector2(newXPos, transform.position.y);
        }
        else
        {   //피격당했을 때 넉백
            newXPos = transform.position.x + 1f;
            newYPos = transform.position.y + Mathf.Sin(Time.deltaTime);
            transform.position = new Vector2(newXPos, newYPos);
            hitTimer -= Time.deltaTime;
            if (hitTimer < 0.0f)
            {
                Hitted = false;
            }
        }

        if (kangaroospawn.dir == 1.0f)
        {
            if (gameObject.transform.position.x > 18.0f)
                gameObject.SetActive(false); //gameObject.Destroy();
        }
        else
        {
            if (gameObject.transform.position.x < -2.0f)
                gameObject.SetActive(false); //gameObject.Destroy();
        }
    }
    void IsHitted(int amount)
    {
        // 피격 당하면 Hitted, hitTimer 설정 -> 피격 모션 발동 및 피격 모션 발동 시간 설정.
        // 체력 깎고 0.5보다 작으면 객체 삭제.
        Hitted = true;
        hitTimer = 0.5f;
        hp -= amount;
        if (hp < 0.5f)
        {
            gameObject.SetActive(false); //gameObject.Destroy();
            //score.gameScore += 10; //죽으면 포인트 10올려줌.
        }
    }
    void OnCollisionEnter2D(Collision2D Collision)
    {
        if (Collision.gameObject.tag == "Bone") //뼈 맞은 경우
            IsHitted(1);
        else if (Collision.gameObject.tag == "Falcon") //매 맞은 경우
            IsHitted(1);
    }
}