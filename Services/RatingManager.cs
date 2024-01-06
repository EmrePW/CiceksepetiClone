using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class RatingManager : IRatingService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public RatingManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }


        public IEnumerable<Rating>? GetByProduct(int productid, bool trackChanges)
        {
            return _manager.Ratings.GetRatingsByProduct(productid, trackChanges);
        }

        public IEnumerable<Rating>? GetByUser(string? userid, bool trackChanges)
        {
            return _manager.Ratings.GetRatingsByUser(userid, trackChanges);
        }

        public Rating? GetOneRating(string user_id, int product_id, bool trackChanges)
        {
            var rating = _manager.Ratings.GetOneRating(user_id, product_id, trackChanges);
            return rating;
        }

        public void CreateRating(RatingDtoForInsertion ratingDto)
        {
            var rating = _mapper.Map<Rating>(ratingDto);
            _manager.Ratings.CreateEntity(rating);
            _manager.Save();
        }
        public void UpdateRating(RatingDtoForUpdate ratingDto)
        {
            var rating = _mapper.Map<Rating>(ratingDto);
            _manager.Ratings.UpdateEntity(rating);
            _manager.Save();
        }

        public IEnumerable<Rating> GetAllRatings(bool trackChanges)
        {
            IEnumerable<Rating>? ratings = _manager.Ratings.GetAll(trackChanges);
            if (ratings is null)
            {
                ratings = Enumerable.Empty<Rating>();
            }
            return ratings;
        }

        public IQueryable<Rating> GetRatedProducts()
        {
            return _manager.Ratings.GetRatedProducts();
        }
    }
}