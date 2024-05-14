using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blazor_Casa_Imoveis.Models
{
    public class ImovelImage
    {
        [Key]
        public int Id { get; set; }
        public int ImovelId { get; set; }
        public string UrlImovelImage { get; set; }
        [ForeignKey("ImovelId")]
        public virtual Imovel Imovel { get; set; }
    }
}
