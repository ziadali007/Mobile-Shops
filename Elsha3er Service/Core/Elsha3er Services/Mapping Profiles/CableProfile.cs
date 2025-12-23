using AutoMapper;
using Elsha3er_Domain.Models;
using Elsha3er_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsha3er.Mapping_Profiles
{
    public class CableProfile : Profile
    {
        public CableProfile()
        {
            CreateMap<Cable, CableResultDto>().ReverseMap();

            CreateMap<AddCableResultDto, Cable>().ReverseMap();
        }
    }
}
