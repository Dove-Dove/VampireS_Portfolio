using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkill
{
    void Initialize(GameObject owner);
    void Activate();
    void TryActivate();
    void LevelUp();
    float GetCooldown();
    string GetName();

}