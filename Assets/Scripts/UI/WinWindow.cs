using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinWindow : MonoBehaviour
{
    [SerializeField] private GameObject _obj;
    [SerializeField] private TextMeshProUGUI _winText;

    public void Open(string WinText) 
    {
        this._winText.text = WinText;
        this._obj.SetActive(true);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Next()
    {
        if (GameDataManager.Instance != null)
        {
            for (int i = 1; i < GameDataManager.Instance.playerGameData._levels.Count; i++)
            {
                if (GameDataManager.Instance.playerGameData._levels[i - 1]._name == SceneManager.GetActiveScene().name)
                {
                    SceneManager.LoadScene(GameDataManager.Instance.playerGameData._levels[i]._name);
                    break;
                }
            }
        }
    }
}
