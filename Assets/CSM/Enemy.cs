using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private int maxHealth = 50;
    private int currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= (int)amount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // ����ġ ��� ó���� ���⼭ ����
        Destroy(gameObject);
    }
}
