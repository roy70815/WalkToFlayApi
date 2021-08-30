using System;
using System.Collections.Generic;
using System.Text;

namespace WalkToFlayApi.Service.Dtos
{
    /// <summary>
    /// 鄉鎮縣市區Dto
    /// </summary>
    public class AreaDto
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
