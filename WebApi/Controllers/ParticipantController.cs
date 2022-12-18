using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace WebApi.Controllers;

[ApiController]
[Route("controller")]

public class ParticipantController
{
    private readonly ParticipantService _participantService;
    public ParticipantController(ParticipantService participantService)
    {
        _participantService = participantService;
    }

    [HttpGet("GetParticipant")]
    public async Task<Response<List<GetParticipantDto>>> GetParticipant()
    {
        return await _participantService.GetParticipant();
    }

    [HttpPost("AddParticipant")]
    public async Task<Response<AddParticipantDto>> AddParticipant(AddParticipantDto participant)
    {
        return await _participantService.AddParticipant(participant);
    }

    [HttpPut("UpdateParticipant")]
    public async Task<Response<AddParticipantDto>> UpdateParticipant(AddParticipantDto participant)
    {
        return await _participantService.UpdateParticipant(participant);
    }

    [HttpDelete("DeleteParticipant")]
    public async Task<Response<string>> DeleteParticipant(int id)
    {
        return  await _participantService.DeleteParticipant(id);
    }
}