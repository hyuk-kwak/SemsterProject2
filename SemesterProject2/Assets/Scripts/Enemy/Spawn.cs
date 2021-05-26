using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public Transform SpawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(EnemyPrefab, SpawnPosition.position, SpawnPosition.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
