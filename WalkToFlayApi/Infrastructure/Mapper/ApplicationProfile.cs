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

            CreateMap<MemberEditParameter, MemberParameterDto>()
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

            CreateMap<ProductParameter, ProductDto>()
                .ForMember(x => x.Name, y => y.MapFrom(o => o.Name))
                .ForMember(x => x.Description, y => y.MapFrom(o => o.Description))
                .ForMember(x => x.Price, y => y.MapFrom(o => o.Price))
                .ForMember(x => x.Status, y => y.MapFrom(o => o.Status))
                .ForAllOtherMembers(x => x.Ignore());

            CreateMap<ProductDto, ProductOutputModel>();
            CreateMap<ProductDetailDto, ProductDetailOutputModel>();
            CreateMap<ProductPageDto, ProductPageOutputModel>()
                .ForMember(x => x.Page, y => y.MapFrom(o => o.Page))
                .ForMember(x => x.TotalCount, y => y.MapFrom(o => o.TotalCount))
                .ForMember(x => x.ProductOutputModel, y => y.MapFrom(o => o.ProductDtos))
                .ForAllOtherMembers(x => x.Ignore());
        }
    }
}
