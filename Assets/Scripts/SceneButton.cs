using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour
{
    public AudioClip clickSound;   // optional

    public void OnClick(string sceneName)
    {
        // Play the sound
        AudioManager.Instance.Play(clickSound);
        SceneManager.LoadScene(sceneName);
    }
    public void QuitGame()
    {
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
