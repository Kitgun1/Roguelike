using KiUtilities.Enums;
using UnityEngine;
using System;
using UnityEngine.UI;

namespace KiUtilities.Structures
{
    public static class StructuresExtension
    {
        #region GetRange

        /// <param name="min">float.minimum</param>
        /// <param name="max">float.maximum</param>
        /// <returns>Returns a KiRangeFloat within [min, max].</returns>
        public static KiRangeFloat GetRange(this float min, float max)
        {
            return new KiRangeFloat() { min = min, max = max };
        }
        /// <param name="min">int.minimum</param>
        /// <param name="max">int.maximum</param>
        /// <returns>Returns a KiRangeInt within [min, max].</returns>
        public static KiRangeInt GetRange(this int min, int max)
        {
            return new KiRangeInt() { min = min, max = max };
        }

        #endregion
    }

    #region RangeStructures
    /// <summary>
    /// A structure containing information about [int min, int max]
    /// </summary>
    [Serializable]
    public struct KiRangeInt
    {
        public int min;
        public int max;
    }

    /// <summary>
    /// A structure containing information about [float min, float max]
    /// </summary>
    [Serializable]
    public struct KiRangeFloat
    {
        public float min;
        public float max;

    }
    #endregion

    #region UI

    [Serializable]
    public struct DropDownData
    {
        public Button Button;
        public Button Panel;
        [Min(0)] public float TimeAutoClose;
        [Min(0)] public float TimeAutoOpen;
        public bool AwakeOnStart;
        public DropDownMode StartMode;
    }

    #endregion
}