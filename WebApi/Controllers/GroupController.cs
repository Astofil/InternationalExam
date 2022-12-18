using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("controller")]

public class GroupController
{
    private readonly GroupService _groupService;
    public GroupController(GroupService groupService)
    {
        _groupService = groupService;
    }

    [HttpGet]
    public async Task<Response<List<GetGroupDto>>> GetGroup()
    {
        return await _groupService.GetGroup();
    }

    [HttpPost("AddGroup")]
    public async Task<Response<AddGroupDto>> AddGroup(AddGroupDto group)
    {
        return await _groupService.AddGroup(group);
    }

    [HttpPut("UpdateGroup")]
    public async Task<Response<AddGroupDto>> UpdateGroup(AddGroupDto group)
    {
        return await _groupService.UpdateGroup(group);
    }

    [HttpDelete("DeleteGroup")]
    public async Task<Response<string>> DeleteGroup(int id)
    {
        return await _groupService.DeleteGroup(id);
    }
}