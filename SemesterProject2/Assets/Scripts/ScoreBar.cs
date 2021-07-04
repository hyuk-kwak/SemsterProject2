using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour
{
    // Start is called before the first frame update
    public int gameScore;
    private Text text;
    void Start()
    {
        gameScore = 0;
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = gameScore.ToString();
    }
}

