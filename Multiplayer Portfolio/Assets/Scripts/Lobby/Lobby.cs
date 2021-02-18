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
        
        public static bool isConnected;
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

        //----------BUTTONS-----------
        public void FindRooms()
        {
            statusText.text = "Finding Players...";
            PhotonNetwork.JoinRandomRoom();
        }

        public void CreateNewRoom()
        {
            roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = MAX_PLAYERS_IN_ROOM;
            
            PhotonNetwork.CreateRoom(null, roomOptions);
        }

        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }
        

    //----------CONNECTION LOBBY-----------
        public override void OnConnectedToMaster()
        {
            statusText.text = "Connected to Master.";
            isConnected = true;

        }

        public override void OnCreatedRoom()
        {
            statusText.text = "Successfully created a new Room.";
        }

        public override void OnJoinedRoom()
        {
            statusText.text = "Successfully joined a room.";

            currentPlayerInRoom = PhotonNetwork.CurrentRoom.PlayerCount;

            if (currentPlayerInRoom == MAX_PLAYERS_IN_ROOM)
            {
                statusText.text = "Room is now full! Match is ready to begin!";
            } 
            else
            {
                statusText.text = "Waiting for other players...";
            }
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {   
            statusText.text = $"New player: {newPlayer.NickName} detected!";

            currentPlayerInRoom = PhotonNetwork.CurrentRoom.PlayerCount;

            if (currentPlayerInRoom == MAX_PLAYERS_IN_ROOM)
            {
                statusText.text = "Room is now full! Match is ready to begin!";
            } 
            else
            {
                statusText.text = "Waiting for other players...";
            }
        }

        public override void OnPlayerLeftRoom(Player player)
        {
            statusText.text = $"Player: {player.NickName} left the Room.";

            currentPlayerInRoom = PhotonNetwork.CurrentRoom.PlayerCount;
        }

        public override void OnLeftRoom()
        {
            statusText.text = "You left the room.";

            currentPlayerInRoom = PhotonNetwork.CountOfRooms;
        }

        //-------DISCONNECT-------
        public override void OnCreateRoomFailed(short returnCode, string cause)
        {
            statusText.text = $"Create room failed! Try again! cause: {cause}";
        }

        public override void OnJoinRandomFailed(short returnCode, string cause)
        {
            statusText.text = $"No players were found! error: {cause}";
        }
  
        public override void OnDisconnected(DisconnectCause cause)
        {
            statusText.text = $"Player Disconnected cause: {cause}";
        }
        
    }
}

