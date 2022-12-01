using System.Collections.Generic;
using UnityEngine;

namespace KiUtilities.Switch.GameObjects
{
    public static class KiSwitchGameObjects
    {
        public static void SwitchGameObjectByIndex(this List<GameObject> gameObjects, int index)
        {
            for (int i = 0; i < gameObjects.Count; i++)
                gameObjects[i].SwitchGameObject(i == index);
        }

        public static void SwitchGameObjectAll(this List<GameObject> gameObjects, bool isActive = false)
        {
            foreach (var gameObject in gameObjects)
                gameObject.SwitchGameObject(isActive);
        }

        public static void SwitchGameObject(this GameObject gameObject, bool isActive = false)
        {
            gameObject.SetActive(isActive);
        }
    }
}
