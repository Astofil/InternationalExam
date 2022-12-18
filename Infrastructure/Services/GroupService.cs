using Domain.Entities;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Context;
using Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Net;

namespace Infrastructure.Services;

public class GroupService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public GroupService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<GetGroupDto>>> GetGroup()
    {
      try
      {
         var list = _mapper.Map<List<GetGroupDto>>(_context.Groups.ToList());
         return new Response<List<GetGroupDto>>(list);
      }
      catch(Exception ex)
      {
         return new Response<List<GetGroupDto>>(HttpStatusCode.InternalServerError, ex.Message);
      }
        
    }
     public async Task<Response<AddGroupDto>> AddGroup(AddGroupDto group)
     {
      try
      {
         var newGroup = _mapper.Map<Group>(group);
        _context.Groups.Add(newGroup);
        await _context.SaveChangesAsync();
        return new Response<AddGroupDto>(group);
      }
        catch(Exception ex)
        {
         return new Response<AddGroupDto>(HttpStatusCode.InternalServerError, ex.Message);
        }
     }

     public async Task<Response<AddGroupDto>> UpdateGroup(AddGroupDto group)
     {
      try
      {
         var find = await _context.Groups.FindAsync(group.GroupId);
        find.GroupId = group.GroupId;
        find.GroupNick = group.GroupNick;
        find.ChallengeId = group.ChallengeId;
        find.NeedMember = group.NeedMember;
        find.TeamSloGan = group.TeamSlogan;
        find.CreatedAt = group.CreatedAt;
        await _context.SaveChangesAsync();
        return new Response<AddGroupDto>(group);
      }
      catch(Exception ex)
      {
         return new Response<AddGroupDto>(HttpStatusCode.InternalServerError, ex.Message);
      }
        
     }

     public async Task<Response<string>> DeleteGroup(int id)
     {
      try
      {
         var find = await _context.Groups.FindAsync(id);
        _context.Groups.Remove(find);
        await _context.SaveChangesAsync();
        return new Response<string>("Group succesfully deleted");
      }
      catch (Exception ex)
      {
         return new Response<string>(HttpStatusCode.InternalServerError, ex.Message);
      }
        
     }
}