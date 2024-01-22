using DAL.Entities;
using DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace IntusWindowsTest.Server.Services.ElementTypeService
{
    public class ElementTypeService : IElementTypeService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public ElementTypeService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<List<ElementType>> GetElemetTypes()
        {
            List<ElementType> result = new();
            using (var uow = _unitOfWorkFactory.MakeUnitOfWork())
            {
                result = await uow.ElementTypes.GetAll().ToListAsync();
            }
            return result;
        }
    }
}
