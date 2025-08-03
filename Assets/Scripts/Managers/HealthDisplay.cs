using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Slider healthBar;
    [SerializeField] private TextMeshProUGUI _healthText; 

    void OnEnable()
    {
        playerHealth.OnHealthChanged.AddListener(UpdateHealthDisplay);
    }

    void OnDisable()
    {
        playerHealth.OnHealthChanged.RemoveListener(UpdateHealthDisplay);
    }

    void UpdateHealthDisplay(int currentHealth, int maxHealth)
    {
        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }

   
        if (_healthText != null)
        {
            _healthText.text = $"{currentHealth} / {maxHealth}";
        }
    }
}
