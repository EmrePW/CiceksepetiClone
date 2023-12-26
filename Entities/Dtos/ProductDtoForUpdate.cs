namespace Entities.Dtos
{
    public record ProductDtoForUpdate : ProductDto
    {
        public int? UnitsInStock { get; init; }

        public decimal? DiscountedPrice { get; init; }

        public bool FreeShip { get; set; }

    }
}