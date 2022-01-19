using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Class to manage main menu behaviour
/// </summary>
public class MainMenuManager : MonoBehaviour
{
    public TMP_InputField NameInputField;
    public Button StartButton;
    public Button QuitButton;
    public GameObject LoadingText;

    void Start()
    {
        StartButton.interactable = false;
        LoadingText.SetActive(false);

        StartButton.onClick.AddListener(() =>
        {
            StartGame();
        });

        QuitButton.onClick.AddListener(() =>
        {
            Application.Quit(0);
        });

        NameInputField.onValueChanged.AddListener((string text) =>
        {
            ValidateInput(text);
        });
    }
    private void StartGame()
    {
        GlobalVariables.PLAYER_NAME = NameInputField.text;
        LoadingText.SetActive(true);
        SceneManager.LoadScene("SampleScene");
    }

    private void ValidateInput(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            StartButton.interactable = false;
        }
        else
        {
            StartButton.interactable = true;
        }
    }
}
