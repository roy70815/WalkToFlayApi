using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkToFlayApi.Models.Input;
using WalkToFlayApi.Models.Output;
using WalkToFlayApi.Service.Dtos;

namespace WalkToFlayApi.Infrastructure.Mapper
{
    /// <summary>
    /// Application映射類別
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class ApplicationProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationProfile"/> class.
        /// </summary>
        public ApplicationProfile()
        {
            CreateMap<MemberParameter, MemberParameterDto>();
            CreateMap<SystemRoleUserDto, SystemRoleUserOutputModel>();
            CreateMap<SystemFunctionParameter, SystemFunctionDto>();
            CreateMap<SystemFunctionDto, SystemFunctionOutputModel>();
            CreateMap<MemberDto, MemberOutputModel>();
            CreateMap<CityDto, CityOutputModel>();
            CreateMap<AreaDto, AreaOutputModel>();
            CreateMap<SystemFunctionDetailParameter, SystemFunctionDetailDto>();
            CreateMap<SystemFunctionDetailDto, SystemFunctionDetailOutputModel>();
        }
    }
}
