using Domain.Entities;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Context;
using Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Net;

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
      try
      {
         var list = _mapper.Map<List<GetChallengeDto>>(_context.Challenges.ToList());
         return new Response<List<GetChallengeDto>>(list);
      }
      catch(Exception ex)
      {
         return new Response<List<GetChallengeDto>>(HttpStatusCode.InternalServerError, ex.Message);
      }
        
    }
     public async Task<Response<AddChallengeDto>> AddChallenge(AddChallengeDto challenge)
     {
      try
      {
         var newChallenge = _mapper.Map<Challenge>(challenge);
        _context.Challenges.Add(newChallenge);
        await _context.SaveChangesAsync();
        return new Response<AddChallengeDto>(challenge);
      }
      catch(Exception ex)
      {
         return new Response<AddChallengeDto>(HttpStatusCode.InternalServerError, ex.Message);
      }
     }

     public async Task<Response<AddChallengeDto>> UpdateChallenge(AddChallengeDto challenge)
     {
      try
      {
         var find = await _context.Challenges.FindAsync(challenge.ChallengeId);
        find.ChallengeId = challenge.ChallengeId;
        find.Title = challenge.Title;
        find.Description = challenge.Description;
        await _context.SaveChangesAsync();
        return new Response<AddChallengeDto>(challenge);
      }
      catch(Exception ex)
      {
         return new Response<AddChallengeDto>(HttpStatusCode.InternalServerError, ex.Message);
      }
        
     }

     public async Task<Response<string>> DeleteChallenge(int id)
     {
      try
      {
         var find = await _context.Challenges.FindAsync(id);
        _context.Challenges.Remove(find);
        await _context.SaveChangesAsync();
        return new Response<string>("Challenge succesfully deleted");
      }
      catch(Exception ex)
      {
         return new Response<string>(HttpStatusCode.InternalServerError, ex.Message);
      }
        
     }
}