using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    private void Start()
    {
        var ps = GetComponent<ParticleSystem>();
        if (ps != null)
        {
            Destroy(gameObject, ps.main.duration + ps.main.startDelay.constant);
        }
        else
        {
            Destroy(gameObject, 1f);
        }
    }
}
