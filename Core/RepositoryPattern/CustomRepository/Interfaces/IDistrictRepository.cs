using Core.Domain;
using Core.RepositoryPattern.GenericRepository;

namespace Core.RepositoryPattern.CustomRepository.Interfaces;

public interface IDistrictRepository : IGenericRepository<District>
{
    District GetDistrict(int id);
}