using Photon.Pun;
using TMPro;

public class NameTagAssign : MonoBehaviourPun
{
    private TextMeshProUGUI playernameDisplay;

    void Start()
    {
        playernameDisplay = GetComponent<TextMeshProUGUI>();
        playernameDisplay.text = photonView.Owner.NickName;
    }
}
