using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public Transform SpawnPosition1;
    public Transform SpawnPosition2;
    public Transform SpawnPosition3;

    public GameObject MonkeyPrefab;
    public GameObject KangarooPrefab;
    public GameObject EaglePrefab;

    float spawnTerm = 2.0f;
    public int stageNum = 1;
    public int count;
    Quaternion rotation = Quaternion.Euler(0, 180, 0);
    public float dir = -1.0f;
    // Start is called before the first frame update
    void Start()
    {
        count = 25 + stageNum * 5;
        StartCoroutine(SpawnMonster());
        Instantiate(EnemyPrefab, SpawnPosition1.position, SpawnPosition1.rotation);
    }
    void Update()
    {
        
    }
    IEnumerator SpawnMonster()
    { //소환할 몬스터 결정. 원숭이 : 캥거루 : 독수리 = 8 : 1 : 1
        while (count > 0 )
        {
            // 소환할 시간 차 결정. 0~1 사이의 난수 + 1/(0.1 ~ stage수)사이의 난수 초 후에 소환.
            yield return new WaitForSeconds(spawnTerm);

            float side = Random.Range(0, 1);
            //소환할 방향 결정. 50% 확률

            {
                if (stageNum > 2 && side < 0.4)
                    Instantiate(MonkeyPrefab, SpawnPosition1.position, Quaternion.identity);
                else if (stageNum < 3 && side > 0.4)
                {
                    dir = 1.0f;
                    Instantiate(MonkeyPrefab, SpawnPosition2.position, rotation);
                }
                break;
            }
            /*int probability = Random.Range(1, 10);
            switch (probability)
            { // 1일 경우 독수리, 2 캥거루, 나머지는 원숭이 -> 10%확률로 독수리, 10%확률로 캥거루, 80%확률로 원숭이
                case 1:
                    {
                        dir = -1.0f;
                        Instantiate(EaglePrefab, SpawnPosition3.position, Quaternion.identity);
                        break;
                    }
                case 2:
                case 3:
                    {
                        if (side < 0.5)
                        {
                            dir = -1.0f;
                            Instantiate(KangarooPrefab, SpawnPosition1.position, Quaternion.identity);
                        }
                        else // 0.5보다 크면 왼쪽소환.
                        {
                            dir = 1.0f;
                            Instantiate(KangarooPrefab, SpawnPosition2.position, rotation);
                        }
                        break;
                    }
                default:
                    {
                        if (stageNum > 2 && side < 0.4)
                            Instantiate(MonkeyPrefab, SpawnPosition1.position, Quaternion.identity);
                        else if (stageNum < 3 && side > 0.4)
                        {
                            dir = 1.0f;
                            Instantiate(MonkeyPrefab, SpawnPosition2.position, rotation);
                        }
                        break;
                    }
            }*/
            //count--;
        }
    }
}

