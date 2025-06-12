using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatCardUI : MonoBehaviour
{
    public TextMeshProUGUI statName;

    public TextMeshProUGUI statText;

    public Image UiImg;

    public Button cardButton;



    // Start is called before the first frame update
    void Start()
    {
        cardButton.onClick.AddListener(clickEvent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetingStatUi(string setStatName, string setStatText, Sprite setStatImg)
    {
        statName.text = setStatName;
        statText.text = setStatText;
        UiImg.sprite = setStatImg;

    }

    void clickEvent()
    {
        //���⿡ �������� �����Ұ� �߰�

        //�ݱ�
        GameObject ui;
        ui = GameObject.Find("UI_Canvas");
        ui.GetComponent<UIManager>().closeStateCard();
    }
}
