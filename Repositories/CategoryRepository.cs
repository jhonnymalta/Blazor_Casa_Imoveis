using AutoMapper;
using Blazor_Casa_Imoveis.Data;
using Blazor_Casa_Imoveis.Models;
using Blazor_Casa_Imoveis.Models.DTOs;
using Blazor_Casa_Imoveis.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Blazor_Casa_Imoveis.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Create(CategoryDTO categoryDTO)
        {
            Category newCategory = _mapper.Map<Category>(categoryDTO);
            newCategory.CreatedAt = DateTime.Now;
            await _context.Categories.AddAsync(newCategory);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int categoryId)
        {
            var category = _mapper.Map<Category>( await _context.Categories.FindAsync(categoryId));
            if(category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<CategoryDTO> Exist(string categoryName)
        {
            try
            {
                return _mapper.Map<CategoryDTO>(await _context.Categories.FirstOrDefaultAsync(c => c.Name.ToLower() == categoryName.ToLower()));
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            try
            {
                var categories = _mapper.Map<IEnumerable<CategoryDTO>>( _context.Categories.ToList());
                return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<CategoryDTO> GetById(int categoryId)
        {
            try
            {
                var category = _mapper.Map<CategoryDTO>(await _context.Categories.FindAsync(categoryId));
                if(category == null) return null;
                    return category;
            }
            catch (Exception ex)
            {

                return null;
            }
            
        }

        public async Task<CategoryDTO> Update(int Id, CategoryDTO categoryDTO)
        {
            try {
                if(Id == categoryDTO.Id)
                {                  

                    var category = await _context.Categories.FindAsync(Id);
                    if (category != null)
                    {
                        category.Name = categoryDTO.Name;
                        category.Description = categoryDTO.Description;
                        category.UpdatedAt = DateTime.UtcNow;
                        await _context.SaveChangesAsync();
                        return _mapper.Map<CategoryDTO>(category);
                    }
                    else
                    {
                        return null;
                    }
                    

                }
                else
                {
                    return null;
                }
                
            }
            catch(Exception ex) {
                return null;
            }
        }
    }
}
