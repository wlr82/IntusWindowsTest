using DAL.Entities;

namespace IntusWindowsTest.Client.Services.SubElementService
{
    public interface ISubElementService
    {
        Task<SubElement?> GetSubElementById(int id);
        Task UpdateSubElement(SubElement subElement);
        Task CreateSubElement(SubElement subElement);
        Task DeleteSubElement(int orderId, int windowId, SubElement subElement);
    }
}
