using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Infrastructure.Services;

public class ParticipantService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public ParticipantService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<GetParticipantDto>>> GetParticipant()
    {
        // var list = _mapper.Map<List<GetParticipantDto>>(_context.Participants.ToList());

        var list = await _context.Participants.Select(t => new GetParticipantDto()
        {
            ParticipantId = t.Participantid,
            FullName = t.Fullname,
            Email = t.Email,
            Phone = t.Phone,
            Password = t.Password,
            CreatedAt = t.CreatedAt,
            GroupId = t.GroupId,
            GroupNick = t.Group.GroupNick,
            ChallengedId = t.Group.ChallengeId,
            NeedMember = t.Group.NeedMember,
            TeamSlogan = t.Group.TeamSloGan,
            GroupCreatedAt = t.Group.CreatedAt,
            LocationId = t.LocationId,
            Name = t.Location.Name,
            Description = t.Location.Description,
        }).ToListAsync();
        return new Response<List<GetParticipantDto>>(list);
    }

    public async Task<Response<AddParticipantDto>> AddParticipant(AddParticipantDto participant)
    {
        // var response = _mapper.Map<GetParticipantDto>(participant);
        var newParticipant = _mapper.Map<Participant>(participant);
        _context.Participants.Add(newParticipant);
        await _context.SaveChangesAsync();
        return new Response<AddParticipantDto>(participant);
    }

    public async Task<Response<AddParticipantDto>> UpdateParticipant(AddParticipantDto participant)
    {
        // var response = _mapper.Map<GetParticipantDto>(participant);
          var find = await _context.Participants.FindAsync(participant.ParticipantId);
          find.Participantid = participant.ParticipantId;
          find.Fullname = participant.Fullname;
          find.Email = participant.Email;
          find.Phone = participant.Email;
          find.Password = participant.Password;
          find.CreatedAt = participant.CreatedAt;
          find.GroupId = participant.GroupId;
          find.LocationId = participant.LocationId;
          await _context.SaveChangesAsync();
          return new Response<AddParticipantDto>(participant);
    }

    public async Task<Response<string>> DeleteParticipant(int id)
    {
        var find = await _context.Participants.FindAsync(id);
        _context.Participants.Remove(find);
        await _context.SaveChangesAsync();
        return new Response<string>("Participant succesfully deleted");
    }
}
