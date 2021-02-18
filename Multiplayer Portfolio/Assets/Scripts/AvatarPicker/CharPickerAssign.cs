using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.AvatarPicker
{     
    public class CharPickerAssign : MonoBehaviour
    {
        public RectTransform picker;
        public Vector2 position;

        public void chooseMale()
        {
            picker.position += position;
            // picker.GetComponent<RectTransform>().position = new Vector2(-405, 192);
        }

        public void chooseFemale()
        {
            // picker.GetComponent<RectTransform>().position = new Vector2(400, 192);
        }
    }
}
