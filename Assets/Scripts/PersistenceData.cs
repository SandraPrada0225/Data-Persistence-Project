using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PersistenceData : MonoBehaviour
{
    public static PersistenceData Instance;
    public string Name;
    public string BestName = "";
    public int BestScore = 0; 

    //se llama tan pronto se crea el objeto
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        //no se destruye cuando cambia de escena 
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string bestName;
        public int bestScore;

    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.bestName = BestName;
        data.bestScore = BestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestName = data.bestName;
            BestScore = data.bestScore;
        }
    }
}
