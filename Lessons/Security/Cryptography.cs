using System.Security.Cryptography;

class Cryptography
{
  public static void Run()
  {
    string originalText = "shoxruxmirzo";

    using Aes aes = Aes.Create();
    byte[] key = aes.Key;
    byte[] iv = aes.IV;

    Console.WriteLine("KEY: {0}", string.Join(" ", key));
    Console.WriteLine("KEY SIZE: {0}", aes.KeySize);
    Console.WriteLine(key.Length * 8);
    Console.WriteLine("IV: {0}", string.Join(" ", iv));

    byte[] encrypted = Encrypt(originalText, key, iv);
    Console.WriteLine("Encrypted: " + Convert.ToBase64String(encrypted));

    string decrypted = Decrypt(encrypted, key, iv);
    Console.WriteLine("Decrypted: " + decrypted);
  }

  static byte[] Encrypt(string plainText, byte[] key, byte[] iv)
  {
    using Aes aes = Aes.Create();
    aes.Key = key;
    aes.IV = iv;

    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

    using MemoryStream ms = new();
    using CryptoStream cs = new(ms, encryptor, CryptoStreamMode.Write);
    using StreamWriter sw = new(cs);

    sw.Write(plainText);
    sw.Close();

    return ms.ToArray();
  }
  static string Decrypt(byte[] cipherText, byte[] key, byte[] iv)
  {
    using Aes aes = Aes.Create();
    aes.Key = key;
    aes.IV = iv;

    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

    using MemoryStream ms = new(cipherText);
    using CryptoStream cs = new(ms, decryptor, CryptoStreamMode.Read);
    using StreamReader sr = new(cs);

    return sr.ReadToEnd();
  }
}
