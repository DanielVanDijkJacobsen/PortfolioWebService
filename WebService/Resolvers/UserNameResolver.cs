using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IMDBDataService.Objects;
using WebService.DTOs;

namespace WebService.Resolvers
{
    public class UserNameResolver : IValueResolver<Users, UserDto, string>
    {
        public string Resolve(Users source, UserDto destination, string member, ResolutionContext context)
        {
            return source.user_name;
        }
    }
}
