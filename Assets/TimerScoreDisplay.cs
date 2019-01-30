using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScoreDisplay : MonoBehaviour
{
    public GameManager GM;

    public TextMeshProUGUI ScoreDisplay;

    public TextMeshProUGUI TimerDisplay;

    public TextMeshProUGUI LivesDisplay;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("Game-Manager").GetComponent<GameManager>();
        ScoreDisplay.text = "0";
        LivesDisplayUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        TimerDisplayUpdate();
    }

    void ScoreDisplayUpdate() {
        //        ScoreDisplay.text = ""+ GM.Score;
    }

    void TimerDisplayUpdate()
    {
        TimerDisplay.text = ""+ GM.timeLeft.ToString("0"); // Convert float to int in display
    }

    void LivesDisplayUpdate()
    {
        LivesDisplay.text = ""+ GM.lives;
    }
}
