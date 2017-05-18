using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Buttons2 : MonoBehaviour
{

    public void OnGUI()
    {
        Debug.Log("버튼눌림");
        SceneManager.LoadScene("How_To_Play");
    }
}
