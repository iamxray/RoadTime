using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public List<float> hightScoreTable = new List<float>();
    




    private void Awake()
    {
        
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }

    public void CheckHighScore(float Score)
    {
        for (int i = 0; i < hightScoreTable.Count; i++)
        {
            if (Score > hightScoreTable[i])
            {
                hightScoreTable[i] = Score;
                SaveHighScore();
                break;
            }
        }
    }


    [System.Serializable]
    class SaveData
    {
        public List<float> hightScoreTable;

    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.hightScoreTable = hightScoreTable;


        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            hightScoreTable = data.hightScoreTable;

        }
    }
}
