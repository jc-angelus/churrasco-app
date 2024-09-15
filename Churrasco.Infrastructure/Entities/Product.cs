
namespace Churrasco.Infrastructure.Entities { 

    public partial class Product
    {
        public uint Id { get; set; }

        public long Sku { get; set; }

        public int Code { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string Picture { get; set; } = null!;

        public decimal? Price { get; set; }

        public string? Currency { get; set; }
    }

}