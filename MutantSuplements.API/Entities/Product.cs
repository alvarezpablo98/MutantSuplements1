using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace MutantSuplements.API.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        [JsonIgnore]
        [ForeignKey("CategoryId")]
        public ProductCategory Category { get; set; }
        public int CategoryId { get; set; }


    }
}
