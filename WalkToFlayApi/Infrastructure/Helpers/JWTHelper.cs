using JWT;
using JWT.Algorithms;
using JWT.Exceptions;
using JWT.Serializers;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WalkToFlayApi.Service.Interface;

namespace WalkToFlayApi.Infrastructure.Helpers
{
    /// <summary>
    /// JWT實作
    /// </summary>
    /// <seealso cref="WalkToFlayApi.Common.Helpers.IJWTHelper" />
    public class JWTHelper : IJWTHelper
    {
        /// <summary>
        /// The configuration
        /// </summary>
        private IConfiguration _configuration;

        /// <summary>
        /// The system role user service
        /// </summary>
        private readonly ISystemRoleUserService _systemRoleUserService;

        /// <summary>
        /// The system role service
        /// </summary>
        private readonly ISystemRoleService _systemRoleService;

        /// <summary>
        /// Initializes a new instance of the <see cref="JWTHelper"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="systemRoleUserService">The system role user service.</param>
        /// <param name="systemRoleService">The system role service.</param>
        public JWTHelper(IConfiguration configuration, ISystemRoleUserService systemRoleUserService, ISystemRoleService systemRoleService)
        {
            _configuration = configuration;
            _systemRoleUserService = systemRoleUserService;
            _systemRoleService = systemRoleService;
        }

        /// <summary>
        /// 建立Token
        /// </summary>
        /// <param name="memberId">會員Id</param>
        /// <returns></returns>
        public string CreateToken(string memberId)
        {
            // 設定要加入到 JWT Token 中的聲明資訊(Claims)
            var claims = new List<Claim>();

            // 在 RFC 7519 規格中(Section#4)，總共定義了 7 個預設的 Claims，我們應該只用的到兩種！
            //claims.Add(new Claim(JwtRegisteredClaimNames.Iss, issuer));
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, memberId)); // User.Identity.Name
            //claims.Add(new Claim(JwtRegisteredClaimNames.Aud, "The Audience"));
            //claims.Add(new Claim(JwtRegisteredClaimNames.Exp, DateTimeOffset.UtcNow.AddMinutes(30).ToUnixTimeSeconds().ToString())); // 必須為數字
            //claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString())); // 必須為數字
            //claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString())); // 必須為數字
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())); // JWT ID

            // 網路上常看到的這個 NameId 設定是多餘的
            //claims.Add(new Claim(JwtRegisteredClaimNames.NameId, userName));

            // 這個 Claim 也以直接被 JwtRegisteredClaimNames.Sub 取代，所以也是多餘的
            // https://stackoverflow.com/a/45333209/910074
            //claims.Add(new Claim(ClaimTypes.Name, userName));

            // 你可以自行擴充 "roles" 加入登入者該有的角色
            var roleUserId = _systemRoleService.GetRoleUserIdByMemberIdAsync(memberId).GetAwaiter().GetResult();
            var roleUserName = _systemRoleUserService.GetRoleUserNameByRoleUserIdAsync(roleUserId).GetAwaiter().GetResult();
            if(roleUserName != null)
            {
                claims.Add(new Claim("roles", roleUserName));
            }
            //claims.Add(new Claim("roles", "Users"));

            var userClaimsIdentity = new ClaimsIdentity(claims);

            // 建立一組對稱式加密的金鑰，主要用於 JWT 簽章之用
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtToken:Secret"]));

            // HmacSha256 有要求必須要大於 128 bits，所以 key 不能太短，至少要 16 字元以上
            // https://stackoverflow.com/a/47280062/910074
            // 你不應該再使用 SecurityAlgorithms.HmacSha256 (已過時)
            // https://stackoverflow.com/a/41870180/910074
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // 建立 SecurityTokenDescriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["JwtToken:Issuer"],
                //Audience = issuer, // 由於 API 用戶端通常沒有特別區分對象，因此不太需要設定，也不太需要驗證
                //NotBefore = DateTime.Now, // 預設值就是 DateTime.Now
                //IssuedAt = DateTime.Now, // 預設值就是 DateTime.Now
                Subject = userClaimsIdentity,
                Expires = DateTime.Now.AddMinutes(5),
                SigningCredentials = signingCredentials
            };

            // 產出所需要的 JWT securityToken 物件，並取得序列化後的 Token 結果(字串格式)
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var serializeToken = tokenHandler.WriteToken(securityToken);

            return serializeToken;
        }

        /// <summary>
        /// 解析Token
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        public string ValidateJwtToken(string token)
        {
            try
            {
                IJsonSerializer serializer = new JsonNetSerializer();
                IDateTimeProvider provider = new UtcDateTimeProvider();
                IJwtValidator validator = new JwtValidator(serializer, provider);
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
                IJwtAlgorithm alg = new HMACSHA256Algorithm();
                IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder, alg);
                var secret = _configuration["JwtToken:Secret"];
                var json = decoder.Decode(token, secret, true);
                //校验通过，返回解密后的字符串
                return json;
            }
            catch (TokenExpiredException)
            {
                //表示过期
                return "expired";
            }
            catch (SignatureVerificationException)
            {
                //表示验证不通过
                return "invalid";
            }
            catch (Exception)
            {
                return "error";
            }
        }
    }
}
