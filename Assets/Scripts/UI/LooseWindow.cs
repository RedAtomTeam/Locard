using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LooseWindow : MonoBehaviour
{
    [SerializeField] private GameObject _obj;
    [SerializeField] private TextMeshProUGUI _looseText;

    public void Open(string LooseText)
    {
        this._looseText.text = LooseText;
        this._obj.SetActive(true);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
