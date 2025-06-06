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
        for (int i = 0; i < projectileCount; i++)
        {
            Vector2 dir = Random.insideUnitCircle.normalized;
            GameObject fireball = Instantiate(projectilePrefab, owner.transform.position, Quaternion.identity);
            Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
            rb.velocity = dir * projectileSpeed;
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
