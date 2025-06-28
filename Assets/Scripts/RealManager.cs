using UnityEngine;
using System.IO;

public class RealManager : MonoBehaviour
{
    public static RealManager Instance;
    public int BestScore;
    public string Name;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        Load();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateBestScore(int newScore)
    {
        if (newScore <= BestScore) return;

        BestScore = newScore;
    }

    [System.Serializable]
    class SaveData
    {
        public int BestScore;
        public string Name;
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.Name = Name;
        data.BestScore = BestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            
            BestScore = data.BestScore; 
            Name = data.Name;
        }
        
    }
}
