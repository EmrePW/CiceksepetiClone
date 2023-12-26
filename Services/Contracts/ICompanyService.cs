using Entities.Dtos;
using Entities.Models;

namespace Services.Contracts
{
    public interface ICompanyService
    {
        IEnumerable<Company> GetCompanies(bool trackChanges);

        public Company? GetOneCompany(int companyID, bool trackChanges);
        public void CreateCompany(CompanyDto companyDto);
    }
}