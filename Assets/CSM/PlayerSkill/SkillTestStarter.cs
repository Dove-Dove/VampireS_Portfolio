using UnityEngine;

public class SkillTestStarter : MonoBehaviour
{
    [SerializeField] private GameObject fireballSkillPrefab;
    [SerializeField] private GameObject magicBoltSkillPrefab;

    private PlayerSkillController skillController;
    private PlayerStatus playerStatus;
    private PlayerMovement movement;
    private PlayerCharacter character;

    private void Start()
    {
        skillController = GetComponent<PlayerSkillController>();
        playerStatus = GetComponent<PlayerStatus>();
        movement = GetComponent<PlayerMovement>();
        character = GetComponent<PlayerCharacter>();

        if (skillController != null && fireballSkillPrefab != null)
        {
            skillController.EquipSkill(fireballSkillPrefab);
            skillController.EquipSkill(magicBoltSkillPrefab);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (playerStatus != null)
            {
                Debug.Log("Test: �ǰ� 10 ������");
                playerStatus.TakeDamage(10f);
            }
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (playerStatus != null)
            {
                Debug.Log("Test: ��� �ߵ�");
                playerStatus.TakeDamage(playerStatus.CurrentHealth);
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RevivePlayer();
        }
    }

    private void RevivePlayer()
    {
        Debug.Log("Test: ��Ȱ");

        // ü�� ȸ��
        if (playerStatus != null)
        {
            playerStatus.Revive(); // ���ο��� ü�� �� ���� ȸ��
        }

        // �Է� �� ��ų Ȱ��ȭ
        if (movement != null)
            movement.enabled = true;

        if (skillController != null)
            skillController.enabled = true;

        // �浹, ���� Ȱ��ȭ
        if (TryGetComponent(out Collider2D col))
            col.enabled = true;

        if (TryGetComponent(out Rigidbody2D rb))
            rb.simulated = true;

        
    }
}
