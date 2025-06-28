using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameField;
    public TMP_Text bestScoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nameField.text = RealManager.Instance.Name;
        bestScoreText.text = $"Best Score: {RealManager.Instance.BestScore}";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        RealManager.Instance.Name = nameField.text;
        SceneManager.LoadScene("main");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }


}
