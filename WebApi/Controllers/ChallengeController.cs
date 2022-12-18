using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("controller")]

public class ChallengeController
{
    private readonly ChallengeService _challengeService;
    public ChallengeController(ChallengeService challengeService)
    {
        _challengeService = challengeService;
    }

    [HttpGet("GetChallenge")]
    public async Task<Response<List<GetChallengeDto>>> GetChallenge()
    {
        return await _challengeService.GetChallenge();
    }

    [HttpPost("AddChallenge")]
    public async Task<Response<AddChallengeDto>> AddChallenge(AddChallengeDto challenge)
    {
        return await _challengeService.AddChallenge(challenge);
    }

    [HttpPut("UpdateChallenge")]
    public async Task<Response<AddChallengeDto>> UpdateChallenge(AddChallengeDto challenge)
    {
        return await _challengeService.UpdateChallenge(challenge);
    }

    [HttpDelete("DeleteChallenge")]
    public async Task<Response<string>> DeleteChallenge(int id)
    {
        return await _challengeService.DeleteChallenge(id);
    }
}