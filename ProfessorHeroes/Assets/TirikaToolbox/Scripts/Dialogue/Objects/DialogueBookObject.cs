using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using UnityEngine;

[CreateAssetMenu(fileName = "New Book", menuName = "Dialogue System/Book")]
public class DialogueBookObject : ScriptableObject
{
    public string path;
    public DialogueBook book;

    [ContextMenu("Save")]
    public void Save()
    {
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(string.Concat(Application.persistentDataPath, path), FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, book);
        stream.Close();
    }
    [ContextMenu("Load")]
    public void Load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, path)))
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(string.Concat(Application.persistentDataPath, path), FileMode.Open, FileAccess.Read);
            book = (DialogueBook)formatter.Deserialize(stream);
            stream.Close();
        }
    }
}
