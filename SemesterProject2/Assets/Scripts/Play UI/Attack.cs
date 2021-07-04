using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    public GameObject Player;
    public PlayerMove playermove;


    // Start is called before the first frame update
    void Start()
    {
        playermove = Player.GetComponent<PlayerMove>();
    }

    // Update is called once per frame

    void Update()
    {

    }
    public void IsAttack()
    {
        playermove.isAttack = true;
        Debug.Log(playermove.isAttack);

    }
}
