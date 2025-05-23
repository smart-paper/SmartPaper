namespace SmartPaperLib
{
    public class DataManager
    {
        public static string ByteArrayToBase64(byte[] bytes)
        {
            return Convert.ToBase64String(bytes); // Change to Base64 encoding (more URL-safe than hexadecimal)
        }

        public static string IntToColorHex(int value, int length = 8)
        {
            return $"#{value.ToString("X").PadLeft(length, '0')}";
        }
    }
}
