using UnityEngine;

public class ExplosionDamage : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int damage = 20;
    [SerializeField] private float radius = 1.5f;
    [SerializeField] private string targetTag = "Enemy";
    [SerializeField] private float lifeTime = 2f;

    [Header("Visual")]
    [SerializeField] private ParticleSystem explosionEffect;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip explosionClip;

    private void Start()
    {
        // 플레이어 스탯 가져오기
        PlayerStatus status = GameObject.FindWithTag("Player")?.GetComponent<PlayerStatus>();
        float size = status?.ProjectileSize ?? 1f;

        // 이펙트 전체 스케일 확대
        transform.localScale *= size;

        // 파티클 크기 조정
        ParticleSystem ps = GetComponent<ParticleSystem>();
        if (ps != null)
        {
            var main = ps.main;
            main.startSizeMultiplier *= size;
            lifeTime = main.duration;
        }

        // Collider 반경 확대
        CircleCollider2D col = GetComponent<CircleCollider2D>();
        if (col != null)
            col.radius *= size;

        DealExplosionDamage();
        Destroy(gameObject, lifeTime);
    }


    private void DealExplosionDamage()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (var hit in hits)
        {
            if (!string.IsNullOrEmpty(targetTag) && !hit.CompareTag(targetTag))
                continue;

            IDamageable dmg = hit.GetComponent<IDamageable>();
            dmg?.TakeDamage(damage);
        }
    }
}
