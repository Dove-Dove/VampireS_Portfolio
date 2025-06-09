using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    // �̱��� �ν��Ͻ�
    public static GameManager Instance { get; private set; }

    //�÷��̾�
    private GameObject Player;

    private int playerLevel;

    private int PlayerEx;

    //ī�޶�
    private GameObject Cam;

    //UI
    private GameObject ui;

    //���� ���� 
    public int nowLeval;

    //��Ÿ ����
    bool GameStopKeyDown = false;



    //�÷��� Ÿ��
    //[HideInInspector]
    //public float playTime = 0;


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
        FindObj();

        ui.GetComponent<UIManager>().setWaveText(nowLeval);

    }

    // Update is called once per frame
    void Update()
    {
        //FindObj();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameStopKeyDown = !GameStopKeyDown;
            if (GameStopKeyDown)
                GameStop();
            else
                GameReStart();
        }
        
        
    }

    public void GameStop()
    {
        Time.timeScale = 0;
    }
    public void GameReStart()
    {
        Time.timeScale = 1;
    }

    public void getLevel(int GetLevel)
    {
        playerLevel += GetLevel;

    }

    public void StartGame()
    {
        nowLeval = 0;
        playerLevel = 0;


    }

    private void FindObj()
    {
        if (Player == null)
        {
            Player = GameObject.Find("Player"); // �� �ε� �� �ٽ� Player ã��
        }

        if (Cam == null)
        {
            Cam = GameObject.Find("Main Camera");
        }

        if(ui == null)
        {
            ui = GameObject.Find("UI_Canvas");
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

            if (Cam == null)
            {
                Debug.LogWarning("UI ������Ʈ�� ã�� �� �����ϴ�.");
                return;
            }
        }
    }

    public void GetEx(int ex)
    {
        PlayerEx += ex;
        if (PlayerEx >= 100)
        {
            PlayerEx -= 100;
            playerLevel ++;
        }
        ui.GetComponent<UIManager>().UIGetEx(PlayerEx);
    }
}
