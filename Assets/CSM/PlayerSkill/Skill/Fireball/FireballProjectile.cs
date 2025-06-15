using UnityEngine;

public class FireballProjectile : MonoBehaviour
{
    [SerializeField] private float lifetime = 3f;

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip fireSound;

    [Header("Visuals")]
    [SerializeField] private Animator animator;

    [Header("Explosion")]
    [SerializeField] private GameObject explosionEffectPrefab;

    private void Start()
    {
        if (fireSound != null)
            audioSource.PlayOneShot(fireSound);

        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (explosionEffectPrefab != null)
                Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
