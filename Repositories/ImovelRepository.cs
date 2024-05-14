using AutoMapper;
using Blazor_Casa_Imoveis.Data;
using Blazor_Casa_Imoveis.Models;
using Blazor_Casa_Imoveis.Models.DTOs;
using Blazor_Casa_Imoveis.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Blazor_Casa_Imoveis.Repositories
{
    public class ImovelRepository : IImovelRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ImovelRepository(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> Create(ImovelDTO imovelDTO)
        {
            Imovel newImovel = _mapper.Map<Imovel>(imovelDTO);
            newImovel.CreatedAt = DateTime.Now;
            await _context.Imoveis.AddAsync(newImovel);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int imovelId)
        {
            var imovel = _mapper.Map<Category>( await _context.Imoveis.FindAsync(imovelId));
            if(imovel != null)
            {
                _context.Categories.Remove(imovel);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

       

        public async Task<IEnumerable<ImovelDTO>> GetAll()
        {
            try
            {
                var imoveis = _mapper.Map<IEnumerable<ImovelDTO>>( _context.Imoveis.ToList());
                return _mapper.Map<IEnumerable<ImovelDTO>>(imoveis);
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<ImovelDTO> GetById(int imovelId)
        {
            try
            {
                var imovel = _mapper.Map<ImovelDTO>(await _context.Imoveis.FindAsync(imovelId));
                if(imovel == null) return null;
                    return imovel;
            }
            catch (Exception ex)
            {

                return null;
            }
            
        }

        public async Task<ImovelDTO> Update(int Id, ImovelDTO imovelDTO)
        {
            try {
                if(Id == imovelDTO.Id)
                {                  

                    var imovel = await _context.Imoveis.FindAsync(Id);
                    if (imovel != null)
                    {
                        imovel.Preco = imovelDTO.Preco;
                        imovel.Quartos = imovelDTO.Quartos;
                        imovel.UpdatedAt = DateTime.UtcNow;
                        await _context.SaveChangesAsync();
                        return _mapper.Map<ImovelDTO>(imovel);
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
