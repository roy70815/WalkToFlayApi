using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace WalkToFlayApi.Common.Helpers
{
    /// <summary>
    /// DB連線介面
    /// </summary>
    public interface IDataBaseHelper
    {
        IDbConnection GetWalkToFlyConnection();
    }
}
