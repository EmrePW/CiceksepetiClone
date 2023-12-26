namespace Entities.Dtos
{
    public record RatingDto
    {
        public long RatingID { get; init; }
        public String? username { get; init; }

        public String? UserID { get; set; } = String.Empty;

        public int ProductID { get; init; }

        public DateTime RatedAt { get; init; } = DateTime.Now;

        public bool? IsFavourite { get; init; }

        public String? RatingValue { get; init; }

        public String? Opinion { get; init; }

    }
}