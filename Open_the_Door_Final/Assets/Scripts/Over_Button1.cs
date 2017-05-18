using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Over_Button1 : MonoBehaviour {

    public void OnMouseDown()
    {
        Debug.Log("버튼눌림");
        PlayerPrefs.DeleteKey("Score");
        PlayerPrefs.DeleteKey("Stage");
        SceneManager.LoadScene("Start");
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
