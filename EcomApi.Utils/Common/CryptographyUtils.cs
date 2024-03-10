using Org.BouncyCastle;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Utilities.IO.Pem;
using System.Security.Cryptography;
using System.Text;

namespace EcomApi.Utils.Common
{
    public static class CryptographyUtils
    {
        public static async Task<T> DecryptBody<T>(this HttpRequest request, RSA privateKey)
        {
            try
            {
                using (StreamReader reader = new StreamReader(request.Body, Encoding.UTF8))
                {
                    string encryptedData = await reader.ReadToEndAsync();

                    // Decrypt the encryptedData using the private key
                    string decryptedData = DecryptData(encryptedData, privateKey);

                    // Deserialize the decrypted data into the specified type (T)
                    T result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(decryptedData);

                    return result;
                }
            }
            catch (Exception ex)
            {
                // Handle decryption or other exceptions as needed
                Console.WriteLine($"Error decrypting request body: {ex.Message}");
                return default(T);
            }
        }

        private static string DecryptData(string encryptedData, RSA privateKey)
        {
            // Implement your decryption logic using the private key here
            // Example: Use RSACryptoServiceProvider to decrypt the data
            byte[] encryptedBytes = Convert.FromBase64String(encryptedData);
            byte[] decryptedBytes = privateKey.Decrypt(encryptedBytes, RSAEncryptionPadding.OaepSHA256);
            string decryptedData = Encoding.UTF8.GetString(decryptedBytes);

            return decryptedData;
        }
        //private static string ExportPrivateKeyToPem(RSA rsa)
        //{
        //    using (TextWriter textWriter = new StringWriter())
        //    {
        //        var pemWriter = new PemWriter(textWriter);
        //        pemWriter.WriteObject(new AsymmetricCipherKeyPair(new RsaKeyParameters(true, rsa.ExportParameters(true))));
        //        pemWriter.Writer.Flush();

        //        return textWriter.ToString();
        //    }
        //}

        private static void SaveKeyToPemFile(string fileName, string key)
        {
            string pemFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            File.WriteAllText(pemFilePath, key);

            Console.WriteLine($"{fileName} saved to {fileName} file.");
        }

        private static void SavePublicKeyToEnv(string publicKey)
        {
            string envFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ".env");

            // Append or replace the REACT_APP_PUBLIC_KEY in .env
            string envContent = File.Exists(envFilePath)
                ? File.ReadAllText(envFilePath)
                : string.Empty;

            envContent = envContent.Replace("REACT_APP_PUBLIC_KEY=", $"REACT_APP_PUBLIC_KEY={publicKey}");

            File.WriteAllText(envFilePath, envContent);

            Console.WriteLine("Public Key saved to .env file.");
        }
    }

}
