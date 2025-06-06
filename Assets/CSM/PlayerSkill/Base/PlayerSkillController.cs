using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillController : MonoBehaviour
{
    [SerializeField] private Transform skillContainer;

    private List<ISkill> equippedSkills = new List<ISkill>();

    private void Update()
    {
        foreach (var skill in equippedSkills)
        {
            skill.TryActivate();
        }
    }

    public void EquipSkill(GameObject skillPrefeb)
    {
        GameObject obj = Instantiate(skillPrefeb, skillContainer.position, Quaternion.identity, skillContainer);
        ISkill skill = obj.GetComponent<ISkill>();
        if (skill != null )
        {
            skill.Initialize(gameObject);
            equippedSkills.Add(skill);
        }
    }
    public void UpgradeSkill(string skillName)
    {
        foreach(var skill in equippedSkills)
        {
            if(skill.GetName() == skillName)
            {
                skill.LevelUp();
                break;
            }
        }
    }
    public bool HasSkill(string skillName)
    {
        return equippedSkills.Exists(s => s.GetName() == skillName);
    }

}
