using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    public LevelTimer levelTimer;  // assign in Inspector
    public string scene;
    void OnCollisionEnter2D(Collision2D col) 
    {
        if (col.gameObject.CompareTag("Player"))
        {
            levelTimer.StopTimer();
            GameManager.Instance.SaveLevelResult("Level1Scene", levelTimer.GetRemainingTime());
            SceneManager.LoadScene(scene);
        }
    }
}
