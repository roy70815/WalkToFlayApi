using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalkToFlayApi.Models.Output
{
    /// <summary>
    /// 錯誤訊息
    /// </summary>
    public class FailInformation
    {
        public string Domain { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
    }
}
