using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;



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

    //������ ���

    public StatCardData[] statCardDatas;

    public ItemData[] itemData;


    //���� ī�� 
    [System.Serializable]
    public class UserStateCard
    {
        public StatCardData stateData;
        public int count;
    }
    //���� ������ ������ �ִ��� Ȯ�� 
    [System.Serializable]
    public class UserItem
    {
        public ItemData itemData;
        public int count;
    }
    



    public List<UserItem> userGetItemData = new List<UserItem>();

    public List<UserStateCard> userStateData = new List<UserStateCard>();


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
            {
                GameStop();
            }
            else
                GameReStart();
        }
        
        
    }

    public void GameStop()
    {
        ui.GetComponent<UIManager>().escStopGame(true);
    }
    public void GameReStart()
    {

        ui.GetComponent<UIManager>().escStopGame(false);
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
            ui.GetComponent<UIManager>().openStateCard();
           
        }
        ui.GetComponent<UIManager>().UIGetEx(PlayerEx);
    }



    public ItemData RanItemData()
    {
        ItemData data;
        int randomNum = Random.Range(0, itemData.Length);
        data = itemData[randomNum];

        return data;

    }

    public StatCardData RanStatCardDate(int getNum)
    {
        StatCardData statCard;
        statCard = statCardDatas[getNum];
        return statCard;

    }





    public void AddItem(ItemData getItem)
    {
        UserItem found = null;

        //�������� �ִ��� Ȯ�� 
        foreach (UserItem item in userGetItemData)
        {
            if (item.itemData == getItem)
            {
                found = item;
                break;
            }
        }

        //var found = userGetItemData.Find(x => x.itemData == get);

        if (found != null) 
            found.count++;
        else 
            userGetItemData.Add(new UserItem { itemData = getItem, count = 1 });
    }

    public List<UserItem> SetUserItemData()
    {
        return userGetItemData;
    }

    public void AddState(StatCardData getState)
    {
        UserStateCard found = null;

        //�������� �ִ��� Ȯ�� 
        foreach (UserStateCard state in userStateData)
        {
            if (state.stateData == getState)
            {
                found = state;
                break;
            }
        }

        //var found = userGetItemData.Find(x => x.itemData == get);

        if (found != null)
            found.count++;
        else
            userStateData.Add(new UserStateCard { stateData = getState, count = 1 });
    }

    public List<UserStateCard> SetUserStateData()
    {
        return userStateData;
    }

}
