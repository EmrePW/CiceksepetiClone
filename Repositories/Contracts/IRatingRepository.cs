using Entities.Models;

namespace Repositories.Contracts
{
    public interface IRatingRepository : IRepositoryBase<Rating>
    {
        public IEnumerable<Rating>? GetRatingsByUser(String? userid, bool trackChanges);

        public IEnumerable<Rating>? GetRatingsByProduct(int productId, bool trackChanges);

        Rating? GetOneRating(string user_id, int product_id, bool trackChanges);

    }
}