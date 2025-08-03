using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private ScoreSystem scoreSystem;

    void OnEnable()
    {
        scoreSystem.OnScoreChanged.AddListener(UpdateScoreText);
    }

    void OnDisable()
    {
        scoreSystem.OnScoreChanged.RemoveListener(UpdateScoreText);
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = "Score: " + score;
    }
}
