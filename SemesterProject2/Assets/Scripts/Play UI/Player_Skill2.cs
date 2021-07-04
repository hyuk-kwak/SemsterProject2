using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Skill2 : MonoBehaviour
{
    public GameObject Falcon;
    public Transform Falcon_pos;
    public PlayerMove playermove;
    public GameObject Player;
    public GameObject FalconClone;
    public float Falcondir;
    float FalconSpeed = 0.2f;
    float FalconTimer = 2.5f;
    bool ThrowFalcon = false;

    //
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
        if (ThrowFalcon && FalconClone != null)
        {
            FalconTimer -= Time.deltaTime;
            if (FalconTimer > 2.0f)
            {
                FalconClone.transform.position += new Vector3(Falcondir, 0, 0) * FalconSpeed;
            }
            else if (FalconTimer > 1.5f)
            {
                FalconClone.transform.position += new Vector3(Falcondir/2, -Falcondir, 0) * FalconSpeed;
            }
            else if (FalconTimer > 1.0f)
            {
                FalconClone.transform.position += new Vector3(Falcondir, 0, 0) * FalconSpeed;
            }
            else if (FalconTimer > 0.5f)
            {
                FalconClone.transform.position += new Vector3(Falcondir / 2, Falcondir, 0) * FalconSpeed;
            }
            else if (FalconTimer > 0.0f)
            {
                FalconClone.transform.position += new Vector3(Falcondir, 0, 0) * FalconSpeed;
            }
            else
            {
                ThrowFalcon = false;
                FalconTimer = 2.5f;
            }
        }
        // Timer 추가해주고 시간 지나면 ThrowFalcon = False;
    }
    public void Is_Falcon()
    {
        if (playermove.Skill2_Timer < 0.0f)
        {
            playermove.isSkill_2 = true;
            //playermove.Skill2_Timer = 0.0f;
            ThrowFalcon = true;
            FalconClone = Instantiate(Falcon, Falcon_pos.position, transform.rotation);
            Falcondir = playermove.Dir;
        }
    }      
}
