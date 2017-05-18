using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Door3 : MonoBehaviour
    {

    public DoorState DS;
    public GameManager GM;

        // public Sprite Closed_Images;
        public Sprite Open_Images;
        SpriteRenderer sprite_render;

        public bool ClearDoor;
        public int PerClear = 80;


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

            else if(GM.Count_Stage_No() > 5 && GM.Count_Stage_No() <= 10)
            {
                if (b >= 50)
                    SceneManager.LoadScene("Game 2");
                else if (b < 50)
                    SceneManager.LoadScene("Game 3");
            }

            
            else if (GM.Count_Stage_No() == 11)
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

        IEnumerator WaitForSound()
    {

            while (GM.Go_Source.isPlaying)
                yield return null;
            Open();
        
    }

        void Start()
        {
            sprite_render = GetComponent<SpriteRenderer>();

            DS = DoorState.Close;

        }


        void Update()
        {



        }
    }

