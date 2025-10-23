using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [HideInInspector] public float lastLevelTime;  // time taken for previous level
    [HideInInspector] public int lastLevelScore;   // score for previous level

    // Store scores for each level separately
    public Dictionary<string, int> levelScores = new Dictionary<string, int>();

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // persists across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Call this after a level ends
    public void SaveLevelResult(string levelName, float timeRemaining)
    {
        // Save last level info
        lastLevelTime = timeRemaining;
        lastLevelScore = Mathf.RoundToInt(timeRemaining * 10);

        // Save this level's score in the dictionary
        if (levelScores.ContainsKey(levelName))
            levelScores[levelName] = lastLevelScore;
        else
            levelScores.Add(levelName, lastLevelScore);
    }

    // Optional: get score for a specific level
    public int GetLevelScore(string levelName)
    {
        return levelScores.ContainsKey(levelName) ? levelScores[levelName] : 0;
    }

    // Optional: get cumulative score
    public int GetTotalScore()
    {
        int total = 0;
        foreach (var score in levelScores.Values)
            total += score;
        return total;
    }
}