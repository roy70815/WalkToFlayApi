using System;
using System.Collections.Generic;
using System.Text;

namespace WalkToFlayApi.Infrastructure.Helpers
{
    /// <summary>
    /// JWT介面
    /// </summary>
    public interface IJWTHelper
    {
        /// <summary>
        /// 建立Token
        /// </summary>
        /// <param name="memnerId">會員Id</param>
        /// <returns></returns>
        string CreateToken(string memnerId);

        /// <summary>
        /// 解析Token
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        string ValidateJwtToken(string token);
    }
}
