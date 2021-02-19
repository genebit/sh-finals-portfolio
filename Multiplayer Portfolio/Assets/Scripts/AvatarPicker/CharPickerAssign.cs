using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharPickerAssign : MonoBehaviour
{
    public Transform picker;
    public static string avatarKey;

    public void chooseMale()
    {
        picker.position = new Vector2(-5.6f, 0);
        PlayerPrefs.SetString(avatarKey, "Male");
        PlayerPrefs.GetString(avatarKey);
    }

    public void chooseFemale()
    {
        picker.position = new Vector2(5.5f, 0);
        PlayerPrefs.SetString(avatarKey, "Female");
        PlayerPrefs.GetString(avatarKey);
    }
}
