using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour //Subscriber
{
    public Slider healthSlider;
    public PlayerHealth playerHealth;

    private void OnEnable()
    {
        playerHealth.OnHealthChanged.AddListener(UpdateHealthBar);
    }

    private void OnDisable()
    {
        playerHealth.OnHealthChanged.RemoveListener(UpdateHealthBar);
    }

    private void UpdateHealthBar(float newHealth)
    {
        healthSlider.value = newHealth;
    }
}
