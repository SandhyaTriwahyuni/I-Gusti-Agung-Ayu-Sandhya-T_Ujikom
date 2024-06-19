using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Button playButton;
    public Button exitButton;

    void Start()
    {
        if (playButton != null)
        {
            playButton.onClick.AddListener(OnPlayButtonClick);
        }

        if (exitButton != null)
        {
            exitButton.onClick.AddListener(OnExitButtonClick);
        }
    }

    void OnPlayButtonClick()
    {
        SceneManager.LoadScene("GameplayScene");
    }

    void OnExitButtonClick()
    {
        Application.Quit();
    }
}
