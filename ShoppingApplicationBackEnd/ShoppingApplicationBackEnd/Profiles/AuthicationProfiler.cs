using AutoMapper;
using ShoppingApplicationBackEnd.DTOS;
using ShoppingApplicationBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingApplicationBackEnd.Profiles
{
    public class AuthicationProfiler:Profile
    {
        public AuthicationProfiler()
        {
            CreateMap<UsersSignUpDTO, User>()
                .ForMember(a => a.Email, c => c.MapFrom(a => a.Email))
                .ForMember(a => a.IsActive, a => a.MapFrom(a => true))
                .ForMember(a => a.Phone, a => a.MapFrom(a => a.Phone))
                .ForMember(a => a.UserName, a => a.MapFrom(a => a.UserName));

            CreateMap<User, UserLoginDTO>();
                
        }
    }
}
