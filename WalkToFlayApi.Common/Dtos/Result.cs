using System;
using System.Collections.Generic;
using System.Text;

namespace WalkToFlayApi.Common.Dtos
{
    /// <summary>
    /// 共用回傳類別
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class.
        /// </summary>
        public Result()
        {
            Id = Guid.NewGuid();
            Success = false;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class.
        /// </summary>
        /// <param name="success">狀態</param>
        public Result(bool success)
        {
            Id = Guid.NewGuid();
            Success = success;
        }
        /// <summary>
        /// 編號
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 回傳訊息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 狀態
        /// </summary>
        public bool Success { get; set; }
    }
}
