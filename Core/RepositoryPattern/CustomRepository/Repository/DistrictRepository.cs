using Core.Domain;
using Core.RepositoryPattern.CustomRepository.Interfaces;
using Core.RepositoryPattern.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Core.RepositoryPattern.CustomRepository.Repository;

public class DistrictRepository : GenericRepository<District>, IDistrictRepository
{
    internal DistrictRepository(DbContext context) : base(context)
    {
    }
    
    public District GetDistrict(int id) => GetEntity(c => c.Id == id, c => c.DeliveryMens);
}