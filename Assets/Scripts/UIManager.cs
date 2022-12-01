using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIManager : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text text;

    private void Start()
    {
        GameManager.Instance.LoadScore();
        if(GameManager.Instance.name != null) {
            text.text = "Best Score: " + GameManager.Instance.name +  " " + GameManager.Instance.score;
        }
    }

    public void StartNew()
    {
        GameManager.Instance.name = inputField.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        GameManager.Instance.SaveScore(); 
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit(); // original code to quit Unity player
        #endif
    }
}
