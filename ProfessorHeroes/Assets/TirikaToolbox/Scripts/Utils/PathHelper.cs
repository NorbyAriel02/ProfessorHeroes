using System.IO;
using UnityEngine;

public class PathHelper {
    public static string GetPlatformPath(string file)
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            file = Path.Combine(Application.persistentDataPath, file);
        }
        else
        {
            file = Path.Combine(Application.streamingAssetsPath, file);
        }

        return file;
    }
}
