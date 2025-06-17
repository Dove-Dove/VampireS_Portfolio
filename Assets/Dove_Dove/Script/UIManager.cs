using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI timeText;

    public TextMeshProUGUI WaveText;

    [SerializeField]
    private Slider HP_Slider;
    [SerializeField]
    private Slider EX_Slider;

    public GameObject[] statUiAll;

    public GameObject stopPanel;
    public GameObject pauseMenu;

    public GameObject GKeyUi;
    bool stop =false;

    public int DataCount = 0;

    private float gamePlayTime = 0;



    void Start()
    {
        EX_Slider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gamePlayTime += Time.deltaTime;

        // F1 -> 소수점 한자리까지 표시
        timeText.text = gamePlayTime.ToString("F1");

    }

    public void UIGetEx(float ex)
    {
        EX_Slider.value = ex / 100;
    }

    public void setPlayerHit(float playerHP)
    {
        float playerHpSlider = playerHP / 100;
        HP_Slider.value = playerHpSlider;
    }

    public void setWaveText(int wave)
    {
        WaveText.text = "Wave " + wave.ToString();
    }

    public void SettingStateCard()
    {

        //for(int count= 0; count < statUiAll.Length; count++)
        //{
        //    int randNum = Random.Range(0, statCardDatas.Length);

        //    for(int tm = 0; tm < temporarySave.Length; tm++)
        //    {
        //        if (temporarySave[tm] == randNum)
        //        {
        //            saveCard = false ;
        //            count--;
        //            break;
        //        }

        //        if(tm == temporarySave.Length-1)
        //        {
        //            saveCard = true ;
        //            temporarySave[tm] = randNum;
        //        }
        //    }

        //    if (true)
        //    {
        //        statUiAll[count].GetComponent<StatCardUI>().SetingStatUi
        //            (statCardDatas[randNum].name , statCardDatas[randNum].StatExplanation 
        //            , statCardDatas[randNum].StatCardImg);

        //        saveCard = false ;
        //    }
            
        //}

        List<int> usedIndices = new List<int>();

        for (int count = 0; count < statUiAll.Length; count++)
        {
            int randNum;

            // 중복되지 않는 랜덤 번호를 뽑을 때까지 반복
            do
            {
                randNum = Random.Range(0, DataCount);
            }
            while (usedIndices.Contains(randNum));

            usedIndices.Add(randNum); // 중복 방지용 저장
            StatCardData stat = GameManager.Instance.RanStatCardDate(randNum);

            statUiAll[count].GetComponent<StatCardUI>().SetingStatUi(
                stat.name,
                stat.StatExplanation,
                stat.StatCardImg
            );
            statUiAll[count].SetActive(true);
        }
    }

    public void escStopGame(bool stop)
    {

        if (stop)
        {
            stopPanel.SetActive(true);
            pauseMenu.SetActive(true);
        }
        else
        {
            pauseMenu.SetActive(false);
            stopPanel.SetActive(false);
        }
    }

    public void openStateCard()
    {
        stopPanel.SetActive(true);
        
        SettingStateCard();
        Time.timeScale = 0;

    }

    public void closeStateCard()
    {
        for (int count = 0; count < statUiAll.Length; count++)
        {
            statUiAll[count].SetActive(false);
        }
        stopPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void GKeyActive(bool active, GameObject gameObj)
    {
        GKeyUi.SetActive(active);

        if(Input.GetKeyDown(KeyCode.G) && active)
        {
            gameObj.SetActive(false);
            GKeyUi.SetActive(false );
        }

    }

    

}
