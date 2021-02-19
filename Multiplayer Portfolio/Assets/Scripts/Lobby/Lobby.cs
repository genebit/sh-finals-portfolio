using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class Lobby : MonoBehaviourPunCallbacks
{     
    [Header ("Connection to Master")]
    [SerializeField] private TextMeshProUGUI connMasterStatText = null;
    [SerializeField] private Color greenM;
    [SerializeField] private Color redM;

    [Header ("Status text")]
    [SerializeField] private TextMeshProUGUI statusText = null;
    [SerializeField] private Color greenS;
    [SerializeField] private Color redS;

    [Header ("Room Counter")]
    [SerializeField] private TextMeshProUGUI roomCountText = null;
    [SerializeField] private Color greenR;
    [SerializeField] private Color redR;
    
    public static int currentPlayerInRoom = 0;

    private RoomOptions roomOptions;
    private const string GAME_VERSION = "0.1";
    public static int MAX_PLAYERS = 2;

    private void Awake() => PhotonNetwork.AutomaticallySyncScene = true;

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.GameVersion = GAME_VERSION;
    }

    private void Update() 
    {
        if (PhotonNetwork.CountOfRooms > 0)
        {
            roomCountText.text = PhotonNetwork.CountOfRooms.ToString();
            roomCountText.color = greenR;
        }
        else 
        {
            roomCountText.text = PhotonNetwork.CountOfRooms.ToString();
            roomCountText.color = redR;
        }
    }
    //----------BUTTONS-----------
    public void FindRooms()
    {
        statusText.text = "FINDING";
        statusText.color = redS;
        
        PhotonNetwork.JoinRandomRoom();
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect();
    }
    
//----------CONNECTION LOBBY-----------
    public override void OnConnectedToMaster()
    {
        connMasterStatText.text = "CONNECTED";
        connMasterStatText.color = greenM;
        
        statusText.text = "CONNECTED";
        statusText.color = greenS;
    }

    public override void OnCreatedRoom()
    {
        statusText.text = "CREATED ROOM";
        statusText.color = greenS;
    }

    public override void OnJoinedRoom()
    {
        currentPlayerInRoom = PhotonNetwork.CurrentRoom.PlayerCount;
        statusText.text = "JOINED ROOM";
        statusText.color = greenS;

        if (currentPlayerInRoom == MAX_PLAYERS)
        {
            statusText.text = "STARTING";
            statusText.color = greenS;

            StartCoroutine(LoadMainScene());
        } 
        else
        {
            statusText.text = "WAITING";
            statusText.color = greenS;
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    { 
        currentPlayerInRoom = PhotonNetwork.CurrentRoom.PlayerCount;

        if (currentPlayerInRoom == MAX_PLAYERS)
        {
            statusText.text = "STARTING";
            statusText.color = greenS;

            StartCoroutine(LoadMainScene());
        } 
        else
        {
            statusText.text = "WAITING";
            statusText.color = greenS;
        }
    }

    public override void OnLeftRoom()
    {
        statusText.text = "YOU LEFT";
        statusText.color = redS;

        currentPlayerInRoom = PhotonNetwork.CountOfRooms;
    }

    //-------DISCONNECT-------
    public override void OnCreateRoomFailed(short returnCode, string cause)
    {
        statusText.text = "ROOM CREATE FAILED";
        statusText.color = redS;
    }

    public override void OnJoinRandomFailed(short returnCode, string cause)
    {
        statusText.text = "NO ROOMS";
        statusText.color = redS;
        PhotonNetwork.CreateRoom("MyRoom", roomOptions);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        statusText.text = "DISCONNECTED";
        statusText.color = redS;

        connMasterStatText.text = "DISCONNECTED";
        statusText.color = redM;

        SceneManager.LoadScene("Login");
    }
    
    private IEnumerator LoadMainScene()
    {
        float waitTime = 2f;
        yield return new WaitForSeconds(waitTime);
        // Go to Main Scene (Both Clients)
        PhotonNetwork.LoadLevel(SceneManager.GetActiveScene().buildIndex+1);
    }
}


