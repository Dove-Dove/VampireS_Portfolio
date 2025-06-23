using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SaleItems : MonoBehaviour
{
    //���� ����
    public float detectionRadius = 3f;
    Vector3 movePos;

    GameObject ui;

    ItemData itemData;



    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.Find("UI_Canvas");
        GetItemData();
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
        bool playerDetected = false;

        foreach (var hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                movePos = (hit.transform.position - transform.position).normalized;
                playerDetected = true;
                break; // �÷��̾ �����ϸ� �ǹǷ� �ݺ� �ߴ�
            }
        }

        ui.GetComponent<UIManager>().GKeyActive(playerDetected, gameObject, itemData);
    }

    // ����׿�: ���� ���� �ð�ȭ
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

    public void GetItemData()
    {
        itemData = GameManager.Instance.RanItemData();
        GetComponent<SpriteRenderer>().sprite = itemData.ItemImg;

    }
}
