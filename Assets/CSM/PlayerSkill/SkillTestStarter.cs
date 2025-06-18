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
                Debug.Log("Test: 피격 10 데미지");
                playerStatus.TakeDamage(10f);
            }
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (playerStatus != null)
            {
                Debug.Log("Test: 즉사 발동");
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
        Debug.Log("Test: 부활");

        // 체력 회복
        if (playerStatus != null)
        {
            playerStatus.Revive(); // 내부에서 체력 및 상태 회복
        }

        // 입력 및 스킬 활성화
        if (movement != null)
            movement.enabled = true;

        if (skillController != null)
            skillController.enabled = true;

        // 충돌, 물리 활성화
        if (TryGetComponent(out Collider2D col))
            col.enabled = true;

        if (TryGetComponent(out Rigidbody2D rb))
            rb.simulated = true;

        
    }
}
