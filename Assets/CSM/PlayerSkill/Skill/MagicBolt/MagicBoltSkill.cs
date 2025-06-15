using UnityEngine;

public class MagicBoltSkill : BaseSkill
{
    [SerializeField] private GameObject projectilePrefab;

    private void Awake()
    {
        baseCooldown = 0.2f; // 쿨다운을 baseCooldown에 설정
    }

    public override string GetName()
    {
        return "MagicBolt";
    }

    public override void Activate()
    {
        if (projectilePrefab == null || owner == null) return;

        float speed = Status?.ProjectileSpeed ?? 6f;
        float size = Status?.ProjectileSize ?? 1f;
        float damage = Status?.AttackPower ?? 1f;
        int count = Status?.ProjectileCount ?? 1;
        float range = Status?.TargetRange ?? 20f;

        for (int i = 0; i < count; i++)
        {
            Transform target = EnemyFinder.FindNearestEnemy(owner.transform.position, range);

            Vector2 direction = (target != null)
                ? (target.position - owner.transform.position).normalized
                : Random.insideUnitCircle.normalized;

            GameObject proj = Instantiate(projectilePrefab, owner.transform.position, Quaternion.identity);
            proj.transform.localScale *= size;

            var projectile = proj.GetComponent<MagicBoltProjectile>();
            if (projectile != null)
                projectile.Initialize(direction * speed, damage);
        }
    }
}
