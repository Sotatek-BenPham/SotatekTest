using AutoMapper;
using SotatekTest.Application.Dtos.User;
using SotatekTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SotatekTest.Application.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<InsertUserDto, User>();
        }
    }
}
