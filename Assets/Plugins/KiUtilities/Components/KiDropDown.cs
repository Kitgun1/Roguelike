using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace KiUtilities.Components
{
    public class KiDropDown
    {
        [MenuItem("GameObject/UI/KiDropdown", false, -10)]
        private static void DropDown()
        {
            var kiDropDown = new GameObject("KiDropDown");

            kiDropDown.transform.parent = KiComponent.FindCanvas().transform;
            kiDropDown.AddComponent<CanvasRenderer>();
            //kiDropDown.transform.SetTransformScale(new Vector2(500, 100));

            var image = kiDropDown.AddComponent<Image>();
            var sprite = Resources.Load<Sprite>("info");


            if (sprite == null) throw new System.NullReferenceException();
            image.sprite = sprite;
        }
    }
}