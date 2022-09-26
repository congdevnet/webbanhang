using System.Security.Cryptography;

namespace WebChuyenDe.Enforcement
{
    public static class PassWordHash
    {
        /// <summary>
        /// Chuyển mật khẩu về MD5
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string GetMD5(string password)
        {
            using (MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider())
            {
                byte[] b = System.Text.Encoding.UTF8.GetBytes(password);
                b = MD5.ComputeHash(b);
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                foreach (byte x in b)

                    sb.Append(x.ToString("x2"));

                return sb.ToString();
            }
        }
    }
}