using DAL.Entities;

namespace IntusWindowsTest.Client.Services.ElementTypeService
{
    public interface IElementTypeService
    {
        List<ElementType> ElementTypes { get; set; }

        Task GetElementTypes();
    }
}
