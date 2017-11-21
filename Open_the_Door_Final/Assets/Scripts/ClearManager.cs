using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ClearManager : MonoBehaviour {


    //마지막에 끝날 때 나타나는 사운드를 나타내는 Audio변수. (아직 활성화 안시킴)
    public AudioSource Finish_Source;
    public AudioClip FinishSound;

    public Sprite Round1_Image;
    public Sprite Round2_Image;
    public Sprite Round3_Image;
    public Sprite Round4_Image;
    public Sprite Round5_Image;

    SpriteRenderer sprite_render;

    public void Change_Round()
    {

    }


    public void Sound_Play()
    {
        Finish_Source = GetComponent<AudioSource>();
        Finish_Source.clip = FinishSound;
        Finish_Source.Play();

    }
    // Use this for initialization
    void Start ()
    {
	        Sound_Play();
	}
	
	// Update is called once per frame
	void Update () {


	}
}
