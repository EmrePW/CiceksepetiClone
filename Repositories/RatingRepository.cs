using Entities.Models;
using Repositories.Contracts;

namespace Repositories
{
    public sealed class RatingRepository : RepositoryBase<Rating>, IRatingRepository
    {
        public RatingRepository(RepositoryContext context) : base(context)
        {
        }


        public Rating? GetOneRating(string user_id, int product_id, bool trackChanges)
        {
            var rating = GetAll(trackChanges).Where(rating => rating.UserID.Equals(user_id)).Where(rating => rating.ProductID.Equals(product_id)).FirstOrDefault();
            return rating;
        }

        public IEnumerable<Rating>? GetRatingsByProduct(int productId, bool trackChanges)
        {
            var ratings = GetAll(trackChanges).Where(rating => rating.ProductID.Equals(productId)).ToList();
            if (ratings is null)
            {
                return Enumerable.Empty<Rating>();
            }
            return ratings;

        }

        public IEnumerable<Rating>? GetRatingsByUser(string? userid, bool trackChanges)
        {
            var ratings = GetAll(trackChanges).Where(rating => rating.UserID.Equals(userid)).ToList();
            if (ratings is null)
            {
                return Enumerable.Empty<Rating>();
            }
            return ratings;
        }
    }
}