using System.Security.Cryptography;
using System.Text;

namespace Client.Helpers
{
    public static class CryptoHelper
    {
        public static string GetHardwareHash()
        {
            string toEncode = EnvironmentHelper.GetMacAddress() + EnvironmentHelper.GetRamSerial();
            toEncode = toEncode.Replace(":", "").Replace(" ", "");

            byte[] bytes = Encoding.Unicode.GetBytes(toEncode);
            SHA256Managed sha256 = new SHA256Managed();
            byte[] hash = sha256.ComputeHash(bytes);

            string hashedString = string.Empty;
            foreach (byte x in hash)
            {
                hashedString += string.Format("{0:x2}", x);
            }

            return hashedString;
        }
    }
}
