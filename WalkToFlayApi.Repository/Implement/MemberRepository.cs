using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WalkToFlayApi.Common.Dtos;
using WalkToFlayApi.Common.Helpers;
using WalkToFlayApi.Repository.Interface;
using WalkToFlayApi.Repository.Models;

namespace WalkToFlayApi.Repository.Implement
{
    /// <summary>
    /// 會員實作
    /// </summary>
    public class MemberRepository : IMemberRepository
    {
        /// <summary>
        /// DapperHelper
        /// </summary>
        private readonly IDapperHelper _dapperHelper;

        /// <summary>
        /// DataBaseHelper
        /// </summary>
        private readonly IDataBaseHelper _dataBaseHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberRepository"/> class.
        /// </summary>
        /// <param name="dapperHelper">The dapper helper.</param>
        /// <param name="dataBaseHelper">The data base helper.</param>
        public MemberRepository(IDapperHelper dapperHelper, IDataBaseHelper dataBaseHelper)
        {
            _dapperHelper = dapperHelper;
            _dataBaseHelper = dataBaseHelper;
        }

        /// <summary>
        /// 建立會員資料
        /// </summary>
        /// <param name="memberModel">會員資料Model</param>
        /// <returns>是否成功</returns>
        public async Task<bool> CreateAsync(MemberModel memberModel)
        {
            var sqlCommand = @" INSERT INTO Member(
                                    MemberId, 
                                    FirstName, 
                                    LastName, 
                                    PassWord, 
                                    Email, 
                                    BirthDay, 
                                    Sex, 
                                    MobilePhone, 
                                    TelePhone, 
                                    City, 
                                    Area, 
                                    Address, 
                                    EnableFlag
                                ) 
                                VALUES 
                                (
                                    @MemberId,
                                    @FirstName,
                                    @LastName,
                                    @PassWord,
                                    @Email,
                                    @BirthDay,
                                    @Sex,
                                    @MobilePhone,
                                    @TelePhone,
                                    @City,
                                    @Area,
                                    @Address,
                                    @EnableFlag
                                )";


            using (var connection = _dataBaseHelper.GetWalkToFlyConnection())
            {
                var result = await _dapperHelper.ExecuteAsync(
                    connection,
                    sqlCommand,
                    memberModel
                    );

                if (result > 0)
                {
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// 取得會員資料
        /// </summary>
        /// <param name="memberId">會員Id</param>
        /// <returns>會員Model</returns>
        public async Task<MemberModel> GetAsync(string memberId)
        {
            var sqlCommand = @" SELECT * 
                                FROM Member
                                WHERE MemberId = @MemberId";

            var parameter = new DynamicParameters();
            parameter.Add("MemberId", memberId);

            using (var connection = _dataBaseHelper.GetWalkToFlyConnection())
            {
                var result = await _dapperHelper.QueryFirstOrDefaultAsync<MemberModel>(
                    connection,
                    sqlCommand,
                    parameter
                    );

                return result;
            }
        }

        /// <summary>
        /// 檢查帳號是否存在
        /// </summary>
        /// <param name="memberId">會員Id</param>
        /// <returns>是否存在</returns>
        public async Task<bool> CheckExistAsync(string memberId)
        {
            var sqlCommand = @" SELECT COUNT(*) 
                                FROM Member 
                                WHERE MemberId = @MemberId;";

            var parameter = new DynamicParameters();
            parameter.Add("MemberId", memberId);

            using (var connection = _dataBaseHelper.GetWalkToFlyConnection())
            {
                var result = await _dapperHelper.QueryFirstOrDefaultAsync<int>(
                    connection,
                    sqlCommand,
                    parameter
                    );

                if (result > 0)
                {
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// 檢查是否有這組帳號密碼
        /// </summary>
        /// <param name="memberId">會員Id</param>
        /// <param name="password">密碼</param>
        /// <returns></returns>
        public async Task<bool> CheckCanLoginAsync(string memberId, string password)
        {
            var sqlCommand = @" SELECT COUNT(*) 
                                FROM Member 
                                WHERE MemberId = @MemberId
                                AND PassWord = @PassWord;";

            var parameter = new DynamicParameters();
            parameter.Add("MemberId", memberId);
            parameter.Add("PassWord", password);

            using (var connection = _dataBaseHelper.GetWalkToFlyConnection())
            {
                var result = await _dapperHelper.QueryFirstOrDefaultAsync<int>(
                    connection,
                    sqlCommand,
                    parameter
                    );

                if (result > 0)
                {
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// 修改密碼
        /// </summary>
        /// <param name="memberId">會員Id</param>
        /// <param name="oldPassword">舊密碼</param>
        /// <param name="newPassword">新密碼</param>
        /// <returns></returns>
        public async Task<bool> UpdatePasswordAsync(string memberId, string oldPassword, string newPassword)
        {
            var sqlCommand = @" Update Member Set
                                    PassWord = @NewPassword,
                                    UpdateTime = CURRENT_TIME()
                                WHERE MemberId = @MemberId
                                AND PassWord = @OldPassword;";

            var parameter = new DynamicParameters();
            parameter.Add("MemberId", memberId);
            parameter.Add("OldPassword", oldPassword);
            parameter.Add("NewPassword", newPassword);

            using (var connection = _dataBaseHelper.GetWalkToFlyConnection())
            {
                var result = await _dapperHelper.ExecuteAsync(
                    connection,
                    sqlCommand,
                    parameter);

                if (result > 0)
                {
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// 取得會員清單
        /// </summary>
        /// <param name="pageDto">分頁參數</param>
        /// <returns>會員清單</returns>
        public async Task<IEnumerable<MemberModel>> GetAllAsync(PageDto pageDto)
        {
            var sqlCommand = new StringBuilder();
            sqlCommand.Append("SELECT * FROM Member ");
            sqlCommand.Append(PageHelper.GetSortSQL());
            sqlCommand.Append(PageHelper.GetPageSQL());

            var parameter = new DynamicParameters();
            parameter.Add("From", pageDto.From);
            parameter.Add("Size", pageDto.Size);
            parameter.Add("SortColumn", pageDto.SortColumn);
            parameter.Add("SortType", pageDto.SortType);

            using (var connection = _dataBaseHelper.GetWalkToFlyConnection())
            {
                var result = await _dapperHelper.QueryAsync<MemberModel>(
                    connection,
                    sqlCommand.ToString(),
                    parameter
                    );

                return result;
            }
        }

        /// <summary>
        /// 取得會員數量
        /// </summary>
        /// <returns>會員數量</returns>
        public async Task<int> GetTotalCountAsync()
        {
            var sqlCommand = @" SELECT COUNT(*) FROM Member";

            using (var connection = _dataBaseHelper.GetWalkToFlyConnection())
            {
                var result = await _dapperHelper.QueryFirstOrDefaultAsync<int>(
                    connection,
                    sqlCommand
                    );

                return result;
            }
        }
    }
}
