using System.Collections.Generic;
using KiUtilities.Structures;
using KiUtilities.Corrector;
using KiUtilities.Filters;

namespace KiUtilities.Random
{
    public static class KiRandomExtension
    {
        #region RandomValueExtension

        #region Float

        /// <summary>
        /// Get random value within range and filter
        /// </summary>
        /// <param name="range">Range random float value</param>
        /// <param name="filters">Filters for random value</param>
        /// <param name="seed">Initializes the random number generator state with a seed</param>
        /// <returns>a float value within range and filtered</returns>
        public static float RandomValueExtension(this KiRangeFloat range, float[] filters = null, int? seed = null)
        {
            if (filters == null || filters.Length == 0) return range.RandomValue();

            bool isFiltered = false;
            float value = 0;
            while (!isFiltered)
            {
                value = range.RandomValue();
                isFiltered = value.CheckValue(filters);
            }
            return value;
        }

        /// <summary>
        /// Get random value within range and filter
        /// </summary>
        /// <param name="range">Range random float value</param>
        /// <param name="filters">Filters for random value</param>
        /// <param name="seed">Initializes the random number generator state with a seed</param>
        /// <returns>a float value within range and filtered</returns>
        public static float RandomValueExtension(this KiRangeFloat range, List<float> filters = null, int? seed = null)
        {
            return RandomValueExtension(range, filters.ToArray(), seed);
        }

        /// <summary>
        /// Get random value within range and filter
        /// </summary>
        /// <param name="range">Range random float value</param>
        /// <param name="filter">Filter for random value</param>
        /// <param name="seed">Initializes the random number generator state with a seed</param>
        /// <returns>a float value within range and filtered</returns>
        public static float RandomValueExtension(this KiRangeFloat range, float? filter = null, int? seed = null)
        {
            if (filter == null) return range.RandomValue();

            bool isFiltered = false;
            float value = 0;
            while (!isFiltered)
            {
                value = range.RandomValue();
                isFiltered = value.CheckValue((float)filter);
            }
            return value;
        }


        /// <summary>
        /// Get random value within [min..max) and filter
        /// </summary>
        /// <param name="min">Minimum random float value</param>
        /// <param name="max">Maximum random float value</param>
        /// <param name="filters">Filters for random value</param>
        /// <param name="seed">Initializes the random number generator state with a seed</param>
        /// <returns>a float value within range and filtered</returns>
        public static float RandomValueExtension(this float min, float max, float[] filters = null, int? seed = null)
        {
            KiRangeFloat range = min.GetRange(max);
            return range.RandomValueExtension(filters, seed);
        }

        /// <summary>
        /// Get random value within [min..max) and filter
        /// </summary>
        /// <param name="min">Minimum random float value</param>
        /// <param name="max">Maximum random float value</param>
        /// <param name="filters">Filters for random value</param>
        /// <param name="seed">Initializes the random number generator state with a seed</param>
        /// <returns>a float value within range and filtered</returns>
        public static float RandomValueExtension(this float min, float max, List<float> filters = null, int? seed = null)
        {
            return RandomValueExtension(min, max, filters.ToArray(), seed);
        }

        /// <summary>
        /// Get random value within [min..max) and filter
        /// </summary>
        /// <param name="min">Minimum random float value</param>
        /// <param name="max">Maximum random float value</param>
        /// <param name="filter">Filter for random value</param>
        /// <param name="seed">Initializes the random number generator state with a seed</param>
        /// <returns>a float value within [min..max) and filtered</returns>
        public static float RandomValueExtension(this float min, float max, float? filter = null, int? seed = null)
        {
            KiRangeFloat range = min.GetRange(max);
            return range.RandomValueExtension(filter, seed);
        }

        #endregion

        #region Int

        /// <summary>
        /// Get random value within range and filter
        /// </summary>
        /// <param name="range">Range random int value</param>
        /// <param name="filters">Filters for random value</param>
        /// <param name="seed">Initializes the random number generator state with a seed</param>
        /// <returns>a int value within range and filtered</returns>
        public static int RandomValueByFilter(this KiRangeInt range, int[] filters = null, int? seed = null)
        {
            if (filters == null || filters.Length == 0) return range.RandomValue();

            bool isFiltered = false;
            int value = 0;
            while (!isFiltered)
            {
                value = range.RandomValue();
                isFiltered = value.CheckValue(filters);
            }
            return value;
        }

        /// <summary>
        /// Get random value within range and filter
        /// </summary>
        /// <param name="range">Range random int value</param>
        /// <param name="filters">Filters for random value</param>
        /// <param name="seed">Initializes the random number generator state with a seed</param>
        /// <returns>a int value within range and filtered</returns>
        public static int RandomValueByFilter(this KiRangeInt range, List<int> filters = null, int? seed = null)
        {
            return RandomValueByFilter(range, filters.ToArray(), seed);
        }

        /// <summary>
        /// Get random value within range and filter
        /// </summary>
        /// <param name="range">Range random int value</param>
        /// <param name="filter">Filter for random value</param>
        /// <param name="seed">Initializes the random number generator state with a seed</param>
        /// <returns>a int value within range and filtered</returns>
        public static int RandomValueByFilter(this KiRangeInt range, int? filter = null, int? seed = null)
        {
            if (filter == null) return range.RandomValue();

            bool isFiltered = false;
            int value = 0;
            while (!isFiltered)
            {
                value = range.RandomValue();
                isFiltered = value.CheckValue((int)filter);
            }
            return value;
        }


        /// <summary>
        /// Get random value within [min..max) and filter
        /// </summary>
        /// <param name="min">Minimum random int value</param>
        /// <param name="max">Maximum random int value</param>
        /// <param name="filters">Filters for random value</param>
        /// <param name="seed">Initializes the random number generator state with a seed</param>
        /// <returns>a int value within range and filtered</returns>
        public static int RandomValueByFilter(this int min, int max, int[] filters = null, int? seed = null)
        {
            KiRangeInt range = min.GetRange(max);
            return range.RandomValueByFilter(filters, seed);
        }

        /// <summary>
        /// Get random value within [min..max) and filter
        /// </summary>
        /// <param name="min">Minimum random int value</param>
        /// <param name="max">Maximum random int value</param>
        /// <param name="filters">Filters for random value</param>
        /// <param name="seed">Initializes the random number generator state with a seed</param>
        /// <returns>a int value within range and filtered</returns>
        public static int RandomValueByFilter(this int min, int max, List<int> filters = null, int? seed = null)
        {
            return RandomValueByFilter(min, max, filters.ToArray(), seed);
        }

        /// <summary>
        /// Get random value within [min..max) and filter
        /// </summary>
        /// <param name="min">Minimum random int value</param>
        /// <param name="max">Maximum random int value</param>
        /// <param name="filter">Filter for random value</param>
        /// <param name="seed">Initializes the random number generator state with a seed</param>
        /// <returns>a int value within [min..max) and filtered</returns>
        public static int RandomValueByFilter(this int min, int max, int? filter = null, int? seed = null)
        {
            KiRangeInt range = min.GetRange(max);
            return range.RandomValueByFilter(filter, seed);
        }
        #endregion

        #endregion

        #region RandomValue

        #region Float

        /// <param name="range">(float minimum, float maximum)</param>
        /// <param name="seed">Initializes the random number generator state with a seed</param>
        /// <returns>Returns a random float within [min..max)</returns>
        public static float RandomValue(this KiRangeFloat range, int? seed = null)
        {
            range.min.CorrectMinValue(range.max);
            if (seed != null)
                UnityEngine.Random.InitState((int)seed);
            return UnityEngine.Random.Range(range.min, range.max);
        }

        /// <param name="min">float minimum</param>
        /// <param name="max">float maximum</param>
        /// <param name="seed">Initializes the random number generator state with a seed</param>
        /// <returns>Returns a random float within [min..max)</returns>
        public static float RandomValue(this float min, float max, int? seed = null)
        {
            return RandomValue(min.GetRange(max), seed);
        }
        #endregion

        #region Int

        /// <param name="range">(int minimum, int maximum)</param>
        /// <param name="seed">Initializes the random number generator state with a seed</param>
        /// <returns>Returns a random int within [min..max)</returns>
        public static int RandomValue(this KiRangeInt range, int? seed = null)
        {
            range.min.CorrectMinValue(range.max);

            if (seed != null)
                UnityEngine.Random.InitState((int)seed);
            return UnityEngine.Random.Range(range.min, range.max);
        }

        /// <param name="min">int minimum</param>
        /// <param name="max">int maximum</param>
        /// <param name="seed">Initializes the random number generator state with a seed</param>
        /// <returns>Returns a random int within [min..max)</returns>
        public static int RandomValue(this int min, int max, int? seed = null)
        {
            return RandomValue(min.GetRange(max), seed);
        }
        #endregion

        #endregion
    }
}
