using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace WalkToFlayApi.Common.Helpers
{
    /// <summary>
    /// 加密Helper
    /// </summary>
    public static class EncryptHelper
    {
        /// <summary>
        /// Shes the a256.
        /// </summary>
        /// <param name="data">需要加密字串</param>
        /// <returns></returns>
        public static string SHA256(string data)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(data);
            byte[] hash = SHA256Managed.Create().ComputeHash(bytes);

            StringBuilder build = new StringBuilder();
            for(int i=0;i< hash.Length; i++)
            {
                build.Append(hash[i].ToString("X2"));
            }

            return build.ToString();
        }
    }
}
