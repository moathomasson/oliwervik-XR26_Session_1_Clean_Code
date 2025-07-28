using UnityEngine;

public class ScoreWinChecker : MonoBehaviour
{
    [SerializeField] private MonoBehaviour scorableObject;
    [SerializeField] private GameStateManager gameState;

    private IScorable scorable;

    void Start()
    {
        scorable = scorableObject as IScorable;
    }

    void Update()
    {
        if (!gameState.IsGameOver() && scorable.GetScore() >= 30)
        {
            gameState.TriggerWin();
        }
    }
}
