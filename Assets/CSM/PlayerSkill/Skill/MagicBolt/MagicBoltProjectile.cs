using UnityEngine;

public class MagicBoltProjectile : MonoBehaviour
{
    private Vector2 velocity;
    private float damage;

    [SerializeField] private float lifetime = 2f;

    [Header("이펙트 및 사운드")]
    [SerializeField] private GameObject moveEffect; // 자식 오브젝트 (ParticleSystem 포함)
    [SerializeField] private GameObject impactEffect; // 충돌 시 효과

    [SerializeField] private AudioClip shootClip;
    [SerializeField] private AudioClip hitClip;
    private AudioSource audioSource;

    public void Initialize(Vector2 velocity, float damage)
    {
        this.velocity = velocity.normalized * velocity.magnitude;
        this.damage = damage;

        // 방향 회전 적용
        RotateToDirection(this.velocity);

        // 파티클 수동 재생
        if (moveEffect != null)
        {
            moveEffect.transform.rotation = Quaternion.Euler(0, 0, GetAngle(this.velocity));
            var ps = moveEffect.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                ps.Play();
            }
        }

        // 사운드
        audioSource = GetComponent<AudioSource>();
        if (shootClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(shootClip);
        }

        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        transform.Translate(velocity * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy")) return;

        if (collision.TryGetComponent(out IDamageable target))
        {
            target.TakeDamage(damage);
        }

        Vector2 contactPoint = collision.ClosestPoint(transform.position); // ★ 충돌 지점 계산
        SpawnImpactEffect(contactPoint); // ★ 위치 전달

        Destroy(gameObject);
    }

    private void SpawnImpactEffect(Vector2 position)
    {
        if (impactEffect != null)
        {
            float angle = GetAngle(velocity);
            Instantiate(impactEffect, position, Quaternion.Euler(0, 0, angle));
        }

        if (hitClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(hitClip);
        }
    }


    private void RotateToDirection(Vector2 dir)
    {
        if (dir.sqrMagnitude < 0.001f) return;

        float angle = GetAngle(dir);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private float GetAngle(Vector2 dir)
    {
        return Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    }
}
