using Entities.Models;

namespace Repositories.Contracts
{
    public interface ICompanyRepository : IRepositoryBase<Company>
    {
        public IQueryable<Company> GetMostGrossingCompaniesThisWeek();

        public void AcceptApplication(Company company);

        public void RejectApplication(Company company);

    }
}