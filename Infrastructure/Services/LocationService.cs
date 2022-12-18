using Domain.Entities;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Context;
using Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Net;

namespace Infrastructure.Services;

public class LocationService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public LocationService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<GetLocationDto>>> GetLocation()
    {
      try
      {
         var list = _mapper.Map<List<GetLocationDto>>(_context.Locations.ToList());
        return new Response<List<GetLocationDto>>(list);
      }
      catch(Exception ex)
      {
         return new Response<List<GetLocationDto>>(HttpStatusCode.InternalServerError, ex.Message);
      }
        
    }
     public async Task<Response<AddLocationDto>> AddLocation(AddLocationDto location)
     {
      try
      {
          var newLocation = _mapper.Map<Location>(location);
        _context.Locations.Add(newLocation);
        await _context.SaveChangesAsync();
        return new Response<AddLocationDto>(location);
      }
      catch(Exception ex)
      {
         return new Response<AddLocationDto>(HttpStatusCode.InternalServerError, ex.Message);
      }
       
     }

     public async Task<Response<AddLocationDto>> UpdateLocation(AddLocationDto location)
     {
      try
      {
         var find = await _context.Locations.FindAsync(location.LocationId);
        find.LocationId = location.LocationId;
        find.Name = location.Name;
        find.Description = location.Description;
        await _context.SaveChangesAsync();
        return new Response<AddLocationDto>(location);
      }
      catch(Exception ex)
      {
         return new Response<AddLocationDto>(HttpStatusCode.InternalServerError, ex.Message);
      }
        
     }

     public async Task<Response<string>> DeleteLocation(int id)
     {
      try
      {
          var find = await _context.Locations.FindAsync(id);
        _context.Locations.Remove(find);
        await _context.SaveChangesAsync();
        return new Response<string>("Location succesfully deleted");
      }
      catch(Exception ex)
      {
         return new Response<string>(HttpStatusCode.InternalServerError, ex.Message);
      }
       
     }
}