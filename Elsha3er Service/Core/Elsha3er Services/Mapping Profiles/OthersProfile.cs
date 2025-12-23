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
    public class OthersProfile : Profile
    {
        public OthersProfile()
        {
            CreateMap<AddOthersResultDto, Others>().ReverseMap();


            CreateMap<OthersResultDto, Others>().ReverseMap();
              
        }
    }
}
