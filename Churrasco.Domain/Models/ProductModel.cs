
using System.ComponentModel.DataAnnotations;

namespace Churrasco.Domain.Models
{
    /// <summary>
    /// Developer: Johans Cuellar
    /// Created: 13/09/2024
    /// Class: ProductModel
    /// </summary
    public class ProductModel
    {
        public uint Id { get; set; }
        [Required]
        public long Sku { get; set; }        
        public int Code { get; set; }
        [Required]
        public string Name { get; set; } = null!;        
        public string? Description { get; set; }                
        public string Picture { get; set; } = null!;
        [Required]        
        public decimal? Price { get; set; }        
        [Required]
        public string? Currency { get; set; }
    }

}