using Blazor_Casa_Imoveis.Models.DTOs;

namespace Blazor_Casa_Imoveis.Repositories.IRepositories
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<CategoryDTO>> GetAll();
        public Task<CategoryDTO> GetById(int categoryId);
        public Task<bool> Create(CategoryDTO categoryDTO);
        public Task<CategoryDTO> Update(int Id,CategoryDTO categoryDTO);
        public Task<CategoryDTO> Exist(string categoryName);
        public Task<bool> Delete(int categoryId);
       // public Task<IEnumerable<CategoryDTO>> DropDown();

    }
}
