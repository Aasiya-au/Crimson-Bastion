using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsSceneLoader : MonoBehaviour
{
    public int nextLevelIndex;

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevelIndex);
    }
}
