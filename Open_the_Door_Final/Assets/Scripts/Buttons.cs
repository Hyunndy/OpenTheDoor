using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Buttons : MonoBehaviour {


  //  public GameManager GM;
    public AudioSource Go_Source;
    public AudioClip GoSound;


    public void OnGUI()
    {
        Debug.Log("버튼눌림");

        Go_Source = GetComponent<AudioSource>();
        Go_Source.clip = GoSound;
        Go_Source.Play();
       // GM.Count_Stage();
        StartCoroutine(WaitForSound()); 
    }


    IEnumerator WaitForSound()
    {
        while (Go_Source.isPlaying)
            yield return null;

   
      SceneManager.LoadScene("Game");
    }
}
