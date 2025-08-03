using UnityEngine;
using UnityEngine.Events;

public class ScoreSystem : MonoBehaviour, IScorable
{
    private int score = 0;
    public UnityEvent<int> OnScoreChanged;

    public void AddScore(int amount)
    {
        score += amount;
        OnScoreChanged?.Invoke(score);
    }

    public int GetScore() => score;
}
