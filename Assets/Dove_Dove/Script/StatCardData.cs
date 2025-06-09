using System.Collections.Generic;
using UnityEngine;

[System.Flags]
public enum StatCardEffect
{
    None = 0,
    PowerUp = 1 << 0,
    SpeedUp = 1 << 1,
    HPUp = 1 << 2,
    PowerDown = 1 << 3,
    SpeedDown = 1 << 4,
    HpDown = 1 << 5,

}



[CreateAssetMenu(fileName = "Stat Card Data", menuName = "Scriptable/Stat Card Data", order = int.MaxValue)]

public class StatCardData : ScriptableObject
{
    [SerializeField]
    private string statCardName;
    public string StatCardName => statCardName;
    //    public string StatCardName {  get { return statCardName; }} ������ �̰� �б� ���뿡�� ���� ����


    [SerializeField]
    private Sprite statCardImg;
    public Sprite StatCardImg => statCardImg;

    [SerializeField]
    private string statExplanation;
    public string StatExplanation => statExplanation;

    //����Ʈȭ �Ѱ�
    [System.Serializable]
    public class StatEffectData
    {
        public StatCardEffect effectType; // 
        public float value;               //
    }

    [SerializeField]
    private List<StatEffectData> effects;
    public List<StatEffectData> Effects => effects;
}
