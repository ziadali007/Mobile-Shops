using AutoMapper;
using Elsha3er_Domain.Models;
using Elsha3er_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsha3er_Services.Mapping_Profiles
{
    public class CoverProfile : Profile
    {
        public CoverProfile()
        {
            CreateMap<Cover, CoverResultDto>().ReverseMap();

            CreateMap<AddCoverResultDto, Cover>().ReverseMap();
        }
    }
}
