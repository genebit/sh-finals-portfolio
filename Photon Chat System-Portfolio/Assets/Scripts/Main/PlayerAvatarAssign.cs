using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAvatarAssign : MonoBehaviour
{   
    [Header ("Users")]
    [SerializeField] private Image imgHost = null;
    public static bool host;

    [SerializeField] private Image imgClient = null;
    
    [Header ("Avatar Image")]
    [SerializeField] private Sprite male = null;
    [SerializeField] private Sprite female = null;
    
    private void Start()
    {
        if (host)
        {
            Debug.Log("You are the host");
            var character = PlayerPrefs.GetString(CharPickerAssign.character);
            
            switch (character)
            {
                case "Male":
                    imgHost.sprite = male;
                    break;
                
                case "Female":
                    imgHost.sprite = female;
                    break;
            }
        }
        else
        {
            Debug.Log("You are the client");
            var character = PlayerPrefs.GetString(CharPickerAssign.character);
            
            switch (character)
            {
                case "Male":
                    imgClient.sprite = male;
                    break;
                
                case "Female":
                    imgClient.sprite = female;
                    break;
            }
        }
    }

}
