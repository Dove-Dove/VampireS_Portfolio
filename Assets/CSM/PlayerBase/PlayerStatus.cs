using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerStatus : MonoBehaviour
{
    [Header("기본 스탯")]
    [SerializeField] private float attackPower = 1f;
    [SerializeField] private float defense = 0f;
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;

    [Header("이동 및 투사체")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float projectileSpeed = 5f;
    [SerializeField] private float projectileSize = 1f;
    [SerializeField] private int projectileCount = 1;

    [Header("전투 보조")]
    [SerializeField] private float cooldownReduction = 0f;
    [SerializeField] private float pickupRange = 1f;
    [SerializeField] private float targetRange = 20f;
    private PlayerAnimatorController anim;
    private InvincibilityHandler invincibilityHandler;
    // 이벤트 정의
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
        invincibilityHandler = GetComponent<InvincibilityHandler>();
        anim = GetComponent<PlayerAnimatorController>();
    }

    #region 스탯 조작 메서드

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
        if (invincibilityHandler != null && invincibilityHandler.IsInvincible) return;

        float finalDamage = Mathf.Max(amount - defense, 1f);
        currentHealth -= finalDamage;

        if (currentHealth <= 0f)
        {
            currentHealth = 0f;
            anim?.TriggerDeath(); 
            OnDeath?.Invoke();
        }
        else
        {
            anim?.TriggerHurt();
            invincibilityHandler?.TriggerInvincibility();
        }
    }
    public void Revive()
    {
        currentHealth = maxHealth;

        
        if (TryGetComponent(out PlayerAnimatorController anim))
            anim.ResetToIdle(); // 선택 사항: Idle 상태로 되돌리기

        Debug.Log("PlayerStatus: 체력 완전 회복");
    }
    #endregion
}
