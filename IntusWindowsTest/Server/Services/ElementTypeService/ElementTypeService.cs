using DAL.Entities;
using DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace IntusWindowsTest.Server.Services.ElementTypeService
{
    public class ElementTypeService : IElementTypeService
    {
        private readonly IUnitOfWork _uow;

        public ElementTypeService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<ElementType>> GetElemetTypes()
        {
            return await _uow.ElementTypes.GetAll().ToListAsync();
        }
    }
}
