using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalkToFlayApi.Models.Output
{
    /// <summary>
    /// 區域OutputModel
    /// </summary>
    public class AreaOutputModel
    {
        /// <summary>
        /// 鄉鎮縣市區Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 鄉鎮縣市區名稱
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// RF:縣市Id
        /// </summary>
        public string CitiId { get; set; }
    }
}
