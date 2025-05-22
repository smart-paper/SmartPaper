namespace SmartPaperLib
{
    public class DatetimeManager
    {
        public static string GetCurrentTimeString()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss"); // Current time as a string in the format 'yyyyMMddHHmmss'
        }

        public static string GetCurrentTimeHexId()
        {
            // Convert a string to long. (It is a 16-digit number, so it can be stored in long.)
            if (long.TryParse(GetCurrentTimeString(), out long currentTimeLong))
            {
                string hexString = currentTimeLong.ToString("X");   // Converts a long to a hexadecimal string.
                return hexString.PadLeft(8, '0');   // If it is not filled with 8 digits, pad the left with 0s.
            }
            else
            {
                return "00000000"; // If the conversion fails, return 8 digits of 0.
            }
        }
    }
}
