using AutoMapper;
using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<ResponseDTO, SystemStatus>()
.ForMember(dest => dest.Id, opt => opt.Ignore()) 
.ForMember(dest => dest.PlataformName, opt => opt.MapFrom(src => src.PlataformName)) 
.ReverseMap(); 
        }
    }
}
