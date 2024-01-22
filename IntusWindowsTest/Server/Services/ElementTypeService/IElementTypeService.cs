using DAL.Entities;

namespace IntusWindowsTest.Server.Services.ElementTypeService
{
    public interface IElementTypeService
    {
        Task<List<ElementType>> GetElemetTypes();
    }
}
