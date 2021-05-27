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
    public float Bonedir;
    float BoneSpeed = 0.2f;
    bool ThrowBone = false;
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

        if (ThrowBone && BoneClone!=null )
        {
            BoneClone.transform.position += new Vector3(Bonedir,0,0) * BoneSpeed;
        }
    }
    public void is_Bone()
    {
        playermove.isSkill_1= true;
        playermove.Skill1_Timer = 5.0f;
        ThrowBone = true;
        BoneClone = Instantiate(Bone, Bone_pos.position, transform.rotation);
        Bonedir = playermove.Dir;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.tag == "monkey")
        {
            ThrowBone = false;
        }
    }
}
