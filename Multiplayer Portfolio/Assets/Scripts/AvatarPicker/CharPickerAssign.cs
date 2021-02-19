using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.AvatarPicker
{     
    public class CharPickerAssign : MonoBehaviour
    {
        public Transform picker;

        public void chooseMale()
        {
            picker.position = new Vector2(-5.6f, 0);
        }

        public void chooseFemale()
        {
            picker.position = new Vector2(5.5f, 0);
        }
    }
}
