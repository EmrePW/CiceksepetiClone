using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories
{
    public sealed class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext context) : base(context)
        {
        }


        public IQueryable<Company> GetMostGrossingCompaniesThisWeek()
        {
            var result = _context.Companies.FromSqlInterpolated($"exec up_GetMostGrossingCompaniesThisWeek");
            return result;
        }

        public void AcceptApplication(Company company)
        {
            _context.Database.ExecuteSqlInterpolated($"exec AcceptCompanyApp {company.CompanyID}");
            _context.SaveChanges();
        }
        public void RejectApplication(Company company)
        {
            _context.Database.ExecuteSqlInterpolated($"exec RejectCompanyApp {company.CompanyID}");
            _context.SaveChanges();
        }

    }
}