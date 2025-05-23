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

        private static readonly string SECURE_URL_SMART_PAPER_PREFIX = "https://app.publicplatform.co.kr/?/smart_paper?type=surl";

        public static string? GenerateUrl(string destUrl)
        {
            try
            {
                string url = $"{SECURE_URL_SMART_PAPER_PREFIX}&url={Uri.EscapeDataString(destUrl)}";
                return url;
            }
            catch
            {
                return null;
            }
        }

        public static string? EncryptAndGenerateUrl(string dataToEncrypt, byte[] keyBytes, byte[] ivBytes)
        {
            try
            {
                using (Aes aes = Aes.Create())
                {
                    aes.Key = keyBytes;
                    aes.IV = ivBytes;

                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                    using (var ms = new System.IO.MemoryStream())
                    {
                        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        {
                            using (var sw = new System.IO.StreamWriter(cs))
                            {
                                sw.Write(dataToEncrypt);
                            }
                            byte[] encrypted = ms.ToArray();

                            // 암호화된 데이터, IV를 Base64로 인코딩 후 파라미터 데이터 인코딩
                            string encryptedDataEncoded = Uri.EscapeDataString(Convert.ToBase64String(encrypted));
                            string ivEncoded = Uri.EscapeDataString(Convert.ToBase64String(ivBytes));
                            int keyBits = keyBytes.Length * 8;

                            // URL 파라미터 생성
                            string url = $"{SECURE_URL_SMART_PAPER_PREFIX}&url={encryptedDataEncoded}&iv={ivEncoded}&keyBits={keyBits}";
                            return url;
                        }
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        public static string? EncryptJsonData(string jsonData, byte[] keyBytes, byte[] ivBytes)
        {
            try
            {
                using (Aes aes = Aes.Create())
                {
                    aes.Key = keyBytes;
                    aes.IV = ivBytes;

                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                    using (var ms = new System.IO.MemoryStream())
                    {
                        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        {
                            using (var sw = new System.IO.StreamWriter(cs))
                            {
                                sw.Write(jsonData);
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
