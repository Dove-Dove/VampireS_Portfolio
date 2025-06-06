using UnityEngine;

public class SkillTestStarter : MonoBehaviour
{
    [SerializeField] private GameObject fireballSkillPrefab;

    private void Start()
    {
        PlayerSkillController skillController = GetComponent<PlayerSkillController>();
        if (skillController != null && fireballSkillPrefab != null)
        {
            skillController.EquipSkill(fireballSkillPrefab);
        }
    }
}
