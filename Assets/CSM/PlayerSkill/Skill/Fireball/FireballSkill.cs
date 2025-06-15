using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSkill : BaseSkill
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed = 5f;
    [SerializeField] private int projectileCount = 1;

    private void Awake()
    {
        baseCooldown = 0.8f; // 기본 쿨다운을 baseCooldown에 저장
    }

    public override void Activate()
    {
        float size = Status?.ProjectileSize ?? 1f;
        float speed = Status?.ProjectileSpeed ?? projectileSpeed;
        int count = Status?.ProjectileCount ?? projectileCount;

        for (int i = 0; i < count; i++)
        {
            Vector2 dir = Random.insideUnitCircle.normalized;
            GameObject fireball = Instantiate(projectilePrefab, owner.transform.position, Quaternion.identity);
            fireball.transform.localScale *= 1 + size/10;

            CircleCollider2D col = fireball.GetComponent<CircleCollider2D>();
            if (col != null)
                col.radius *= size;

            Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.velocity = dir * speed;
        }
    }

    public override void LevelUp()
    {
        base.LevelUp();
        if (projectileCount < 5)
        {
            projectileCount++;
        }
        else
        {
            baseCooldown = Mathf.Max(0.2f, baseCooldown * 0.9f); // 기본 쿨다운 감소
        }
    }

    public override string GetName() => "Fireball";
}
