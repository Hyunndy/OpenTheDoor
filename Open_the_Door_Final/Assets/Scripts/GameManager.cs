using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using UnityEditor.SceneManagement;


/*
 ----------------------------------------------------------------------
 최종 수정일: 16.06.21
 파일명: Open_the_Door
 작성자: 유현지

 스크립트명: GameManager
 용도: 게임 오브젝트들을 총괄하는 스크립트.
 ----------------------------------------------------------------------
 */


/*
----------------------------------------------------------------------
1) GameState

-> 게임의 현재 진행상황을 나타내는 상태변수.
----------------------------------------------------------------------
*/
public enum GameState
{
    Ready,
    Play,
    End
}

public class GameManager : MonoBehaviour
{
/*
----------------------------------------------------------------------
 2) GameManager스크립트의 변수들
----------------------------------------------------------------------
*/
    //게임스테이트 변수.
    public GameState GS; 

    //현재 씬의 이름을 가져오기 위한 변수. (Start나 Over씬에서 Game씬에서의 이벤트가 발생하면 안되기 때문.
    public string Current_Scene;

    //제한시간 표기를 위한 변수.
    public float LimitTime;
    public Text TimeText;

    //통과한 문의 숫자를 나타내는 변수 -> 나중에 최종점수를 나타낼 때 필요함.
    public int Count_Clear_Door;
    //통과한 스테이지의 숫자를 나타내는 변수 -> 맵 전환에 이용되는 변수.
    public int Count_Clear_Stage;


    //문이 열릴 때 나타내는 사운드를 나타내는 Audio변수.
    public AudioSource Go_Source;
    public AudioClip GoSound;
   


    /*
    ----------------------------------------------------------------------
    3) Go() 함수

    -> 문이 열릴 때 Go!하는 사운드가 나오게 하는 함수.
    ----------------------------------------------------------------------
    */
    public void Go()
    {
       
        GS = GameState.Play;

        { 
            Go_Source = GetComponent<AudioSource>();
            Go_Source.clip = GoSound;
            Go_Source.Play();
        }
        
        /*
        GS = GameState.Play;
        Go_Source = GetComponent<AudioSource>();
        Go_Source.clip = GoSound;
        Go_Source.Play();
        */
    }

/*
----------------------------------------------------------------------
4) Save_Score() 함수

-> 문이 열릴 때 마다 Count_Clear_Door변수가 1씩 증가하게 만들어주는 함수.

-> PlayerPrefs.를 이용해서 "Score"라는 저장공간에 Count_Clear_Door을 저장한다.
-> 씬이 여러 개 반복 되면서 진행되기 때문에 Count_Clear_Door은 씬이 바뀔 때 마다 초기화된다.
-> 따라서 GameManager 스크립트의 Start()함수에 Count_Clear_Door은 "Score"이란걸 저장해둬야한다. 
----------------------------------------------------------------------
*/

    public void Save_Score()
    {
        Count_Clear_Door += 1;

        PlayerPrefs.SetInt("Score", Count_Clear_Door);
    }

/*
----------------------------------------------------------------------
5) Count_Stage() 함수

-> 문이 열릴 때 마다 Count_Clear_Stage 변수의 숫자를 1씩 늘려주는 함수.
-> PlayerPrefs.를 이용해서 "Stage"라는 저장공간에 Count_Clear_Stage을 저장한다.
----------------------------------------------------------------------
*/

    public void Count_Stage()
    {
        Count_Clear_Stage += 1;

        PlayerPrefs.SetInt("Stage", Count_Clear_Stage);
    }

/*
----------------------------------------------------------------------
6) Count_Stage_No() 함수

-> 현재 스테이지가 어딘지 반환해주는 int함수.
-> Stage 당 맵 전환을 위해 반환시킨다.
-> 각 door스크립트에서 Stage를 얻어오지를 않아서 이걸 넣어줬더니 잘 얻어온다. ㅇㅅㅇ

----------------------------------------------------------------------
*/
    public int Count_Stage_No()
    {
        return PlayerPrefs.GetInt("Stage");
    }

/*
----------------------------------------------------------------------
7) Start() 함수

-> C# 스크립트에서 중요한 함수
-> 스크립트가 호출 될 때 마다 딱 1번씩만 호출되는 함수
-> 초기화에 쓰이는 함수!!!!!!!!!!!!
----------------------------------------------------------------------
*/
    void Start()
    {
       //Current_Scene을 현재 Scene의 이름으로 저장해둔다.
       Current_Scene = SceneManager.GetActiveScene().name;

       //Count_Clear_Door에 "Score"을 저장한다.
       //이렇게 하는 이유는 씬이 전환 될 때 마다 변수들이 초기화되기 때문.
       Count_Clear_Door = PlayerPrefs.GetInt("Score");


       //Count_Clear_Stage에 "Stage"을 저장한다.       
       Count_Clear_Stage = PlayerPrefs.GetInt("Stage");
    }

/*
----------------------------------------------------------------------
8) Update() 함수

-> C# 스크립트에서 아주 중요한 함수!!
-> 프레임이 넘어갈 때 마다 계속 호출되는 함수.
-> 계~속 실행되고 있어야하는 함수들을 넣어 놓으면 된다.
----------------------------------------------------------------------
*/
    void Update()
    {
        //제한시간이 끝나면 Over로 넘어가는걸 구현했음.
        if (Current_Scene != "Over" && Current_Scene != "Start")
        {
            TimeText.text = string.Format("{0:N1}", LimitTime);
            LimitTime -= Time.deltaTime;
            if (LimitTime <= 0)
            { 
                //게임이 끝나는 시점.
                LimitTime = 0;
                SceneManager.LoadScene("Over");
            }
        }
    }


    
    /*
if (PlayerPrefs.HasKey("Score") && PlayerPrefs.HasKey("Stage"))
{
    if (Current_Scene == "Start")
    {
        PlayerPrefs.DeleteKey("Score");
        PlayerPrefs.DeleteKey("Stage");
        Count_Clear_Door = 0;
        Count_Clear_Stage = 0;
    }
    else
    {

    }
}    */

}
