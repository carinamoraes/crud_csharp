using System.Security.Cryptography;
using System.Text;

namespace crud_csharp.Middleware
{
    public static class Cryptography
    {
        public static string Generate(this string password)
        {
            var hash = SHA1.Create();
            var encoding = new ASCIIEncoding();
            var array = encoding.GetBytes(password);

            array = hash.ComputeHash(array);

            var hashPassword = new StringBuilder();

            foreach (var item in array)
            {
                hashPassword.Append(item.ToString("x2"));
            }

            return hashPassword.ToString();
        }
    }
}
