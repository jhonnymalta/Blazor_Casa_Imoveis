using AutoMapper;
using Blazor_Casa_Imoveis.Data;
using Blazor_Casa_Imoveis.Models;
using Blazor_Casa_Imoveis.Models.DTOs;
using Blazor_Casa_Imoveis.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Blazor_Casa_Imoveis.Repositories
{
    public class ImovelImageRepository : IImovelImageRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ImovelImageRepository(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Create(ImovelImageDTO imovelImage)
        {
            ImovelImage image = _mapper.Map<ImovelImage>(imovelImage);
            await _context.ImovelImages.AddAsync(image);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> delete(int imovelImageId)
        {
            var image = _mapper.Map<ImovelImage>(await _context.ImovelImages.FindAsync(imovelImageId));
            if(image != null)
            {
                _context.ImovelImages.Remove(image);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> deleteAllImovelImage(int imovelId)
        {
            var listaImage = await _context.ImovelImages.Where(x => x.Id == imovelId).ToListAsync();
            _context.ImovelImages.RemoveRange(listaImage);            
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ImovelImageDTO>> GetAll(int imovelId)
        {
            try
            {
                return _mapper.Map<IEnumerable<ImovelImageDTO>>(await _context.ImovelImages.Where(x => x.ImovelId == imovelId).ToListAsync());
            }
            catch (Exception)
            {

                return null;
            }
            
        }
    }
}
