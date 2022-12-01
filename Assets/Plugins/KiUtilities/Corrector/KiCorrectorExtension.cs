using KiUtilities.Structures;

namespace KiUtilities.Corrector
{
    public static class KiCorrectorExtension
    {
        #region CorrectMinValue

        /// <param name="range">(float minimum, float maximum)</param>
        /// <returns>Returns a correct min float within range.</returns>
        public static float CorrectMinValue(this KiRangeFloat range)
        {
            if (range.min >= range.max) range.min = range.max - 1;
            return range.min;
        }

        /// <param name="range">(int minimum, int maximum)</param>
        /// <returns>Returns a correct min int within range.</returns>
        public static int CorrectMinValue(this KiRangeInt range)
        {
            if (range.min >= range.max) range.min = range.max - 1;
            return range.min;
        }


        /// <param name="min">float minimum</param>
        /// <param name="max">float maximum</param>
        /// <returns>Returns a correct min float within range.</returns>
        public static float CorrectMinValue(this float min, float max)
        {
            return CorrectMinValue(min.GetRange(max));
        }

        /// <param name="min">int minimum</param>
        /// <param name="max">int maximum</param>
        /// <returns>Returns a correct min int within range.</returns>
        public static int CorrectMinValue(this int min, int max)
        {
            return CorrectMinValue(min.GetRange(max));
        }
        #endregion

        #region CorrectMaxValue

        /// <param name="range">(float minimum, float maximum)</param>
        /// <returns>Returns a correct max float within range.</returns>
        public static float CorrectMaxValue(this KiRangeFloat range)
        {
            if (range.min >= range.max) range.max = range.min + 1;
            return range.max;
        }

        /// <param name="range">(int minimum, int maximum)</param>
        /// <returns>Returns a correct max int within range.</returns>
        public static int CorrectMaxValue(this KiRangeInt range)
        {
            if (range.min >= range.max) range.max = range.min + 1;
            return range.max;
        }


        /// <param name="min">float minimum</param>
        /// <param name="max">float maximum</param>
        /// <returns>Returns a correct max float within range.</returns>
        public static float CorrectMaxValue(this float min, float max)
        {
            return CorrectMaxValue(max.GetRange(min));
        }

        /// <param name="min">int minimum</param>
        /// <param name="max">int maximum</param>
        /// <returns>Returns a correct max int within range.</returns>
        public static int CorrectMaxValue(this int min, int max)
        {
            return CorrectMaxValue(max.GetRange(min));
        }
        #endregion
    }
}