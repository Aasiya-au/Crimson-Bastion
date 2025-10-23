using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // needed for TextMeshPro

public class ScrollText : MonoBehaviour
{
    public float speed = 50f; // pixels per second
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        // move upward
        rectTransform.anchoredPosition += new Vector2(0, speed * Time.deltaTime);

        // optional: destroy when off screen
        if (rectTransform.anchoredPosition.y > 1000f) // adjust depending on your canvas size
        {
            Destroy(gameObject);
            SceneManager.LoadScene("SplashScreenScene");
        }
    }
}
