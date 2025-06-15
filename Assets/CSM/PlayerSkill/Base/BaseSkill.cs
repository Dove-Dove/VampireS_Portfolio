using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkill : MonoBehaviour, ISkill
{
    protected GameObject owner;
    protected int level = 1;
    protected float baseCooldown = 1f;
    private float lastUseTime;

    private PlayerStatus _status;
    protected PlayerStatus Status
    {
        get
        {
            if (_status == null && owner != null)
                _status = owner.GetComponent<PlayerStatus>();
            return _status;
        }
    }

    public abstract void Activate();
    public abstract string GetName();

    // ���� ����Ǵ� ��ٿ� = �⺻�� * (1 - ���� ���)
    public float GetCooldown()
    {
        float reduction = Status?.CooldownReduction ?? 0f;
        return baseCooldown * (1f - reduction);
    }

    // �������̽� ���ǿ� �浹 ������
    public float GetColldown() => baseCooldown;

    public void Initialize(GameObject owner)
    {
        this.owner = owner;
        lastUseTime = Time.time - GetCooldown(); // �ʱ⿣ �ٷ� �߻� �����ϰ�
    }

    public void TryActivate()
    {
        if (Time.time - lastUseTime >= GetCooldown())
        {
            Activate();
            lastUseTime = Time.time;
        }
    }

    public virtual void LevelUp()
    {
        level++;
    }
}
