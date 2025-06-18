using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDescription : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI ItemName;

    public Image ItemImg;

    public TextMeshProUGUI ItemPrice;

    public TextMeshProUGUI ItemText;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SettingDescription(ItemData itemData)
    {
        ItemName.text = itemData.name;
        ItemImg.sprite = itemData.ItemImg;
        ItemPrice.text = itemData.ItemPrice.ToString();
        ItemText.text = itemData.ItemText;

    }

}
