using System.ComponentModel.DataAnnotations;

namespace Blazor_Casa_Imoveis.Models.DTOs
{
    public class ImovelDTO
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="the field {0} is required")]
        public int Area { get; set; }
        [Required]
        public int Quartos { get; set; }
        [Required]
        public int Vagas { get; set; }
        public decimal Preco { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<ImovelImage> ImovelImages { get; set; }
        public List<string> UrlImagens { get; set; }

    }
}
