using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class SavePlayerName : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI statusText = null;
    [Header ("Color Indicator")]
    [SerializeField] private Color green;
    [SerializeField] private Color red;
    
    [Space]
    [SerializeField] private TMP_InputField textField = null;
    
    public static string playerName;
    public static bool validName = false;
    

    private const string playerPrefsNameKey = "PlayerName";

    private void Start() => textField.text = PlayerPrefs.GetString(playerPrefsNameKey);
    
    public void SaveName()
    {
        playerName = textField.text;

        if (!string.IsNullOrEmpty(playerName)) 
        {   
            validName = true;
            statusText.color = green; // GREEN
            statusText.text = "VALID";
            PlayerPrefs.SetString(playerPrefsNameKey, playerName);
        
            PhotonNetwork.NickName = playerName;
            StartCoroutine(LoadLobby());
        }
        else 
        {
            statusText.color = red; // RED
            statusText.text = "INVALID";
        }
    }
    private IEnumerator LoadLobby()
    {
        int waitTime = 3;
        yield return new WaitForSeconds(waitTime);
        // Load to Lobby Scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
