using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
                                    County, 
                                    City, 
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
                                    @County,
                                    @City,
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
        public async Task<MemberModel> GetByMemberIdAsync(string memberId)
        {
            var sqlCommand = @" SELECT * FROM Member";

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
    }
}
