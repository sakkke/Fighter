using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        var startButton = root.Q<Button>("start");
        var exitButton = root.Q<Button>("exit");

        if (startButton != null)
        {
            startButton.clicked += OnStartButtonClicked;
        }
        if (exitButton != null)
        {
            exitButton.clicked += OnExitButtonClicked;
        }
    }

    void OnStartButtonClicked()
    {
        SceneManager.LoadScene("GameScene");
    }

    void OnExitButtonClicked()
    {
        Application.Quit();
    }
}
