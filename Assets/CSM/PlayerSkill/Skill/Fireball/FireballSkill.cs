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

            // ������ ����
            fireball.transform.localScale *= size;

            // Collider ũ����� Ű��� �ʹٸ� ���⿡ �߰�
            CircleCollider2D col = fireball.GetComponent<CircleCollider2D>();
            if (col != null)
                col.radius *= size;

            // �̵� �ӵ� ����
            Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
            rb.velocity = dir * speed;
        }
    }


    public override void LevelUp()
    {
        base.LevelUp();
        if (projectileCount < 5)
        {
            projectileCount++; // �߻� �� ����
        }
        else
        {
            coldown = Mathf.Max(0.1f, coldown * 0.9f); // ��ٿ� ����
        }
    }

    public override string GetName() => "Fireball";
}
