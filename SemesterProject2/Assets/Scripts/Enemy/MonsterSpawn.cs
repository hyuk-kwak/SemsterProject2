using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MonsterSpawn : MonoBehaviour
{
    public Monkey monkey;
    public Kangaroo kangaroo;
    public Eagle eagle;

    public int stageNum = 1; // stagenum 받아와야함. 임시생성
    void Start()
    {
        monkey = FindObjectOfType<Monkey>();  
        kangaroo = FindObjectOfType<Kangaroo>();
        eagle = FindObjectOfType<Eagle>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SelectSpawnSide()
    { // 소환할 방향 결정. 50% 확률로 leftSpawn을 true로 바꿈 
        float side = Random.Range(0,1);
        if(stageNum > 3)
            if(side >= 0.5) monkey.leftSpawn = true;
        if(side >= 0.5) kangaroo.leftSpawn = true;
    }
    IEnumerator SpawnMonster()
    { //소환할 몬스터 결정. 원숭이 : 캥거루 : 독수리 = 8 : 1 : 1
        float spawnTerm = (Random.Range(0,1) + (1 / Random.Range(0.1f,stageNum)));
        // 소환할 시간 차 결정. 0~1 사이의 난수 + 1/(0.1 ~ stage수)사이의 난수 초 후에 소환.
        yield return new WaitForSeconds(spawnTerm);

        SelectSpawnSide();
        //소환할 방향 결정.
        int probability = Random.Range(1,10);
        switch(probability)
        { // 1일 경우 독수리, 2 캥거루, 나머지는 원숭이 -> 10%확률로 독수리, 10%확률로 캥거루, 80%확률로 원숭이
            case 1:
                Instantiate(eagle,new Vector2(3000,3000),Quaternion.identity);
                break;
            case 2:
                if(kangaroo.leftSpawn)
                    Instantiate(kangaroo,new Vector2(-3000,0),Quaternion.identity);
                else
                    Instantiate(kangaroo,new Vector2(3000,0),Quaternion.identity);
                break;
            default:
                if(monkey.leftSpawn)
                   Instantiate(monkey,new Vector2(-3000,0),Quaternion.identity);
                else
                    Instantiate(monkey,new Vector2(3000,0),Quaternion.identity);
                break;
        }
    }
}
