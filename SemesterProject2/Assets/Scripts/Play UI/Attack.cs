using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{

    PlayerMove playermove;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void start()
    {

    }
    void Update()
    {

    }
    public void isAttack()
    {
        GameObject.Find("GameObject").GetComponent<PlayerMove>().isAttack = true;
        //playermove.jump = true;

    }
}
