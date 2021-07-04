using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public float delayTime;
    
    public Button ListBtn;
    public Button PlayBtn;
    public Button RestartBtn;
    public AudioMixer audioMixer;
    public Slider SoundSlider;

    
        
    
    public void AudioControl() //슬라이더로 소리 볼륨 조절
    {
        float sound = SoundSlider.value;

        if (sound == -40f) audioMixer.SetFloat("BGM", -80); //음소거시
        else audioMixer.SetFloat("BGM", sound); 
    }

    public void listBtnOnClick()
    {
        GameObject go = transform.GetChild(2).transform.gameObject;
        go.SetActive(true);
        
        //Instantiate(listBtnCheck, transform.position, transform.rotation);
    }

    public void listBtnYes()
    {
        SceneManager.LoadScene("StartScene");//게임 로비화면 scene 호출
    }
    public void listBtnNo()
    {
        GameObject go = transform.GetChild(2).transform.gameObject;
        go.SetActive(false);
    }
    public void playBtnOnClick()
    {
        

        Destroy(gameObject);//pause UI 삭제

        
    }

    public void restartBtnOnClick()
    {
        GameObject go = transform.GetChild(3).transform.gameObject;
        go.SetActive(true);
        //Instantiate(restartBtnCheck, transform.position, transform.rotation);     
    }

    public void restartBtnYes()
    {
        SceneManager.LoadScene("MainScene"); //현재 게임 scene 호출
    }
    public void restartBtnNo()
    {
        GameObject go = transform.GetChild(3).transform.gameObject;
        go.SetActive(false);
    }





}
