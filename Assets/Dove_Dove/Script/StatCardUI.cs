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




    // Start is called before the first frame update
    void Start()
    {
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
}
