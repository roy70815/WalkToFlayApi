using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkToFlayApi.Models.Input;
using WalkToFlayApi.Service.Dto;

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
        }
    }
}
