using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private PlayerStatus status;
    private PlayerMovement movement;
    private PlayerSkillController skillController;
    private Rigidbody2D rd;
    private void Awake()
    {
        status = GetComponent<PlayerStatus>();
        movement = GetComponent<PlayerMovement>();
        skillController = GetComponent<PlayerSkillController>();
        rd = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        if (status != null)
            status.OnDeath += HandleDeath;
    }

    private void OnDisable()
    {
        if (status != null)
            status.OnDeath -= HandleDeath;
    }

    private void HandleDeath()
    {
        Debug.Log("플레이어 사망: 입력 및 스킬 중단");

        if (movement != null)
            movement.enabled = false;
        if(rd != null)
            rd.simulated = false;

        if (skillController != null)
            skillController.enabled = false;

        // 필요 시 콜라이더 끄기 (충돌 방지)
        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
            col.enabled = false;
    }
}
