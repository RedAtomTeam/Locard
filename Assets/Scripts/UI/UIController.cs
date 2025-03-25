using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] private LevelController levelController;

    [SerializeField] private WinWindow winWindow;
    [SerializeField] private LooseWindow looseWindow;
    [SerializeField] private GameObject exitWindow;
    [SerializeField] private TextMeshProUGUI stepsText;


    public void UpdateSteps(int steps, int maxSteps)
    {
        string text = $"{steps}/{maxSteps}";
        this.stepsText.text = text;
    }


    public void Win(string text)
    {
        this.winWindow.Open(text);
    }


    public void Loose(string text)
    {
        this.looseWindow.Open(text);
    }


    public void OpenExitWindow()
    {
        this.levelController.inputHandler.gameObject.SetActive(false);
        this.exitWindow.SetActive(true);
    }


    public void CloseExitWindow()
    {
        this.levelController.inputHandler.gameObject.SetActive(true);
        this.exitWindow.SetActive(false);
    }


    public void LoadChoosLevelsScene()
    {
        SceneManager.LoadScene("ChooseLevel");
    }
}
