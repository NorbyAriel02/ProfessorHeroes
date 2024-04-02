using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Sheets.v4;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

[Serializable]
public class Row
{
    public List<string> cellData = new List<string>();
}
[Serializable]
public class RowList
{
    public List<Row> rows = new List<Row>();
}

public class Record
{
    public string usename;
    public float timer;
    public string level;
}
public class GoogleSheetsAPIForUnity 
{
    public GoogleSheetsAPIForUnity(GameConfig gameConfig)
    {
        spreadSheetID = gameConfig.spreadSheetID;
        sheetID = gameConfig.sheetID;
        serviceAccountEmail = gameConfig.serviceAccountEmail;
        certificateName = gameConfig.certificateName;
        Login();
    }
    private string spreadSheetID;
    private string sheetID;
    private string serviceAccountEmail;
    private string certificateName;
    private string certificatePath;

    private static SheetsService googleSheetsService;
        
    
    private string deleteDataInRange;
    void Login()
    {
        certificatePath = Application.dataPath + "/StreamingAssets/" + certificateName;  //Comment to use on Android

        var certificate = new X509Certificate2(certificatePath, "notasecret", X509KeyStorageFlags.Exportable);

        ServiceAccountCredential credential = new ServiceAccountCredential(
            new ServiceAccountCredential.Initializer(serviceAccountEmail)
            {
                Scopes = new[] { SheetsService.Scope.Spreadsheets }
            }.FromCertificate(certificate));

        googleSheetsService = new SheetsService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = "GoogleSheets API for Unity"
        });
    }
    public RowList ReadData(string getDataInRange)
    {
        RowList DataFromGoogleSheets = new RowList();
        string range = sheetID + "!" + getDataInRange;

        var request = googleSheetsService.Spreadsheets.Values.Get(spreadSheetID, range);
        var reponse = request.Execute();
        var values = reponse.Values;
        if (values != null && values.Count > 0)
        {
            foreach (var row in values)
            {
                Row newRow = new Row();
                DataFromGoogleSheets.rows.Add(newRow);
                foreach (var value in row)
                {
                    newRow.cellData.Add(value.ToString());
                }

            }
        }
        return DataFromGoogleSheets;
    }    

    public List<Record> ReadDataRecords(string getDataInRange)
    {
        RowList rowList = ReadData(getDataInRange);
        List<Record> records = new List<Record>();
        foreach (var row in rowList.rows)
        {
            Record record = new Record();
            record.level = row.cellData[0];
            record.usename = row.cellData[1];
            float.TryParse(row.cellData[2], out record.timer);
            records.Add(record);
        }
        return records;
    }
    //public void WriteData()
    //{
    //    string range = sheetID + "!" + writeDataInRange;
    //    var valueRange = new ValueRange();
    //    var cellData = new List<object>();
    //    var arrows = new List<IList<object>>();
    //    foreach (var row in WriteDataFromUnity.rows)
    //    {
    //        cellData = new List<object>();
    //        foreach (var data in row.cellData)
    //        {
    //            cellData.Add(data);
    //        }

    //        arrows.Add(cellData);
    //    }

    //    valueRange.Values = arrows;

    //    var request = googleSheetsService.Spreadsheets.Values.Append(valueRange, spreadSheetID, range);
    //    request.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
    //    var reponse = request.Execute();
    //}    
    //public void DeleteData()
    //{
    //    var range = sheetID + "!" + deleteDataInRange;

    //    var deleteData = googleSheetsService.Spreadsheets.Values.Clear(new ClearValuesRequest(), spreadSheetID, range);
    //    deleteData.Execute();
    //}    
    public void UpdateData(string writeDataInRange, RowList WriteDataFromUnity)
    {
        string range = sheetID + "!" + writeDataInRange;
        var valueRange = new ValueRange();
        var cellData = new List<object>();
        var arrows = new List<IList<object>>();
        foreach (var row in WriteDataFromUnity.rows)
        {
            cellData = new List<object>();
            foreach (var data in row.cellData)
            {
                cellData.Add(data);
            }

            arrows.Add(cellData);
        }

        valueRange.Values = arrows;

        var updateRequest = googleSheetsService.Spreadsheets.Values.Update(valueRange, spreadSheetID, range);
        updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
        var appendReponse = updateRequest.Execute();
    }
    public void UpdateDataRecords(string writeDataInRange, List<Record> WriteDataFromUnity)
    {
        RowList rowList = new RowList();
        foreach (var record in WriteDataFromUnity)
        {
            Row row = new Row();
            row.cellData.Add(record.level);
            row.cellData.Add(record.usename);
            row.cellData.Add(record.timer.ToString("0.000"));
            rowList.rows.Add(row);
        }
        UpdateData(writeDataInRange, rowList);
    }
}
