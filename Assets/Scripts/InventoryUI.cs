using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public TextMeshProUGUI totalScoreText; // optional Inspector assignment

    void Start()
    {
        // Find TMP text in scene if not assigned
        if (totalScoreText == null)
        {
            GameObject tmpObj = GameObject.Find("XP Text"); // exact name of your TMP text object
            if (tmpObj != null)
                totalScoreText = tmpObj.GetComponent<TextMeshProUGUI>();
            else
                Debug.LogError("TotalScoreText object not found in scene!");
        }

        // Only set text if totalScoreText is valid
        if (totalScoreText != null && GameManager.Instance != null)
        {
            totalScoreText.text = "Total Score: " + GameManager.Instance.GetTotalScore();
        }
    }
}
