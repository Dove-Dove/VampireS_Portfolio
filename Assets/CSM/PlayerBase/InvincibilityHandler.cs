using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityHandler : MonoBehaviour
{
    [SerializeField] private float duration = 1f;
    public bool IsInvincible { get; private set; }

    private SpriteBlinkEffect blinkEffect;

    private void Awake()
    {
        blinkEffect = GetComponent<SpriteBlinkEffect>();
    }

    public void TriggerInvincibility()
    {
        if (!IsInvincible)
            StartCoroutine(InvincibleCoroutine());
    }

    private IEnumerator InvincibleCoroutine()
    {
        IsInvincible = true;
        blinkEffect?.StartBlinking(duration);
        yield return new WaitForSeconds(duration);
        IsInvincible = false;
    }
}
