﻿using AutoMapper;
using WebService.DataService.DTO;
using WebService.DTOs;
namespace WebService.Resolvers
{
    public class UserNameResolver : IValueResolver<Users, UserDto, string>
    {
        public string Resolve(Users source, UserDto destination, string member, ResolutionContext context)
        {
            return source.Name;
        }
    }
}