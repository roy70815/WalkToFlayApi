using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkToFlayApi.Common.Helpers;
using WalkToFlayApi.Infrastructure.Helpers;
using WalkToFlayApi.Repository.Implement;
using WalkToFlayApi.Repository.Interface;
using WalkToFlayApi.Service.Implement;
using WalkToFlayApi.Service.Interface;

namespace WalkToFlayApi.Infrastructure.DependencyInjection
{
    /// <summary>
    /// 依賴注入
    /// </summary>
    public static class DependencyInjectionExtention
    {
        /// <summary>
        /// 依賴注入方法
        /// </summary>
        /// <param name="services">The services.</param>
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddCommon();
            services.AddApplication();
            services.AddService();
            services.AddRepository();
        }

        /// <summary>
        /// 依賴注入Common層
        /// </summary>
        /// <param name="services">The services.</param>
        public static void AddCommon(this IServiceCollection services)
        {
            services.AddTransient<IDataBaseHelper, DataBaseHelper>();
            services.AddTransient<IDapperHelper, DapperHelper>();
        }

        /// <summary>
        /// 依賴注入Application層
        /// </summary>
        /// <param name="services">The services.</param>
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IJWTHelper, JWTHelper>();
        }
        /// <summary>
        /// 依賴注入Service層
        /// </summary>
        /// <param name="services">The services.</param>
        public static void AddService(this IServiceCollection services)
        {
            services.AddTransient<IMemberService, MemberService>();
            services.AddTransient<ILogginService, LogginService>();
            services.AddTransient<ISystemRoleUserService, SystemRoleUserService>();
            services.AddTransient<ISystemFunctionService, SystemFunctionService>();
            services.AddTransient<IDistrictService, DistrictService>();
            services.AddTransient<ISystemFunctionDetailService, SystemFunctionDetailService>();
            services.AddTransient<IMenuService, MenuService>();
            services.AddTransient<ISystemRoleService, SystemRoleService>();
        }

        /// <summary>
        /// 依賴注入Repository層
        /// </summary>
        /// <param name="services">The services.</param>
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IMemberRepository, MemberRepository>();
            services.AddTransient<ISystemRoleUserRepository, SystemRoleUserRepository>();
            services.AddTransient<ISystemFunctionRepository, SystemFunctionRepository>();
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<IAreaRepository, AreaRepository>();
            services.AddTransient<ISystemFunctionDetailRepository, SystemFunctionDetailRepository>();
            services.AddTransient<ISystemRoleRepository, SystemRoleRepository>();
            services.AddTransient<ISystemRoleUserFunctionRepository, SystemRoleUserFunctionRepository>();
        }
    }
}
