using DAL.Repositories.Contracts;
using SubElement = DAL.Entities.SubElement;

namespace IntusWindowsTest.Server.Services.SubElementsService
{
    public class SubElementsService : ISubElementsService
    {
        private readonly IUnitOfWork _uow;

        public SubElementsService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<SubElement?> GetSubElementById(int subElementId, CancellationToken cancellationToken)
        {
            return await _uow.SubElements.GetByIdAsync(subElementId, cancellationToken);
        }

        public async Task<SubElement?> CreateSubElement(SubElement subElement, CancellationToken cancellationToken)
        {
            var dbWindow = await _uow.Windows.GetByIdAsync(subElement.Window.Id, cancellationToken);
            var dbElementType = await _uow.ElementTypes.GetByIdAsync(subElement.ElementType.Id, cancellationToken);
            if (dbWindow == null || dbElementType == null)
                return null;

            var entSubElement = new SubElement()
            {
                Element = subElement.Element,
                Width = subElement.Width,
                Height = subElement.Height,
                ElementType = dbElementType,
                Window = dbWindow
            };

            var dbSubElement = await _uow.SubElements.AddAndReturnEntityAsync(entSubElement, cancellationToken);
            await _uow.CompleteAsync(cancellationToken);
            return dbSubElement;
        }

        public async Task<bool> DeleteSubElement(int subElementId, CancellationToken cancellationToken)
        {
            var result = await _uow.SubElements.DeleteByIdAsync(subElementId, cancellationToken);
            if (!result)
                return false;

            await _uow.CompleteAsync(cancellationToken);
            return true;
        }

        public async Task<SubElement?> UpdateSubElement(SubElement subElement, CancellationToken cancellationToken)
        {
            var dbSubElement = await _uow.SubElements.GetByIdAsync(subElement.Id, cancellationToken);
            var dbElementType = await _uow.ElementTypes.GetByIdAsync(subElement.ElementType.Id, cancellationToken);

            if (dbSubElement == null)
                return null;

            dbSubElement.Element = subElement.Element;
            dbSubElement.Width = subElement.Width;
            dbSubElement.Height = subElement.Height;
            dbSubElement.ElementType = dbElementType;

            await _uow.CompleteAsync(cancellationToken);
            return dbSubElement;
        }
    }
}
