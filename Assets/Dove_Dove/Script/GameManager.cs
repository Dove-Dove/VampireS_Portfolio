using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    // 싱글톤 인스턴스
    public static GameManager Instance { get; private set; }

    //플레이어
    private GameObject Player;

    //카메라
    private GameObject Cam;

    //플레이 타임
    float playTime = 0;


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
        if (Player == null)
        {
            Player = GameObject.Find("Player"); // 씬 로드 시 다시 Player 찾기
        }

        if (Cam == null)
        {
            Cam = GameObject.Find("Main Camera");
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

        }


    }

    // Update is called once per frame
    void Update()
    {
        playTime += Time.deltaTime;




    }
}
