using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    private PlayerStatus status;

    private void Awake()
    {
        status = GetComponent<PlayerStatus>();
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
        Debug.Log("플레이어 사망 처리 로직 실행됨");
        // TODO: 게임 오버 UI 띄우기, 리스폰, 이펙트 등
    }
}
