using AutoMapper;
using TestProject.Model;
using TestProject.Services.Contracts.Message;
using TestProject.Services.Contracts.Post;
using TestProject.Services.Contracts.User;

namespace TestProject.Services.Mapper
{
    public static class MappingsConfig
    {
        private static IMapper _mapper;

        public static IMapper Mapper
        {
            get
            {
                return _mapper;
            }
        }

        public static void RegisterMappings()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>().ReverseMap();
                cfg.CreateMap<Post, PostDto>().ReverseMap();
                cfg.CreateMap<Message, MessageDto>().ReverseMap();
            });

            configuration.AssertConfigurationIsValid();

            _mapper = configuration.CreateMapper();
        }
    }
}