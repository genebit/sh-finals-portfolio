using UnityEngine;
using Photon.Pun;
using TMPro;

public class SavePlayerName : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI statusText = null;
    [SerializeField] private TMP_InputField inputfield = null;
    
    public static string playerName;
    public static bool validName = false;
    
    private const string playerPrefsNameKey = "PlayerName";

    private void Start() 
    {
        inputfield.text = PlayerPrefs.GetString(playerPrefsNameKey);
    }
    public void SaveName()
    {
        playerName = inputfield.text;

        if (!string.IsNullOrEmpty(playerName)) 
        {   
            validName = true;
            statusText.text = "Player name saved.";
            PlayerPrefs.SetString(playerPrefsNameKey, playerName);
        
            PhotonNetwork.NickName = playerName;
        }
        else 
        {
            statusText.text = "Invalid Name. Please enter a new one.";
        }
    }
}
