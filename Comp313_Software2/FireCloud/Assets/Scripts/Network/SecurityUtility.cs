using System.Text;
using System.Security.Cryptography;
public class SecurityUtility
{
    public const int PBKDF2_ITERATION = 10000;
    public static string MD5Sum(string stringToEncrypt)
    {
        System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
        byte[] bytes = ue.GetBytes(stringToEncrypt);

        // Encrypt bytes
        System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] hashBytes = md5.ComputeHash(bytes);

        // Convert the encrypted bytes back to a string (base 16)
        string hashString = "";

        for (int i = 0; i < hashBytes.Length; i++)
        {
            hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
        }

        return hashString.PadLeft(32, '0');
    }

    public static string PBKDF2(string stringToEncrypt, string salt)
    {
        byte[] stringToEncryptBytes = Encoding.UTF8.GetBytes(stringToEncrypt);
        byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
        Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(stringToEncryptBytes, saltBytes, PBKDF2_ITERATION);
        byte[] hash = pbkdf2.GetBytes(64);
        return System.Convert.ToBase64String(hash);
    }
}
