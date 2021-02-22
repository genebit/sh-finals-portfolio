using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayerNet : MonoBehaviourPun
{
    void Start()
    {
        if (photonView.IsMine)
        {
            // Move Player
        }
    }
}   
