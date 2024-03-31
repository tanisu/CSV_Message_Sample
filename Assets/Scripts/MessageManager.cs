using System.Collections.Generic;
using UnityEngine;

public class MessageManager{
    Dictionary<string, string> messages = new Dictionary<string, string>();
    
    public void LoadMessage(string fileName)
    {
        TextAsset textAsset = Resources.Load<TextAsset>(fileName);
        if(textAsset == null)
        {
            Debug.LogError("Gaild to load the file");
            return;
        }

        string[] lines = textAsset.text.Split('\n');
        bool isHeaderLine = true;
        foreach(string line in lines)
        {
            if (isHeaderLine)
            {
                isHeaderLine = false;
                continue;
            }

            if (!string.IsNullOrWhiteSpace(line))
            {
                string[] parts = line.Split(',');
                if(parts.Length == 2)
                {
                    messages[parts[0].Trim()] = parts[1].Trim();
                }
            }
        }
    }

    public string GetMessage(string key)
    {
        if (messages.ContainsKey(key))
        {
            return messages[key];
        }
        Debug.LogWarning($"Message key not found:{key}");
        return string.Empty;
    }
}
