using System.Text;
using System.Security.Cryptography;
using System.Web;

namespace SmartPaperLib
{
    public class SmartPaperManager
    {
        // Recommended Nonce length (96 bits = 12 bytes)
        public const int NonceByteSize = 12;
        // Tag length (128 bits = 16 bytes)
        public const int TagByteSize = 16;
        // Key length (256 bits = 32 bytes)
        public const int KeyByteSize = 32;

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

        public static byte[] GenerateUniqueNonce()
        {
            byte[] bytes = new byte[NonceByteSize];
            RandomNumberGenerator.Fill(bytes);
            return bytes;
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

        public static string EncryptData(string data, byte[] key, byte[] nonce, byte[] associatedData = null)
        {
            // Key length must be one of 16, 24, or 32 bytes. (AES-128, AES-192, AES-256)
            if (key.Length != 16 && key.Length != 24 && key.Length != 32)
                throw new ArgumentException("Key must be 16, 24, or 32 bytes long for AES-128, AES-192, or AES-256 respectively.", nameof(key));
            if (nonce.Length != SmartPaperManager.NonceByteSize) // Nonce must be 12 bytes.
                throw new ArgumentException($"Nonce must be {SmartPaperManager.NonceByteSize} bytes long.", nameof(nonce));

            using (var aesGcm = new AesGcm(key))
            {
                byte[] plaintext = Encoding.UTF8.GetBytes(data);
                byte[] cipherText = new byte[plaintext.Length];
                byte[] tag = new byte[SmartPaperManager.TagByteSize]; // GCM 태그는 16바이트 (128비트)

                aesGcm.Encrypt(nonce, plaintext, cipherText, tag, associatedData);
                byte[] combinedData = new byte[cipherText.Length + tag.Length];
                Buffer.BlockCopy(cipherText, 0, combinedData, 0, cipherText.Length);
                Buffer.BlockCopy(tag, 0, combinedData, cipherText.Length, tag.Length);
                return Convert.ToBase64String(combinedData);
            }
        }

        /// <summary>
        /// Construct a URL that contains an encrypted URL.
        /// </summary>
        /// <param name="url">String data to be encrypted with GCM</param>
        /// <param name="key">AES encryption key (byte[])</param>
        /// <param name="nonce">Nonce (byte[])</param>
        /// <returns>A composed URL string</returns>
        public static string EncryptAndGenerateUrl(string url, byte[] key, byte[] nonce, bool isAutoSave = false)
        {
            // 1. Perform GCM encryption and concatenate the cipher and tag and encode them as Base64
            string encryptedDataBase64 = EncryptData(url, key, nonce);

            // 2. Encode Nonce to Base64
            string nonceBase64 = Convert.ToBase64String(nonce);

            // 3. Convert Key Bytes to Bits
            int keyBits = key.Length << 3; // 16 bytes -> 128 bits, 24 bytes -> 192 bits, 32 bytes -> 256 bits

            // 4. Constructing URL query parameters and URL encoding
            //string encodedData = Uri.EscapeDataString(encryptedDataBase64);
            string encodedData = HttpUtility.UrlEncode(encryptedDataBase64);
            //string encodedNonce = Uri.EscapeDataString(nonceBase64);
            string encodedNonce = HttpUtility.UrlEncode(nonceBase64);

            // 5. Generate URL parameters
            return $"{SECURE_URL_SMART_PAPER_PREFIX}&url={encodedData}&iv={encodedNonce}&keyBits={keyBits}&autoSave={isAutoSave.ToString().ToLowerInvariant()}";
        }
    }
}
