using System.Text;
using System.Security.Cryptography;

namespace SmartPaperLib
{
    public class SecurityManager
    {
        public static byte[] GenerateDeterministicKeyFromPin(string pin, int keyBitLength = 256)
        {
            // Convert the entered PIN to a byte array seed
            byte[] seedBytes = Encoding.UTF8.GetBytes(pin);

            // Generate a 256-bit key deterministically using the SHA-256 hash function
            using (var sha256 = SHA256.Create())
            {
                // Generate a 256-bit (32-byte) Key by hashing the PIN byte array
                byte[] hashBytes = sha256.ComputeHash(seedBytes);
                if (keyBitLength == 256)
                {
                    return hashBytes;
                }
                else if (keyBitLength == 192)
                {
                    return hashBytes.Take(24).ToArray(); // First 24 bytes (192 bits)
                }
                else if (keyBitLength == 128)
                {
                    return hashBytes.Take(16).ToArray(); // First 16 bytes (128 bits)
                }
                else
                {
                    throw new ArgumentException("Key bit length is not supported (128, 192, 256).");
                }
            }
        }

        public static byte[] GenerateUniqueIV()
        {
            using (Aes aes = Aes.Create())
            {
                return aes.IV;
            }
        }

        private static readonly string NORMAL_URL_SMART_PAPER_PREFIX = "https://app.publicplatform.co.kr/?/smart_paper?type=url";
        private static readonly string SECURE_URL_SMART_PAPER_PREFIX = "https://app.publicplatform.co.kr/?/smart_paper?type=surl";

        public static string? GenerateUrl(string destUrl, bool isAutoSave = false)
        {
            try
            {
                return $"{NORMAL_URL_SMART_PAPER_PREFIX}&url={Uri.EscapeDataString(destUrl)}&autoSave={isAutoSave.ToString().ToLowerInvariant()}";
           }
            catch
            {
                return null;
            }
        }

        public static string? EncryptAndGenerateUrl(string url, byte[] keyBytes, byte[] ivBytes, bool isAutoSave = false)
        {
            try
            {
                using (Aes aes = Aes.Create())
                {
                    aes.Key = keyBytes;
                    aes.IV = ivBytes;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;

                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                    using (var ms = new System.IO.MemoryStream())
                    {
                        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        {
                            using (var sw = new System.IO.StreamWriter(cs))
                            {
                                sw.Write(url);
                            }
                            byte[] encrypted = ms.ToArray();

                            string encryptedDataEncoded = Uri.EscapeDataString(Convert.ToBase64String(encrypted));
                            string ivEncoded = Uri.EscapeDataString(Convert.ToBase64String(ivBytes));
                            int keyBits = keyBytes.Length << 3;

                            // URL 파라미터 생성
                            return $"{SECURE_URL_SMART_PAPER_PREFIX}&url={encryptedDataEncoded}&iv={ivEncoded}&keyBits={keyBits}&autoSave={isAutoSave.ToString().ToLowerInvariant()}";
                        }
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        public static string? EncryptJsonData(string data, byte[] keyBytes, byte[] ivBytes)
        {
            try
            {
                using (Aes aes = Aes.Create())
                {
                    aes.Key = keyBytes;
                    aes.IV = ivBytes;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;

                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                    using (var ms = new System.IO.MemoryStream())
                    {
                        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        {
                            using (var sw = new System.IO.StreamWriter(cs))
                            {
                                sw.Write(data);
                            }
                            byte[] encrypted = ms.ToArray();
                            return Convert.ToBase64String(encrypted);
                        }
                    }
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
