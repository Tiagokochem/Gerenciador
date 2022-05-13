using System.Security.Cryptography;
using System.Text;

namespace Site.Helper
{
    public static class Criptografia
    {
        public static string GerarHash(this string valor)
        {
            var hash = SHA1.Create();
            var encodeing = new ASCIIEncoding();
            var array = encodeing.GetBytes(valor);

            array = hash.ComputeHash(array);

            var strHexa = new StringBuilder();

            foreach(var item in array)
            {
                strHexa.Append(item.ToString("x2"));
            }
            return strHexa.ToString();
        }

    }
}
