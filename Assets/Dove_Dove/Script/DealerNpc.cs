using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DealerNpc : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject spawnEffect;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
            SpawnDealer();
    }
    public void SpawnDealer()
    {
        if (spawnEffect != null)
        {
            // ����Ʈ ���� �� 2�� �� �ڵ� ����
            GameObject effect = Instantiate(spawnEffect, transform.position, Quaternion.identity);
            Destroy(effect, 2f);
        }
        else
        {
            Debug.LogWarning("SpawnEffect �������� �Ҵ���� �ʾҽ��ϴ�.");
        }
    }
}
