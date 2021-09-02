using System;
using System.Collections.Generic;
using System.Text;

namespace WalkToFlayApi.Repository.Models
{
    /// <summary>
    /// 會員Model
    /// </summary>
    public class MemberModel
    {
        /// <summary>
        /// 會員Id
        /// </summary>
        public string MemberId { get; set; }
        /// <summary>
        /// 姓氏
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// 名稱
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// 密碼
        /// </summary>
        public string PassWord { get; set; }
        /// <summary>
        /// 信箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime BirthDay { get; set; }
        /// <summary>
        /// 性別
        /// </summary>
        public bool Sex { get; set; }
        /// <summary>
        /// 手機
        /// </summary>
        public string MobilePhone { get; set; }
        /// <summary>
        /// 市話
        /// </summary>
        public string TelePhone { get; set; }
        /// <summary>
        /// 縣市
        /// </summary>
        public int? City { get; set; }
        /// <summary>
        /// 鄉鎮市區
        /// </summary>
        public int? Area { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 更新時間
        /// </summary>
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 是否啟用
        /// </summary>
        public bool EnableFlag { get; set; }
    }
}
