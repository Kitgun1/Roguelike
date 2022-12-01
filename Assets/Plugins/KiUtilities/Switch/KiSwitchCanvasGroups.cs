using System.Collections.Generic;
using UnityEngine;

namespace KiUtilities.Switch.CanvasGroups
{
    public static class KiSwitchCanvasGroups
    {
        public static void SwitchCanvasGroupByIndex(this List<CanvasGroup> canvasGroups, int index)
        {
            for (int i = 0; i < canvasGroups.Count; i++)
                canvasGroups[i].SwitchCanvasGroup(i == index);
        }

        public static void SwitchCanvasGroupAll(this List<CanvasGroup> canvasGroups, bool value = false)
        {
            foreach (var image in canvasGroups)
                image.SwitchCanvasGroup(value);
        }

        public static void SwitchCanvasGroup(this CanvasGroup canvasGroup, bool isActive = false)
        {
            if (isActive) canvasGroup.alpha = 1;
            else canvasGroup.alpha = 0;
            canvasGroup.interactable = isActive;
            canvasGroup.blocksRaycasts = isActive;
        }
    }
}