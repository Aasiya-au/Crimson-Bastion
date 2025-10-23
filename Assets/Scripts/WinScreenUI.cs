using UnityEngine;
using TMPro;  // <-- add this

public class WinScreenUI : MonoBehaviour
{
    public TextMeshProUGUI timeText;   // for TMP text
    public TextMeshProUGUI scoreText;  // for TMP text

    void Start()
    {
        float timeRemaining = GameManager.Instance.lastLevelTime;
        float score = timeRemaining;

        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timeText.text = $"MISSION TIME: {minutes:00}:{seconds:00}";
        scoreText.text = $"SCORE: {score} XP";
    }
}
