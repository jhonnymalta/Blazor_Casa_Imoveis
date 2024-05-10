using System.ComponentModel.DataAnnotations;

namespace Blazor_Casa_Imoveis.Models.DTOs
{
    public class CategoryDTO
    {
        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
       
    }
}
