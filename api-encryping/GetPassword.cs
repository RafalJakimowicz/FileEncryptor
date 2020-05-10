using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_encryping.secure.password
{
    static class GetPassword
    {
        private static byte[] passbytes = Encoding.UTF8.GetBytes("%4$^7api_encryping.secure.password");
        public static string getPass()
        {
            return BitConverter.ToString(passbytes);
        }
    }
}
