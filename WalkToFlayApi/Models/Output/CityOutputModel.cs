using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalkToFlayApi.Models.Output
{
    /// <summary>
    /// 縣市OutputModel
    /// </summary>
    public class CityOutputModel
    {
        /// <summary>
        /// 縣市Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 縣市名稱
        /// </summary>
        public string Name { get; set; }
    }
}
