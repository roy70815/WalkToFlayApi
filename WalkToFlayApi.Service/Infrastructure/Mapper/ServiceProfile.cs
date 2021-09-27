using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WalkToFlayApi.Common.Helpers;
using WalkToFlayApi.Repository.Models;
using WalkToFlayApi.Service.Dtos;

namespace WalkToFlayApi.Service.Infrastructure.Mapper
{
    /// <summary>
    /// Service層映射類別
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class ServiceProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceProfile"/> class.
        /// </summary>
        public ServiceProfile()
        {
            CreateMap<MemberParameterDto, MemberModel>();
            CreateMap<MemberModel, MemberDto>()
                .ForMember(x => x.MemberId, y => y.MapFrom(o => o.MemberId))
                .ForMember(x => x.FirstName, y => y.MapFrom(o => o.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(o => o.LastName))
                .ForMember(x => x.Email, y => y.MapFrom(o => o.Email))
                .ForMember(x => x.BirthDay, y => y.MapFrom(o => o.BirthDay))
                .ForMember(x => x.Sex, y => y.MapFrom(o => o.Sex))
                .ForMember(x => x.MobilePhone, y => y.MapFrom(o => o.MobilePhone))
                .ForMember(x => x.TelePhone, y => y.MapFrom(o => o.TelePhone))
                .ForMember(x => x.City, y => y.MapFrom(o => o.City))
                .ForMember(x => x.Area, y => y.MapFrom(o => o.Area))
                .ForMember(x => x.Address, y => y.MapFrom(o => o.Address))
                .ForAllOtherMembers(x => x.Ignore());

            CreateMap<SystemRoleUserModel, SystemRoleUserDto>();
            CreateMap<SystemFunctionDto, SystemFunctionModel>().ReverseMap();
            CreateMap<CityModel, CityDto>();
            CreateMap<AreaModel, AreaDto>();
            CreateMap<SystemFunctionDetailDto, SystemFunctionDetailModel>().ReverseMap();
            CreateMap<SystemFunctionModel, MenuDto>()
                .ForMember(x => x.FunctionId, y => y.MapFrom(o => o.FunctionId))
                .ForMember(x => x.FunctionName, y => y.MapFrom(o => o.FunctionName))
                .ForMember(x => x.FunctionChineseName, y => y.MapFrom(o => o.FunctionChineseName))
                .ForMember(x => x.Url, y => y.MapFrom(o => o.Url))
                .ForAllOtherMembers(x => x.Ignore());
            CreateMap<SystemFunctionDetailModel, SmallMenuDto>()
                .ForMember(x => x.FunctionDetailId, y => y.MapFrom(o => o.FunctionDetailId))
                .ForMember(x => x.FunctionDetailName, y => y.MapFrom(o => o.FunctionDetailName))
                .ForMember(x => x.FunctionDetailChineseName, y => y.MapFrom(o => o.FunctionDetailChineseName))
                .ForMember(x => x.Url, y => y.MapFrom(o => o.Url))
                .ForMember(x => x.FunctionId, y => y.MapFrom(o => o.FunctionId))
                .ForAllOtherMembers(x => x.Ignore());
        }
    }
}
