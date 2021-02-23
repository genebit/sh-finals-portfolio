using UnityEngine;
using Photon.Pun;
using TMPro;

namespace Scripts.PlayerName
{
    public class NameTagAssign : MonoBehaviourPun
    {
        private TextMeshProUGUI playernameDisplay;

        private void Start()
        {
            playernameDisplay = GetComponent<TextMeshProUGUI>();
            playernameDisplay.text = photonView.Owner.NickName;
            
        }
    }
}
