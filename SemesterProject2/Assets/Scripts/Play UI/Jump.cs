using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jump : MonoBehaviour
{
    
    PlayerMove playermove;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void start(){
        
    }
    void Update()
    {
        
    }
    public void isjump(){
        Debug.Log("sdasd");
        GameObject.Find("GameObject").GetComponent<PlayerMove>().jump = true;
        //playermove.jump = true;
        
    }
}
