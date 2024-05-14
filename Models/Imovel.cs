using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blazor_Casa_Imoveis.Models
{
    public class Imovel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Area { get; set; }
        [Required]
        public int Quartos { get; set; }
        [Required]
        public int Vagas { get; set; }
        public decimal Preco { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        //Relationship
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public virtual ICollection<ImovelImage> ImovelImages { get; set; }
    }
}
