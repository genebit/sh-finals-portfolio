using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerAvatarAssign : MonoBehaviour
{   
    [Header ("Host")]
    [SerializeField] private Image charImgHost;
    
    [Header ("Client")]
    [SerializeField] private Image charImgClient;
    private string setCharacter;

    void Start()
    {
        setCharacter = CharPickerAssign.character;

    }

}
