using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class HealthChangedEvent : UnityEvent<int, int> { }

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 30;
    public int CurrentHealth { get; private set; }

    public HealthChangedEvent OnHealthChanged = new();

    void Start()
    {
        CurrentHealth = maxHealth;
        OnHealthChanged?.Invoke(CurrentHealth, maxHealth);
    }

    public void TakeDamage(int amount)
    {
        Debug.Log("TakeDamage called: " + amount);

        CurrentHealth = Mathf.Max(CurrentHealth - amount, 0);
        OnHealthChanged?.Invoke(CurrentHealth, maxHealth);

        Debug.Log("CurrentHealth after damage: " + CurrentHealth);

        if (CurrentHealth <= 0)
        {
            Debug.Log("Triggering Game Over!");
            FindAnyObjectByType<GameStateManager>()?.TriggerGameOver();
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player collided with enemy! Taking damage.");
            TakeDamage(10);
            Destroy(collision.gameObject); // om du vill att fienden försvinner
        }
    }
}
