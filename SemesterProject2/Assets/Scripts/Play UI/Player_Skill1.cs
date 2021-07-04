using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Skill1 : MonoBehaviour
{
    public GameObject Bone;
    public Transform Bone_pos;
    public PlayerMove playermove;
    public GameObject Player;
    public GameObject BoneClone;

    public Monkey enemy_monkey;
    public Kangaroo enemy_kangaroo;
    public Eagle enemy_eagle;

    public float Bonedir;
    float BoneSpeed = 0.2f;
    bool ThrowBone = false;

    private void Awake()
    {
        playermove = Player.GetComponent<PlayerMove>();
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        if (ThrowBone && BoneClone!=null )
        {
            BoneClone.transform.position += new Vector3(Bonedir,0,0) * BoneSpeed;
            if (BoneClone.transform.position.x > 18.0f) BoneClone.SetActive(false);
            else if (BoneClone.transform.position.x < -2.0f) BoneClone.SetActive(false);
        }
    }
    public void Is_Bone()
    {
        Debug.Log(playermove.Skill1_Timer);
        if (playermove.Skill1_Timer < 0.0f)
        {
            Debug.Log("Skill_1");
            playermove.isSkill_1 = true;
            //playermove.Skill1_Timer = 5.0f;
            ThrowBone = true;
            BoneClone = Instantiate(Bone, Bone_pos.position, transform.rotation);
            Bonedir = playermove.Dir;
        }
    }
    public void OnCollisionEnter2D(Collision2D enemy)
    {
        if (enemy.gameObject.tag == "monkey")
        {
            ThrowBone = false;
        }
        else if (enemy.gameObject.tag == "kangaroo")
        {
            ThrowBone = false;
        }
        else if (enemy.gameObject.tag == "eagle")
        {
            ThrowBone = false;
        }
    }
}
