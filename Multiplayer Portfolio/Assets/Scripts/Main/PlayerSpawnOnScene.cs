using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerSpawnOnScene : MonoBehaviourPun
{
    public GameObject playerPrefab;
    public Transform[] spawnPoints;

    private void Start() 
    {
        SpawnUsers();
    }
    private void SpawnUsers() 
    {
        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            Debug.Log(PhotonNetwork.PlayerList[i].NickName);
        }
        
        if (photonView.Owner.NickName.Equals(PhotonNetwork.PlayerList[0].NickName))
        {
            PhotonNetwork.Instantiate(playerPrefab.name, 
                                    spawnPoints[0].position,
                                    spawnPoints[0].rotation, 0);
        }
        else if (photonView.Owner.NickName.Equals(PhotonNetwork.PlayerList[1].NickName))
        {
            PhotonNetwork.Instantiate(playerPrefab.name, 
                                    spawnPoints[1].position,
                                    spawnPoints[1].rotation, 0);
        }

    }
}
