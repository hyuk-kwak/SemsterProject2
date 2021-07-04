using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : MonoBehaviour
{
    public GameObject eagle;
    public GameObject player;
    float speed = 0.01f;
    //[SerializeField] public Player player 추가 필요
    public Score score;
    public float hitTimer = 0f;
    public float moveTimer = 0.5f;
    public bool Hitted = false;
    public int hp = 2; // 몬스터의 체력. 타수에 따라 1또는 2로 설정.
    public int damage = 1; // 플레이어에게 주는 데미지
    void Start()
    {
        score = FindObjectOfType<Score>();
    }
    void FixedUpdate()
    {
        float newXPos = transform.position.x;
        float newYPos = transform.position.y;
        if (!Hitted)
        {
            newXPos += speed;
            if (transform.position.x - player.transform.position.x < 1f && transform.position.x - player.transform.position.x > 0f)
                newYPos -= 0.05f;

            if (transform.position.y <= 2f)
            {
                newYPos += 0.05f;
            }
            transform.position = new Vector2(newXPos, newYPos);
        }
        else
        {   //피격당했을 때 넉백
            newXPos += 0.1f;
            newYPos += Mathf.Sin(Time.time);
            transform.position = new Vector2(newXPos, newYPos);
            hitTimer -= Time.deltaTime;
            if (hitTimer < 0.0f)
            {
                Hitted = false;
            }
        }

        if (gameObject.transform.position.x < -2.0f) gameObject.SetActive(false);
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
            //score.gameScore += 20; //죽으면 포인트 20올려줌.
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