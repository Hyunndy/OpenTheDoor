using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class How_To_Play_Button1 : MonoBehaviour {


    public void OnMouseDown()
    {
        Debug.Log("버튼눌림");
        SceneManager.LoadScene("Start");
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
