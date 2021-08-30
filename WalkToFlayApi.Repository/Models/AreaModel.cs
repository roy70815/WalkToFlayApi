using System;
using System.Collections.Generic;
using System.Text;

namespace WalkToFlayApi.Repository.Models
{
    /// <summary>
    /// 鄉鎮市區域Model
    /// </summary>
    public class AreaModel
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
