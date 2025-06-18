using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteBlinkEffect : MonoBehaviour
{
    [SerializeField] private float blinkInterval = 0.1f;
    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void StartBlinking(float duration)
    {
        StartCoroutine(BlinkCoroutine(duration));
    }

    private IEnumerator BlinkCoroutine(float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            sr.enabled = !sr.enabled;
            yield return new WaitForSeconds(blinkInterval);
            elapsed += blinkInterval;
        }
        sr.enabled = true;
    }
}