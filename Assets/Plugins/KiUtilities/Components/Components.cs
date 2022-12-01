using KiUtilities.Structures;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace KiUtilities.Components
{
    internal static class KiComponent
    {
        internal static Canvas FindCanvas()
        {
            var canvas = Object.FindObjectOfType<Canvas>();
            if (canvas == null)
            {
                var gameObject = new GameObject("Canvas");
                canvas = gameObject.AddComponent<Canvas>();
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                gameObject.AddComponent<CanvasScaler>();
                gameObject.AddComponent<GraphicRaycaster>();
            }
            return canvas;
        }

        internal static void SetIcon(Object obj, Texture2D icon)
        {
            EditorGUIUtility.SetIconForObject(obj, icon);
        }

        internal static void SetIconForObject(Object obj, string path)
        {
            var icon = Resources.Load<Texture2D>(path);
            EditorGUIUtility.SetIconForObject(obj, icon);
        }

        internal static void SetAllPropertyImage(this Image image, Sprite sprite, Color color, Material material, bool raycastTarget, Vector4 raycastPadding, bool maskable)
        {
            image.sprite = sprite;
            image.color = color;
            image.material = material;
            image.raycastTarget = raycastTarget;
            image.raycastPadding = raycastPadding;
            image.maskable = maskable;
        }

        internal static void SetSprite(this Image image, Sprite sprite)
        {
            image.sprite = sprite;
        }

        internal static void SetTransformScale(this Transform transform, Vector2 size)
        {
            //transform.GetComponent<Anc>
        }
    }
}