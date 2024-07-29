using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    AudioSource _audioSource;

    [SerializeField]
    AudioClip _clickedAudio;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
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
        _audioSource.PlayOneShot(_clickedAudio);
        SceneManager.LoadScene("GameScene");
    }

    void OnExitButtonClicked()
    {
        _audioSource.PlayOneShot(_clickedAudio);
        Application.Quit();
    }
}
