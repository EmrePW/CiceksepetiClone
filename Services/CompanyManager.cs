using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class CompanyManager : ICompanyService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public CompanyManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void CreateCompany(CompanyDto companyDto)
        {
            Company? company = _mapper.Map<Company>(companyDto);
            _manager.Company.CreateEntity(company);
            _manager.Save();
        }

        public IEnumerable<Company> GetCompanies(bool trackChanges)
        {
            return _manager.Company.GetAll(trackChanges);
        }

        public Company? GetOneCompany(int companyID, bool trackChanges)
        {
            return _manager.Company.GetByCondition(company => company.CompanyID.Equals(companyID), trackChanges);
        }
    }
}