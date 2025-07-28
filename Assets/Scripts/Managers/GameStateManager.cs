using UnityEngine;
using UnityEngine.Events;

public class GameStateManager : MonoBehaviour
{
    public UnityEvent OnGameOver;
    public UnityEvent OnWin;

    private bool isGameOver = false;

    public void TriggerGameOver()
    {
        if (isGameOver) return;
        isGameOver = true;
        OnGameOver?.Invoke();
    }

    public void TriggerWin()
    {
        if (isGameOver) return;
        isGameOver = true;
        OnWin?.Invoke();
    }

    public bool IsGameOver() => isGameOver;
}
