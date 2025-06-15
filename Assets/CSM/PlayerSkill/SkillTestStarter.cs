using UnityEngine;

public class SkillTestStarter : MonoBehaviour
{
    [SerializeField] private GameObject fireballSkillPrefab;
    [SerializeField] private GameObject magicBoltSkillPrefab;

    private void Start()
    {
        PlayerSkillController skillController = GetComponent<PlayerSkillController>();
        if (skillController != null && fireballSkillPrefab != null)
        {
            skillController.EquipSkill(fireballSkillPrefab);
            skillController.EquipSkill(magicBoltSkillPrefab);
        }
    }
}
