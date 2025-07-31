using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour //Publisher
{
    public UnityEvent<float> OnHealthChanged = new UnityEvent<float>();
    private float health = 100f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        health = Mathf.Max(0, health);
        OnHealthChanged.Invoke(health); 
    }
}
