using UnityEngine;
using Photon.Chat;
using Photon.Pun;
using ExitGames.Client.Photon;
using TMPro;
using System;

public class PhotonChatManager : MonoBehaviour, IChatClientListener
{   
    [Header ("Chat")]
    [SerializeField] private TMP_InputField inputMessageField = null;
    [SerializeField] private TextMeshProUGUI messageLogs = null;

    private ChatClient chatClient;
    private string username;
    private string chatRoom;
    
    private void Start()
    {
        username = PlayerPrefs.GetString("PlayerName");

        chatClient = new ChatClient(this);
        chatClient.Connect(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat,
        PhotonNetwork.AppVersion, new AuthenticationValues(username));
        
        chatRoom = "chatRoom";
    }

    private void Update() 
    {
        chatClient.Service();
    }

//----------------SEND MESSAGE---------------->
    public void SendMessage() 
    {
        if (!string.IsNullOrEmpty(inputMessageField.text)) 
        {
            chatClient.PublishMessage(chatRoom, inputMessageField.text);
            inputMessageField.text = "";
        }
    }
//----------------IMPLEMENTED INTERFACE---------------->
    public void OnConnected()
    {
        Debug.Log("Connected");
        chatClient.Subscribe(new string[] { chatRoom });
        messageLogs.text = $"{username}: Joined the room.";
    }

    public void OnDisconnected()
    {
        Debug.Log("Connected");
    }


    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        for (int i = 0; i < messages.Length; i++)
        {
            messageLogs.text = messageLogs.text + Environment.NewLine + $"{senders[i]}: {messages[i]}";
        }
    }

    public void OnSubscribed(string[] channels, bool[] results)
    {
        Debug.Log("Subscribed");
        
        for (int i = 0; i < channels.Length; i++) 
        {
            Debug.Log(channels[i]);
        }
    }

    public void OnPrivateMessage(string sender, object message, string channelName)
    {
        
    }

    public void OnUnsubscribed(string[] channels)
    {
        Debug.Log("Unsubscribed");
    }

    public void DebugReturn(DebugLevel level, string message)
    {

    }

    public void OnChatStateChange(ChatState state)
    {

    }
    
    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {

    }

    public void OnUserSubscribed(string channel, string user)
    {
       
    }

    public void OnUserUnsubscribed(string channel, string user)
    {

    }  
}
