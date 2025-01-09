using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Rank Data")]
public class RankData : ScriptableObject
{
    [System.Serializable]
    public class RankEntry
    {
        public int score;
        public string playerName;

        public RankEntry(int score, string playerName)
        {
            this.score = score;
            this.playerName = playerName;
        }
    }

    public List<RankEntry> rankList = new List<RankEntry>();

    private string GetFilePath()
    {
        return Path.Combine(Application.persistentDataPath, "RankData.json");
    }

    public void SaveToFile()
    {
        string json = JsonUtility.ToJson(this, true); 
        File.WriteAllText(GetFilePath(), json);
        Debug.Log($"Data saved to {GetFilePath()}");
    }

    public void SortRanksDescending()
    {
        rankList.Sort((x, y) => y.score.CompareTo(x.score));
    }
}
