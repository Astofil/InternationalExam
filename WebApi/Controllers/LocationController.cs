using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("controller")]

public class LocationController
{
    private readonly LocationService _locationService;
    public LocationController(LocationService locationService)
    {
        _locationService = locationService;
    }

    [HttpGet("GetLocation")]
    public async Task<Response<List<GetLocationDto>>> GetLocation()
    {
        return await _locationService.GetLocation();
    }

    [HttpPost("AddLocation")]
    public async Task<Response<AddLocationDto>> AddLocation(AddLocationDto location)
    {
        return await _locationService.AddLocation(location);
    }

    [HttpPut("UpdateLocation")]
    public async Task<Response<AddLocationDto>> UpdateLocation(AddLocationDto location)
    {
        return await _locationService.UpdateLocation(location);
    }

    [HttpDelete("DeleteLocation")]
    public async Task<Response<string>> DeleteLocation(int id)
    {
        return await _locationService.DeleteLocation(id);
    }
}