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
        Debug.Log("�÷��̾� ��� ó�� ���� �����");
        // TODO: ���� ���� UI ����, ������, ����Ʈ ��
    }
}
