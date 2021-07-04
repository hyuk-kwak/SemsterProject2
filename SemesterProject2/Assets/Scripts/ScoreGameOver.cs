using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public int gameScore;
    private Text text;
    ScoreBar scorebar;
    void Start()
    {
        gameScore = 0;
        text = GetComponent<Text>();
        scorebar = GameObject.Find("MainScore").GetComponent<ScoreBar>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = scorebar.gameScore.ToString();
    }
}
