using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public enum DoorState
{
    Close,
    Open
}


public class Door1 : MonoBehaviour {

    public DoorState DS;
    public GameManager GM;

    //터치 한 번만 되게 bool변수
    bool click = false;
   
    public Sprite Open_Images;
    SpriteRenderer sprite_render;

    //꽝이 아닌 맞는 문이 라는 뜻 ClearDoor->CorrectDoor으로 이름 바꿈
    public bool CorrectDoor;

    //맞는 문인가에 대한 확률
    public int CorrectRange;

    

    public void Open()
    {
        click = false;
        // 1~100이 어떻게 나오냐에 따라 그 문이 over화면으로 갈지, 다음 game씬으로 갈지 결정한다.
        float a = Random.Range(0, 100);

        //이 밑은 문이 다음 스테이지로 통과할지 안할지가 아니라 그 문이 문2개 인 씬으로 갈지, 문 3개인 씬으로 갈지 결정하는것.

        if (a >= CorrectRange)
        {
            CorrectDoor = true;
            GM.Save_Score();
            GM.Count_Stage();

            float b = Random.Range(0, 100);

            if (GM.Get_Count_Stage() <= 5)

            {
                if (b >= 50)
                    SceneManager.LoadScene("Game");
                else if (b < 50)
                    SceneManager.LoadScene("Game 1");
            }

            else if (GM.Get_Count_Stage() > 5 && GM.Get_Count_Stage() <= 10)
            {
                if (b >= 50)
                    SceneManager.LoadScene("Game 2");
                else if (b < 50)
                    SceneManager.LoadScene("Game 3");
            }

            else if(GM.Get_Count_Stage() == 11)
            {
                SceneManager.LoadScene("Clear");
            }

            // 이 부분을 고쳐야 Clear 다음에 넘어가더라도 될듯..? Clear에서 Count_Stage가 0이 안되고 이어지게 하면 될듯.
            
        }
        else
        {
            CorrectDoor = false;
            SceneManager.LoadScene("Over");
        }
    }

    public void Open_Sound()
    {
        
        GM.Go();
        StartCoroutine(WaitForSound());

//  DS = DoorState.Open;
//  sprite_render.sprite = Open_Images;
//
//
//  Clear();

    }

    public void OnMouseDown()
    {
        if (click == false)
        {
            Debug.Log("버튼눌림");
            click = true;
            if (DS == DoorState.Close)
            {
                //GM.Go();

                Open_Sound();
                // StartCoroutine(WaitForSound());

            }
        }
    }


    void Start()
    {
        sprite_render =GetComponent<SpriteRenderer>();
        click = false;
       // sprite_render.sprite = Closed_Images;
        DS = DoorState.Close;   

    }


    IEnumerator WaitForSound()
    {

        while (GM.Go_Source.isPlaying)
           yield return null;

        DS = DoorState.Open;
        sprite_render.sprite = Open_Images;

         Open();
    }

    void Update()
    {

   

    }
}
