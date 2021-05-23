using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartSceneUI : MonoBehaviour
{


    
   public void startBtn()
    {
        SceneManager.LoadScene("MainScene");
        
    }

}
