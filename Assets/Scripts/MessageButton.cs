using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageButton : MonoBehaviour
{
    public string key;
    public Text messageText;
    Button messageButton;
    MessageManager message;

    void Start()
    {
        messageButton = GetComponent<Button>();
        message = new MessageManager();
        message.LoadMessage("sample");
        messageButton.onClick.AddListener(()=> { messageText.text = message.GetMessage(key); });
        
    }
}
