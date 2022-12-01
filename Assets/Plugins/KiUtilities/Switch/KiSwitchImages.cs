using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KiUtilities.Switch.Images
{
    public static class KiSwitchImages
    {
        public static void SwitchImageByIndex(this List<Image> images, int index)
        {
            for (int i = 0; i < images.Count; i++)
                if (i == index) images[i].SwitchImage(1);
                else images[i].SwitchImage();
        }

        public static void SwitchImageAll(this List<Image> images, float value = 0f)
        {
            foreach (var image in images)
                image.SwitchImage(value);
        }

        public static void SwitchImage(this Image image, float value = 0)
        {
            image.color = new Vector4(image.color.r, image.color.g, image.color.b, value);
        }
    }
}