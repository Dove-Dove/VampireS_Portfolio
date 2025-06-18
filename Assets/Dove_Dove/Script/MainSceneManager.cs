using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class MainSceneManager : MonoBehaviour
{
    FullScreenMode fullScreenMode;

    // Start is called before the first frame update
    public Button StartButton;

    public Button ShopButton;

    public Button OptionButton;

    public Button EndButton;

    public TMP_Dropdown resolutionsDropdown;
    List<Resolution> resolutions = new List<Resolution>();
    int resolutionNum;


    void Start()
    {
        //���� ��ư Ŭ�� �̺�Ʈ
        StartButton.onClick.AddListener(test);

        //�� ��ư
        ShopButton.onClick.AddListener(test);

        //�� ��ư
        OptionButton.onClick.AddListener(test);

        //���� ��ư
        EndButton.onClick.AddListener(test);
        DropDownShow();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void test()
    {
        Debug.Log("�׽�Ʈ ");
    }

    void DropDownShow()
    {
        resolutions.Clear();  // �ߺ� ����
        resolutions.AddRange(Screen.resolutions);
        resolutionsDropdown.options.Clear();
        int optionNum = 0;

        foreach (Resolution res in resolutions)
        {
            string optionText = $"{res.width} x {res.height} ";
            resolutionsDropdown.options.Add(new TMP_Dropdown.OptionData(optionText));

            if (res.width == Screen.width && res.height == Screen.height)
                resolutionsDropdown.value = optionNum;
            optionNum++;
        }

        resolutionsDropdown.RefreshShownValue();
    }

    public void DropBoxChange(int x)
    {
        resolutionNum = x;

    }

    public void onBtnClick()
    {
        Screen.SetResolution(resolutions[resolutionNum].width, resolutions[resolutionNum].height
            , fullScreenMode);
    }
}
