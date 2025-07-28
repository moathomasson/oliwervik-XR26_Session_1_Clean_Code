using UnityEngine;
using TMPro;

public class GameUIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameStatusText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject gameOverPanel;

    private float gameTime;

    void Start()
    {
        gameOverPanel.SetActive(false);
        gameStatusText.text = "Game Started!";
    }

    void Update()
    {
        gameTime += Time.deltaTime;
        timerText.text = "Time: " + Mathf.FloorToInt(gameTime).ToString() + "s";
    }

    public void ShowWinMessage(int score)
    {
        gameStatusText.text = "YOU WIN! Score: " + score;
        gameOverPanel.SetActive(true);
    }

    public void ShowGameOverMessage()
    {
        gameStatusText.text = "GAME OVER!";
        gameOverPanel.SetActive(true);
    }
}
