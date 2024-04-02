using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public GameConfig gameConfig;
    public GameObject recordPrefab;
    public Transform content;
    private GoogleSheetsAPIForUnity Sheet;
    void Start()
    {
        GameManager.Instance.OnLoadScene?.Invoke();
        Sheet = new GoogleSheetsAPIForUnity(gameConfig);
        LoadRecords();
    }
    public void LoadRecords()
    {
        RowList list = Sheet.ReadData("A2:C11");
        int index = 1;
        foreach (Row row in list.rows)
        {
            SetText(Instantiate(recordPrefab, content), row, index++);
        }
    }

    private void SetText(GameObject record, Row row, int index)
    {
        TMP_Text[] txts = record.GetComponentsInChildren<TMP_Text>();
        foreach (TMP_Text txt in txts)
        {
            if(txt.name.Equals("txtLevel"))
            {
                txt.text = index.ToString();
            }
            
            if (txt.name.Equals("txtName"))
            {
                txt.text = row.cellData[1];
            }
            
            if (txt.name.Equals("txtTime"))
            {
                txt.text = row.cellData[2];
            }
        }
    }
    public void Back()
    {
        ChangeOfScene.Instance.Menu();
    }
}
