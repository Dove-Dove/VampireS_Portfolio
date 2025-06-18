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
        Debug.Log("�÷��̾� ���: �Է� �� ��ų �ߴ�");

        if (movement != null)
            movement.enabled = false;
        if(rd != null)
            rd.simulated = false;

        if (skillController != null)
            skillController.enabled = false;

        // �ʿ� �� �ݶ��̴� ���� (�浹 ����)
        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
            col.enabled = false;
    }
}
