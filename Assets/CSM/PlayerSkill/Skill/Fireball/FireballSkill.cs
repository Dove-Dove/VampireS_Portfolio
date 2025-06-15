using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSkill : BaseSkill
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed = 5f;
    [SerializeField] private int projectileCount = 1;

    public override void Activate()
    {
        float size = Status?.ProjectileSize ?? 1f;
        float speed = Status?.ProjectileSpeed ?? 5f;
        int count = Status?.ProjectileCount ?? 1;

        for (int i = 0; i < count; i++)
        {
            Vector2 dir = Random.insideUnitCircle.normalized;
            GameObject fireball = Instantiate(projectilePrefab, owner.transform.position, Quaternion.identity);

            // 스케일 적용
            fireball.transform.localScale *= size;

            // Collider 크기까지 키우고 싶다면 여기에 추가
            CircleCollider2D col = fireball.GetComponent<CircleCollider2D>();
            if (col != null)
                col.radius *= size;

            // 이동 속도 적용
            Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
            rb.velocity = dir * speed;
        }
    }


    public override void LevelUp()
    {
        base.LevelUp();
        if (projectileCount < 5)
        {
            projectileCount++; // 발사 수 증가
        }
        else
        {
            coldown = Mathf.Max(0.1f, coldown * 0.9f); // 쿨다운 감소
        }
    }

    public override string GetName() => "Fireball";
}
