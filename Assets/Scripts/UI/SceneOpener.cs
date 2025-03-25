using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneOpener : MonoBehaviour
{
    public void OpenSceneByName(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void OpenLastLevel()
    {
        var levels = GameDataManager.Instance.playerGameData._levels;
        LevelData targetLevel = levels[0];
        for (int i = 0; i < levels.Count; i++)
        {
            if (levels[i]._open)
            {
                targetLevel = levels[i];
            }
            else
            {
                break;
            }
        }

        SceneManager.LoadScene(targetLevel._name);

    }
}
