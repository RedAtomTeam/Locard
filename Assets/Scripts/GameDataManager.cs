using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance = null; 
    public List<string> _levels = new List<string>();
    public GameData playerGameData;


    private void Awake()
    {
        Initialized();
    }


    public void Initialized()
    {
        string fileName = "GameData";
        if (Instance == null)
        {
            Instance = this; 
            DontDestroyOnLoad(gameObject); 
        }

        if (File.Exists(Application.persistentDataPath + "\\" + "saves" + "\\" + fileName))
        {
            LoadGameData(fileName);
        }
        else 
        {
            playerGameData = new GameData(_levels);

            SaveGameData(fileName);
        }
    }


    public void SaveGameData(string fileName)
    {
        string saveFilePath = Application.persistentDataPath + "\\" + "saves" + "\\" + fileName;
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(saveFilePath, FileMode.Create))
        {
            formatter.Serialize(stream, playerGameData);
        }
    }


    public void LoadGameData(string fileName)
    {
        string saveFilePath = Application.persistentDataPath + "\\" + "saves" + "\\" + fileName;
        if (File.Exists(saveFilePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(saveFilePath, FileMode.Open))
            {
                playerGameData = formatter.Deserialize(stream) as GameData;
            }
        }
    }

}


[System.Serializable]
public class LevelData
{
    public int _id;
    public string _name;
    public bool _open;

    public LevelData(int id, string name, bool open)
    {
        _id = id;
        _name = name;
        _open = open;
    }
}

[System.Serializable]
public class GameData
{
    public List<LevelData> _levels;

    public GameData(List<string> levels)
    {
        _levels = new List<LevelData>(levels.Count);

        for (int i = 0; i < levels.Count; i++) 
        {
            if (i == 0)
            {
                _levels.Add(new LevelData(i, levels[i], true));
            }
            else 
            {
                _levels.Add(new LevelData(i, levels[i], false));
            }
        }

    }
}
