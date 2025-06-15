using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkill : MonoBehaviour, ISkill
{
    protected GameObject owner;
    protected int level = 1;
    protected float coldown = 1;
    private float lastUseTime = -999f;

    protected PlayerStatus Status
    {
        get
        {
            if (_status == null && owner != null)
                _status = owner.GetComponent<PlayerStatus>();
            return _status;
        }
    }
    private PlayerStatus _status;

    public abstract void Activate();
    public abstract string GetName();

    public float GetColldown() => coldown;

    public void Initialize(GameObject owner)
    {
        this.owner = owner;
        lastUseTime = Time.time;
    }
    public void TryActivate()
    {
        if(Time.time - lastUseTime >= coldown)
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
