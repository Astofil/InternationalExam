using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

namespace Infrastructure.Mapper;

public class ServiceProfile:Profile
{
    public ServiceProfile()
    {
        CreateMap<Participant, GetParticipantDto>();
        CreateMap<AddParticipantDto, Participant>();
        CreateMap<Group, GetGroupDto>();
        CreateMap<AddGroupDto, Group>();
        CreateMap<Location, GetLocationDto>();
        CreateMap<AddLocationDto, Location>();
        CreateMap<Challenge, GetChallengeDto>();
        CreateMap<AddChallengeDto, Challenge>();
    }
}