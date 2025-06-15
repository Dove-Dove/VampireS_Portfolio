using UnityEngine;

public class MagicBoltProjectile : MonoBehaviour
{
    private Vector2 velocity;
    private float damage;

    [SerializeField] private float lifetime = 2f;

    [Header("����Ʈ �� ����")]
    [SerializeField] private GameObject moveEffect; // �ڽ� ������Ʈ (ParticleSystem ����)
    [SerializeField] private GameObject impactEffect; // �浹 �� ȿ��

    [SerializeField] private AudioClip shootClip;
    [SerializeField] private AudioClip hitClip;
    private AudioSource audioSource;

    public void Initialize(Vector2 velocity, float damage)
    {
        this.velocity = velocity.normalized * velocity.magnitude;
        this.damage = damage;

        // ���� ȸ�� ����
        RotateToDirection(this.velocity);

        // ��ƼŬ ���� ���
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

        // ����
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

        Vector2 contactPoint = collision.ClosestPoint(transform.position); // �� �浹 ���� ���
        SpawnImpactEffect(contactPoint); // �� ��ġ ����

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
