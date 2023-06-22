using System.Collections.Generic;
using Backend.Dto.District;
using Backend.Services.Interfaces;
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
    public IEnumerable<DistrictDto> Get() => _districtService.GetEntities();

    [HttpPost]
    [Route("get-district/{id:int}")]
    public DistrictDto Get(int id) => _districtService.GetEntity(id);

    [HttpPost]
    [Route("send-district")]
    public void PostDistrict(DistrictDto dto) => _districtService.PostEntity(dto);

    [HttpDelete]
    [Route("delete-district/{id:int}")]
    public void DeleteDistrict(int id) => _districtService.PostDelete(id);
}