using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerStatus : MonoBehaviour
{
    [Header("�⺻ ����")]
    [SerializeField] private float attackPower = 1f;
    [SerializeField] private float defense = 0f;
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;

    [Header("�̵� �� ����ü")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float projectileSpeed = 5f;
    [SerializeField] private float projectileSize = 1f;
    [SerializeField] private int projectileCount = 1;

    [Header("���� ����")]
    [SerializeField] private float cooldownReduction = 0f;
    [SerializeField] private float pickupRange = 1f;
    [SerializeField] private float targetRange = 20f;

    // �̺�Ʈ ����
    public event Action OnDeath;

    public float AttackPower => attackPower;
    public float Defense => defense;
    public float MaxHealth => maxHealth;
    public float CurrentHealth => currentHealth;

    public float MoveSpeed => moveSpeed;
    public float ProjectileSpeed => projectileSpeed;
    public float ProjectileSize => projectileSize;
    public int ProjectileCount => projectileCount;

    public float CooldownReduction => cooldownReduction;
    public float PickupRange => pickupRange;
    public float TargetRange => targetRange;
    private void Awake()
    {
        currentHealth = maxHealth;
    }

    #region ���� ���� �޼���

    public void IncreaseAttackPower(float amount) => attackPower += amount;
    public void IncreaseDefense(float amount) => defense += amount;
    public void IncreaseMaxHealth(float amount)
    {
        maxHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
    }

    public void Heal(float amount) => currentHealth = Mathf.Min(currentHealth + amount, maxHealth);

    public void TakeDamage(float amount)
    {
        float finalDamage = Mathf.Max(amount - defense, 1f);
        currentHealth -= finalDamage;

        if (currentHealth <= 0f)
        {
            currentHealth = 0f;
            OnDeath?.Invoke(); // �ܺ� �����ڿ��� �˸�
        }
    }

    #endregion
}
