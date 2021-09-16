using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkToFlayApi.Common.Dtos;
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
            CreateMap<SmallMenuDto, SmallMenuOutputModel>();
            CreateMap<MenuDto, MenuOutputModel>();
            CreateMap<MemberPageDto, MemberPageOutputModel>()
                .ForMember(x => x.Page, y => y.MapFrom(o => o.Page))
                .ForMember(x => x.TotalCount, y => y.MapFrom(o => o.TotalCount))
                .ForMember(x => x.MemberOutputModels, y => y.MapFrom(o => o.memberDtos))
                .ForAllOtherMembers(x => x.Ignore());
        }
    }
}
