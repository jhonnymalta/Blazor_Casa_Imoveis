using Blazor_Casa_Imoveis.Models;

namespace Blazor_Casa_Imoveis.Repositories.IRepositories
{
    public interface IImovelImageRepository
    {
        public Task<bool> Create(ImovelImageDTO imovelImage);
        public Task<bool> delete(int imovelImageId);
        public Task<bool> deleteAllImovelImage(int imovelId);
        public Task<IEnumerable<ImovelImageDTO>> GetAll(int imovelId);
    }
}
