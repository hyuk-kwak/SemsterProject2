using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseBtn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject pauseBtn;
    public Text countdowntext;
    public bool isPause = false;
    int count;
    bool countstart;
    bool restart;
    float firstTime;
   

    void Update()
    {
        
        
    }

    public void SetPause()
    {
        if (!isPause)
        {
            isPause = true;
            Time.timeScale = 0;
            pauseBtn.gameObject.SetActive(true);
            restart = false;
        }
    }
    public void Continue()
    {
        if (isPause)
        {
            isPause = false;
            pauseBtn.gameObject.SetActive(false);
            countstart = true;
            Time.timeScale = 1;
            
        }
    }

   
}
