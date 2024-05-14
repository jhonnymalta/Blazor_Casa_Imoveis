using Blazor_Casa_Imoveis.Models.DTOs;

namespace Blazor_Casa_Imoveis.Repositories.IRepositories
{
    public interface IImovelRepository
    {
        public Task<IEnumerable<ImovelDTO>> GetAll();
        public Task<ImovelDTO> GetById(int imovelId);
        public Task<bool> Create(ImovelDTO imovelId);
        public Task<ImovelDTO> Update(int Id, ImovelDTO imovelId);        
        public Task<bool> Delete(int imovelId);
       // public Task<IEnumerable<CategoryDTO>> DropDown();

    }
}
