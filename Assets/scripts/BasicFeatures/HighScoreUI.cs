using UnityEngine;
using TMPro;
using PlayerMove; // Add this line
public class HighScoreUI : MonoBehaviour
{
    public HighScoreManager highScoreManager;
    private TextMeshProUGUI textComponent;

    void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();

        if (textComponent == null)
        {
            Debug.LogError("HighScoreUI script requires a TextMeshProUGUI component.");
            enabled = false;
            return;
        }

        if (highScoreManager == null)
        {
            Debug.LogError("HighScoreUI script requires a reference to HighScoreManager.");
            enabled = false;
            return;
        }

        UpdateHighScoreUI();
    }

    void Update()
    {
        // You can update the high score UI dynamically here if needed.
    }

    public void UpdateHighScoreUI()
    {
        int highScore = highScoreManager.GetHighScore();
        textComponent.text = $"{highScore} m";
    }
}
