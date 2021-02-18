using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

namespace Scripts.Lobby
{
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
        private const int MAX_PLAYERS_IN_ROOM = 2;

        private void Awake() => PhotonNetwork.AutomaticallySyncScene = true;

        private void Start()
        {
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = GAME_VERSION;
        }

        private void Update() 
        {
            roomCountText.text = PhotonNetwork.CountOfRooms.ToString();
            if (PhotonNetwork.CountOfRooms > 0)
            {
                roomCountText.color = greenR;
            }
            else 
            {
                roomCountText.color = redR;
            }
        }
        //----------BUTTONS-----------
        public void FindRooms()
        {
            statusText.text = "Finding Players...";
            PhotonNetwork.JoinRandomRoom();
        }

        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }
        
    //----------CONNECTION LOBBY-----------
        public override void OnConnectedToMaster()
        {
            connMasterStatText.text = "CONNECTED";
            connMasterStatText.color = greenM;
        }

        public override void OnCreatedRoom()
        {
            statusText.text = "CREATED ROOM";
        }

        public override void OnJoinedRoom()
        {
            currentPlayerInRoom = PhotonNetwork.CurrentRoom.PlayerCount;

            if (currentPlayerInRoom == MAX_PLAYERS_IN_ROOM)
            {
                statusText.text = "READY TO BEGIN";
            } 
            else
            {
                statusText.text = "WAITING FOR USER";
            }
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        { 
            currentPlayerInRoom = PhotonNetwork.CurrentRoom.PlayerCount;

            if (currentPlayerInRoom == MAX_PLAYERS_IN_ROOM)
            {
                statusText.text = "READY TO BEGIN";
            } 
            else
            {
                statusText.text = "WAITING FOR USER";
            }
        }

        public override void OnLeftRoom()
        {
            statusText.text = "YOU LEFT";

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
            PhotonNetwork.CreateRoom(null, roomOptions);
        }
  
        public override void OnDisconnected(DisconnectCause cause)
        {
            statusText.text = "DISCONNECTED";
            statusText.color = redS;

            connMasterStatText.text = "DISCONNECTED";
            statusText.color = redM;
        }
        
    }
}

