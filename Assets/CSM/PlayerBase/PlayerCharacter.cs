using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private PlayerHealth health;
    private PlayerMovement movement;

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        health = GetComponent<PlayerHealth>();

    }

    private void OnEnable()
    {
        if (health == null)
            health = GetComponent<PlayerHealth>();

        health.onDeath += HandleDeath;
    }

    private void OnDisable()
    {
        if (health != null)
            health.onDeath -= HandleDeath;
    }

    private void HandleDeath()
    {
        Debug.Log("플레이어 죽음");
    }
}
