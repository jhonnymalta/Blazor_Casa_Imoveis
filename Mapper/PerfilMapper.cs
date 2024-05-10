using AutoMapper;
using Blazor_Casa_Imoveis.Models;
using Blazor_Casa_Imoveis.Models.DTOs;

namespace Blazor_Casa_Imoveis.Mapper
{
    public class PerfilMapper: Profile
    {
        public PerfilMapper()
        {
            CreateMap<CategoryDTO, Category>().ReverseMap();
        }
    }
}
