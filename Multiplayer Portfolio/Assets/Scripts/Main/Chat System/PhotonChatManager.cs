using UnityEngine;
using Photon.Chat;
using Photon.Pun;
using ExitGames.Client.Photon;
using TMPro;
using System;

public class PhotonChatManager : MonoBehaviour, IChatClientListener
{   
    [SerializeField] private TMP_InputField inputMessageField = null;
    
    [SerializeField] private TextMeshProUGUI messageLogs = null;
    
    private ChatClient chatClient;

    private string room1 = "room1";
    private string room2 = "room2";

    private void Start()
    {
        chatClient = new ChatClient(this);
        chatClient.Connect(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat,
        PhotonNetwork.AppVersion, new AuthenticationValues(PlayerPrefs.GetString("PlayerName")));
        
        chatClient.Subscribe( new string[] { room1, room2 } );
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
            chatClient.PublishMessage(room1, inputMessageField.text);
            inputMessageField.text = "";

            messageLogs.text = messageLogs.text + Environment.NewLine + inputMessageField.text;
        }
    }
//----------------IMPLEMENTED INTERFACE---------------->
    public void OnConnected()
    {
        Debug.Log("Connected");
    }

    public void OnDisconnected()
    {
        Debug.Log("Connected");
    }

    public void DebugReturn(DebugLevel level, string message)
    {
    }

    public void OnChatStateChange(ChatState state)
    {

    }

    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {

    }

    public void OnPrivateMessage(string sender, object message, string channelName)
    {

    }

    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {

    }

    public void OnSubscribed(string[] channels, bool[] results)
    {
        Debug.Log(channels);
    }

    public void OnUnsubscribed(string[] channels)
    {

    }

    public void OnUserSubscribed(string channel, string user)
    {
        Debug.Log(channel);
    }

    public void OnUserUnsubscribed(string channel, string user)
    {

    }  
}
