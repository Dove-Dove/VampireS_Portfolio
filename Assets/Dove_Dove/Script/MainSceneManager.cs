using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class MainSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Button StartButton;

    public Button ShopButton;

    public Button OptionButton;

    public Button EndButton;

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
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void test()
    {
        Debug.Log("�׽�Ʈ ");
    }
}
