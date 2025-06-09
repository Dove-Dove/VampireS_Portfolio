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
}
