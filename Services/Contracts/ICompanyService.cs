using Entities.Dtos;
using Entities.Models;

namespace Services.Contracts
{
    public interface ICompanyService
    {
        IEnumerable<Company> GetCompanies(bool trackChanges);

        public Company? GetOneCompany(int companyID, bool trackChanges);
        public void CreateCompany(CompanyDto companyDto);

        public void DeleteCompany(Company company);

        public void SaveCompany(Company company);

        public IQueryable<Company> GetMostGrossingCompaniesThisWeek();

        public void AcceptApplication(Company company);

        public void RejectApplication(Company company);

    }
}