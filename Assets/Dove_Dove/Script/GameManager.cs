using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    // �̱��� �ν��Ͻ�
    public static GameManager Instance { get; private set; }

    //�÷��̾�
    private GameObject Player;

    //ī�޶�
    private GameObject Cam;

    //�÷��� Ÿ��
    float playTime = 0;


    private void Awake()
    {
        //������ ����
        Application.targetFrameRate = 120;

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �� ��ȯ �Ŀ��� GameManager ����
        }
        else
        {
            Destroy(gameObject); // �ߺ��� GameManager�� ������ ����
        }

        Player = GameObject.Find("Player");
        Cam = GameObject.Find("Main Camera");
    }

    void Start()
    {
        if (Player == null)
        {
            Player = GameObject.Find("Player"); // �� �ε� �� �ٽ� Player ã��
        }

        if (Cam == null)
        {
            Cam = GameObject.Find("Main Camera");
        }

        {//�ٽ� Ȯ��
            if (Player == null)
            {
                Debug.LogWarning("Player ������Ʈ�� ã�� �� �����ϴ�.");
                return;
            }


            if (Cam == null)
            {
                Debug.LogWarning("Camera ������Ʈ�� ã�� �� �����ϴ�.");
                return;
            }

        }


    }

    // Update is called once per frame
    void Update()
    {
        playTime += Time.deltaTime;




    }
}
