using Entities.Dtos;
using Entities.Models;

namespace Services.Contracts
{
    public interface IRatingService
    {
        public IEnumerable<Rating>? GetByUser(string? userid, bool trackChanges);
        public IEnumerable<Rating>? GetByProduct(int productid, bool trackChanges);

        public IEnumerable<Rating> GetAllRatings(bool trackChanges);

        // public IEnumerable<Rating> GetByCompany()

        public Rating? GetOneRating(string user_id, int product_id, bool trackChanges);

        public void CreateRating(RatingDtoForInsertion ratingDto);

        public void UpdateRating(RatingDtoForUpdate ratingDto);

    }
}