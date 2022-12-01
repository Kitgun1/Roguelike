using System.Collections.Generic;

namespace KiUtilities.Filters
{
    public static class KiFilterExtension
    {
        #region CheckFloatValue

        /// <summary>
        /// Checks the value within array filters
        /// </summary>
        /// <param name="value">float value</param>
        /// <param name="filters">float[] filters</param>
        /// <returns>true if the value does not match the filters, else false</returns>
        public static bool CheckValue(this float value, float[] filters)
        {
            foreach (var filter in filters)
            {
                if (filter == value) return false;
            }
            return true;
        }

        /// <summary>
        /// Checks the value within list filters
        /// </summary>
        /// <param name="value">float value</param>
        /// <param name="filters">List filters</param>
        /// <returns>true if the value does not match the filters, else false</returns>
        public static bool CheckValue(this float value, List<float> filters)
        {
            return CheckValue(value, filters.ToArray());
        }

        /// <summary>
        /// Checks the value within filter
        /// </summary>
        /// <param name="value">float value</param>
        /// <param name="filter">float filter</param>
        /// <returns>true if the value does not match the filter, else false</returns>
        public static bool CheckValue(this float value, float filter)
        {
            return !(filter == value);
        }
        #endregion

        #region CheckIntValue

        /// <summary>
        /// Checks the value within array filters
        /// </summary>
        /// <param name="value">int value</param>
        /// <param name="filters">int[] value</param>
        /// <returns>true if the value does not match the filters, else false</returns>
        public static bool CheckValue(this int value, int[] filters)
        {
            foreach (var filter in filters)
            {
                if (filter == value) return false;
            }
            return true;
        }

        /// <summary>
        /// Checks the value within List filters
        /// </summary>
        /// <param name="value">int value</param>
        /// <param name="filters">List filters</param>
        /// <returns>true if the value does not match the filters, else false</returns>
        public static bool CheckValue(this int value, List<int> filters)
        {
            return CheckValue(value, filters.ToArray());
        }

        /// <summary>
        /// Checks the value within  filter
        /// </summary>
        /// <param name="value">int value</param>
        /// <param name="filter">filter</param>
        /// <returns>true if the value does not match the filter, else false</returns>
        public static bool CheckValue(this int value, int filter)
        {
            return !(filter == value);
        }
        #endregion
    }
}