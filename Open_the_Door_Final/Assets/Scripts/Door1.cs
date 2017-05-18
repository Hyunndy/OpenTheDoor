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

   
    public Sprite Open_Images;
    SpriteRenderer sprite_render;

    public bool ClearDoor;
    public int PerClear;



    public void Clear()
    {
        float a = Random.Range(0, 100);

        if (a >= PerClear)
        {
            ClearDoor = true;
            GM.Save_Score();
            GM.Count_Stage();

            float b = Random.Range(0, 100);

            if (GM.Count_Stage_No() <= 5)

            {
                if (b >= 50)
                    SceneManager.LoadScene("Game");
                else if (b < 50)
                    SceneManager.LoadScene("Game 1");
            }

            else if (GM.Count_Stage_No()>5 && GM.Count_Stage_No()<=10)
            {
                if (b >= 50)
                    SceneManager.LoadScene("Game 2");
                else if (b < 50)
                    SceneManager.LoadScene("Game 3");
            }

            else if(GM.Count_Stage_No() == 11)
            {
                SceneManager.LoadScene("Clear");
            }
            
        }
        else
        {
            ClearDoor = false;
            SceneManager.LoadScene("Over");
        }
    }

    public void Open()
    {
        DS = DoorState.Open;
        sprite_render.sprite = Open_Images;

        Clear();

    }

    public void OnMouseDown()
    {

        Debug.Log("버튼눌림");
        if (DS == DoorState.Close)
        {
            GM.Go();
            StartCoroutine(WaitForSound());
 
        }
    }

    void Start()
    {
        sprite_render =GetComponent<SpriteRenderer>();
       // sprite_render.sprite = Closed_Images;
        DS = DoorState.Close;   

    }

    IEnumerator WaitForSound()
    {

            while (GM.Go_Source.isPlaying)
                yield return null;
            Open();
        
    }

    void Update()
    {

   

    }
}
