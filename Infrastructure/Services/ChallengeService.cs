using Domain.Entities;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Context;
using Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Infrastructure.Services;

public class ChallengeService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public ChallengeService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<GetChallengeDto>>> GetChallenge()
    {
        var list = _mapper.Map<List<GetChallengeDto>>(_context.Challenges.ToList());
        return new Response<List<GetChallengeDto>>(list);
    }
     public async Task<Response<AddChallengeDto>> AddChallenge(AddChallengeDto challenge)
     {
        var newChallenge = _mapper.Map<Challenge>(challenge);
        _context.Challenges.Add(newChallenge);
        await _context.SaveChangesAsync();
        return new Response<AddChallengeDto>(challenge);
     }

     public async Task<Response<AddChallengeDto>> UpdateChallenge(AddChallengeDto challenge)
     {
        var find = await _context.Challenges.FindAsync(challenge.ChallengeId);
        find.ChallengeId = challenge.ChallengeId;
        find.Title = challenge.Title;
        find.Description = challenge.Description;
        await _context.SaveChangesAsync();
        return new Response<AddChallengeDto>(challenge);
     }

     public async Task<Response<string>> DeleteChallenge(int id)
     {
        var find = await _context.Challenges.FindAsync(id);
        _context.Challenges.Remove(find);
        await _context.SaveChangesAsync();
        return new Response<string>("Challenge succesfully deleted");
     }
}