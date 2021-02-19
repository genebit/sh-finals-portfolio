using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class PlayerOnLeave : MonoBehaviourPunCallbacks
{
    // Back Button
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect();
    }

    private void Update() 
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount != Lobby.MAX_PLAYERS) 
            PhotonNetwork.Disconnect();   
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        // Go to Login Scene
        SceneManager.LoadScene("Login");
    }
}   

