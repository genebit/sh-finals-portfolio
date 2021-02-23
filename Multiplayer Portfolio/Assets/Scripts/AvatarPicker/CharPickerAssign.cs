using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharPickerAssign : MonoBehaviour
{
    public Transform picker;
    public static string character;

    private void Start() 
    {
        character = "Male";
    }
    public void chooseMale()
    {
        picker.position = new Vector2(-5.6f, 0.5f);
        character = "Male";
    }

    public void chooseFemale()
    {
        picker.position = new Vector2(5.5f, 0.5f);
        character = "Female";

    }
}
