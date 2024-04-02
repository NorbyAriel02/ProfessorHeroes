using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FirstThreeRecords : MonoBehaviour
{
    public List<TMP_Text> nameTexts;
    public List<TMP_Text> timeTexts;
    public GameConfig gameConfig;
    private GoogleSheetsAPIForUnity Sheet;
    void Start()
    {
        Sheet = new GoogleSheetsAPIForUnity(gameConfig);
        LoadRecords();
    }

    void LoadRecords()
    {
        RowList list = Sheet.ReadData(gameConfig.readRange);
        for (int i = 0; i < nameTexts.Count; i++)
        {
            nameTexts[i].text = list.rows[i].cellData[1];
            timeTexts[i].text = list.rows[i].cellData[2];
        }
    }
}
