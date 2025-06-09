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
        //시작 버튼 클릭 이벤트
        StartButton.onClick.AddListener(test);

        //샵 버튼
        ShopButton.onClick.AddListener(test);

        //샵 버튼
        OptionButton.onClick.AddListener(test);

        //종료 버튼
        EndButton.onClick.AddListener(test);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void test()
    {
        Debug.Log("테스트 ");
    }
}
