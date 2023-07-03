using System.Collections.Generic;
using Backend.Dto.District;
using Backend.Services.Interfaces;
using Core.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class DistrictController : ControllerBase
{
    private readonly IDistrictService _districtService;

    public DistrictController(IDistrictService districtService) => _districtService = districtService;

    [HttpGet]
    [Route("get-districts")]
    [Authorize(Roles = Role.Admin)]
    public async Task<IEnumerable<DistrictDto>> Get() => await _districtService.GetEntities();

    [HttpPost]
    [Route("get-district/{id:int}")]
    [Authorize(Roles = Role.Admin)]
    public async Task<DistrictDto> Get(int id) => await _districtService.GetEntity(id);

    [HttpPost]
    [Route("send-district")]
    [Authorize(Roles = Role.Admin)]
    public void PostDistrict(DistrictDto dto) => _districtService.PostEntity(dto);

    [HttpDelete]
    [Route("delete-district/{id:int}")]
    [Authorize(Roles = Role.Admin)]
    public void DeleteDistrict(int id) => _districtService.PostDelete(id);
}