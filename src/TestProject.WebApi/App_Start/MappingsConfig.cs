using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestProject.Model;
using TestProject.Services.Contracts.Message;
using TestProject.Services.Contracts.Post;
using TestProject.Services.Contracts.User;

namespace TestProject.WebApi
{
    public static class MappingsConfig
    {
        public static void RegisterMappings()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>().ReverseMap();
                cfg.CreateMap<Post, PostDto>().ReverseMap();
                cfg.CreateMap<Message, MessageDto>().ReverseMap();
            });

            configuration.AssertConfigurationIsValid();

            configuration.CreateMapper();
        }
    }
}