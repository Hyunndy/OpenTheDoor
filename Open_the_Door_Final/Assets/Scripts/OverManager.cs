using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


/*
 ----------------------------------------------------------------------
 최종 수정일: 16.06.21
 파일명: Open_the_Door
 작성자: 유현지

 스크립트명: OverManager
 용도: 게임 오버 화면을 제어하는 스크립트
 ----------------------------------------------------------------------
 */

public class OverManager : MonoBehaviour
{

    //GameManager 스크립트를 GM으로 불러온다.
    public GameManager GM;

    //최종점수를 나타내기 위한 int변수.
    public int Final_Count;

    //최종점수 : Final_Count를 나타내는 Text변수.
    public Text Final;

    /*
    ----------------------------------------------------------------------
    1) Display

    -> 게임의 현재 진행상황을 나타내는 상태변수.
    ----------------------------------------------------------------------
    */
    public void Display()
    {
        //Sibal_Stage = PlayerPrefs.GetInt("Stage");
        Final_Count = PlayerPrefs.GetInt("Score");
        //Stage.text = string.Format("?? : {0}", Sibal_Stage);
        Final.text = string.Format("최종점수 : {0}", Final_Count);


    }

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        Display();
        // Delete();
    }
}
