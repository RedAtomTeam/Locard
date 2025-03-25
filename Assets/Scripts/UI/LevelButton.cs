using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public SceneOpener opener;
    public int id;
    public string levelName;


    private void Awake()
    {
        List<LevelData> levels = GameDataManager.Instance.playerGameData._levels;

        for (int i = 0; i < levels.Count; i++) 
        {
            if (levels[i]._name == this.levelName && levels[i]._id == this.id)
            {
                if (levels[i]._open)
                {
                    SetOpen();
                }
                else
                {
                    SetClose();
                }
            }
        }

    }


    public void SetClose()
    {
        this.gameObject.GetComponent<Image>().color = new Color (0, 0, 0, 0.8f);
        this.gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
    }


    public void SetOpen()
    {
        this.gameObject.GetComponent<Image>().color = new Color (1, 1, 1, 1f);
        this.gameObject.GetComponent<Button>().onClick.AddListener(delegate { this.opener.OpenSceneByName(this.levelName); });
    }

}
