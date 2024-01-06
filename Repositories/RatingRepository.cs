using Entities.Models;
using Microsoft.EntityFrameworkCore;
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
            var ratings = _context.Ratings?.FromSqlInterpolated($"exec up_GetRatings {userid}");
            if (ratings is null)
            {
                return Enumerable.Empty<Rating>();
            }
            return ratings;
        }
        public IEnumerable<Rating>? GetFavouriteProductsByUser(string? userid, bool trackChanges)
        {
            var ratings = _context.Ratings?.FromSqlInterpolated($"exec up_GetFavouriteProducts {userid}");
            if (ratings is null)
            {
                return Enumerable.Empty<Rating>();
            }
            return ratings;
        }

        public IQueryable<Rating> GetRatedProducts()
        {
            IEnumerable<Rating> sql_result = Enumerable.Empty<Rating>();
            if (_context.Ratings is null)
            {
                return sql_result.AsQueryable<Rating>();
            }
            sql_result = _context.Ratings.FromSqlInterpolated($"select * from vw_RatedProducts");

            return sql_result.AsQueryable<Rating>();
        }
    }
}