using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float startTime = 120f; // seconds
    public string levelName;       // assign in Inspector

    private float remainingTime;
    private bool isRunning = true;

    void Start()
    {
        remainingTime = startTime;
    }

    void Update()
    {
        if (!isRunning) return;

        remainingTime -= Time.deltaTime;

        if (remainingTime <= 0)
        {
            remainingTime = 0;
            isRunning = false;
            TimerEnded();
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (remainingTime <= 10)
            timerText.color = Color.red;
    }

    void TimerEnded()
    {
        Debug.Log("Time's up!");

        if (!string.IsNullOrEmpty(levelName))
            GameManager.Instance.SaveLevelResult(levelName, remainingTime);

        SceneManager.LoadScene("LoseScene");
    }

    public float GetRemainingTime() => remainingTime;

    public void StartTimer() => isRunning = true;
    public void StopTimer() => isRunning = false;
    public void ResetTimer()
    {
        remainingTime = startTime;
        isRunning = true;
    }
}
