using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharPickerAssign : MonoBehaviour
{
    public Transform picker;
    public static string character;

    private void Start() 
    {
        if (PlayerPrefs.GetString(character).Equals("Male"))
        {
            picker.position = new Vector2(-5.6f, 0.5f);
            PlayerPrefs.SetString(character, "Male");
        }
        if (PlayerPrefs.GetString(character).Equals("Female"))
        {
            picker.position = new Vector2(5.5f, 0.5f);
            PlayerPrefs.SetString(character, "Male");
        }
    }
    public void chooseMale()
    {
        picker.position = new Vector2(-5.6f, 0.5f);
        PlayerPrefs.SetString(character, "Male");
    }

    public void chooseFemale()
    {
        picker.position = new Vector2(5.5f, 0.5f);
        PlayerPrefs.SetString(character, "Female");
    }
}
