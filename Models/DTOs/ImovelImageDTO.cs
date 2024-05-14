using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blazor_Casa_Imoveis.Models
{
    public class ImovelImageDTO
    {
        
        public int Id { get; set; }
        public int ImovelId { get; set; }
        public string UrlImovelImage { get; set; }       
        
    }
}
