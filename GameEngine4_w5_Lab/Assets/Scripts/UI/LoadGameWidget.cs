using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LoadGameWidget : MenuWidget
{
    private GameDataList gameData;
    // Start is called before the first frame update
    private const string SaveFileKey = "FileSaveData";
    [SerializeField] private bool Debug; 
    void Start()
    {
        if (Debug) SaveDebugData();
        LoadGameData();
    }
    private void SaveDebugData()
    {
        GameDataList dataList = new GameDataList();
        dataList.SaveFileNames.AddRange(new List<string> { "Save1", "Save2", "Save3" });
        PlayerPrefs.SetString(SaveFileKey, JsonUtility.ToJson(dataList));
    }
    private void LoadGameData()
    {
        if (!PlayerPrefs.HasKey(SaveFileKey)) return;

        string jsonString = PlayerPrefs.GetString(SaveFileKey);
        gameData = JsonUtility.FromJson<GameDataList>(jsonString);

        if (gameData.SaveFileNames.Count <= 0) return;

        UnityEngine.Debug.Log(gameData.SaveFileNames);
    }
}

[SerializeField]
class GameDataList
{
    public List<string> SaveFileNames = new List<string>();
}