using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    // 싱글톤 인스턴스
    public static GameManager Instance { get; private set; }

    //플레이어
    private GameObject Player;

    private int playerLevel;

    private int PlayerEx;

    //카메라
    private GameObject Cam;

    //UI
    private GameObject ui;

    //현제 레벨 
    public int nowLeval;

    //기타 세팅
    bool GameStopKeyDown = false;



    //플레이 타임
    //[HideInInspector]
    //public float playTime = 0;


    private void Awake()
    {
        //프레임 고정
        Application.targetFrameRate = 120;

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 후에도 GameManager 유지
        }
        else
        {
            Destroy(gameObject); // 중복된 GameManager가 있으면 삭제
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
            Player = GameObject.Find("Player"); // 씬 로드 시 다시 Player 찾기
        }

        if (Cam == null)
        {
            Cam = GameObject.Find("Main Camera");
        }

        if(ui == null)
        {
            ui = GameObject.Find("UI_Canvas");
        }

        {//다시 확인
            if (Player == null)
            {
                Debug.LogWarning("Player 오브젝트를 찾을 수 없습니다.");
                return;
            }


            if (Cam == null)
            {
                Debug.LogWarning("Camera 오브젝트를 찾을 수 없습니다.");
                return;
            }

            if (Cam == null)
            {
                Debug.LogWarning("UI 오브젝트를 찾을 수 없습니다.");
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
