using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour, IScorable
{
    [SerializeField] private float maxHealth = 30f;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Slider healthBar;
    [SerializeField] private GameStateManager gameState;

    private int score = 0;
    private float health;

    void Start()
    {
        health = maxHealth;
        healthBar.maxValue = maxHealth;
        UpdateUI();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            score += 10;
            UpdateUI();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10);
            Destroy(collision.gameObject);
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        health = Mathf.Max(0, health);
        UpdateUI();

        if (health <= 0)
        {
            gameState?.TriggerGameOver();
        }
    }

    private void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        healthBar.value = health;
    }

    public int GetScore() => score;
}
