﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WalkToFlayApi.Repository.Models;
using WalkToFlayApi.Service.Dto;

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
                .ForMember(x => x.PassWord, y => y.MapFrom(o => o.PassWord))
                .ForMember(x => x.Email, y => y.MapFrom(o => o.Email))
                .ForMember(x => x.BirthDay, y => y.MapFrom(o => o.BirthDay))
                .ForMember(x => x.Sex, y => y.MapFrom(o => o.Sex))
                .ForMember(x => x.MobilePhone, y => y.MapFrom(o => o.MobilePhone))
                .ForMember(x => x.TelePhone, y => y.MapFrom(o => o.TelePhone))
                .ForMember(x => x.County, y => y.MapFrom(o => o.County))
                .ForMember(x => x.City, y => y.MapFrom(o => o.City))
                .ForMember(x => x.Address, y => y.MapFrom(o => o.Address))
                .ForAllOtherMembers(x => x.Ignore());
        }
    }
}