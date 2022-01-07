using AutoMapper;
using User.Api.Models.Request;
using User.Api.Models.Response;
using User.Core.Domain;
using User.Service.Dto;

namespace User.Api.Mapper
{
    public class UserMapProfile:Profile
    {
        public UserMapProfile()
        {
            CreateMap<PostUserRequest, UserDto>()
                .ReverseMap();

            CreateMap<UserDto, UserDomain>()
                .ReverseMap();

            CreateMap<UserDomain, PostUserResponse>()
                .ReverseMap();

            CreateMap<UserDomain, GetUserResponse>()
                .ReverseMap();

            CreateMap<UserDomain, GetUserResponseDto>()
                .ReverseMap();

            CreateMap<GetUserResponseDto, GetUserResponse>()
                .ReverseMap();
        }
    }
}
