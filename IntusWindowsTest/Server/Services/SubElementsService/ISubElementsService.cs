using DAL.Entities;

namespace IntusWindowsTest.Server.Services.SubElementsService
{
    public interface ISubElementsService
    {
        Task<SubElement?> GetSubElementById(int subElementId, CancellationToken cancellationToken);
        Task<SubElement?> UpdateSubElement(SubElement subElement, CancellationToken cancellationToken);
        Task<SubElement?> CreateSubElement(SubElement subElement, CancellationToken cancellationToken);
        Task<bool> DeleteSubElement(int subElementId, CancellationToken cancellationToken);
    }
}
