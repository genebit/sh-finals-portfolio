using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawnOnScene : MonoBehaviourPun
{
    [SerializeField] private GameObject targetPrefab = null;

    void Start()
    {
        PhotonNetwork.Instantiate(targetPrefab.name, Vector3.zero, Quaternion.identity, 0);
    }

}
