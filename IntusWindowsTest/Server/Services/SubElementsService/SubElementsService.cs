using DAL.Repositories.Contracts;
using SubElement = DAL.Entities.SubElement;

namespace IntusWindowsTest.Server.Services.SubElementsService
{
    public class SubElementsService : ISubElementsService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public SubElementsService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<SubElement?> GetSubElementById(int subElementId, CancellationToken cancellationToken)
        {
            SubElement? dbSubElement;
            using (var uow = _unitOfWorkFactory.MakeUnitOfWork())
            {
                dbSubElement = await uow.SubElements.GetByIdAsync(subElementId, cancellationToken);
            }

            return dbSubElement;
        }

        public async Task<SubElement?> CreateSubElement(SubElement subElement, CancellationToken cancellationToken)
        {
            SubElement? dbSubElement;
            using (var uow = _unitOfWorkFactory.MakeUnitOfWork())
            {
                var dbWindow = await uow.Windows.GetByIdAsync(subElement.Window.Id, cancellationToken);
                var dbElementType = await uow.ElementTypes.GetByIdAsync(subElement.ElementType.Id, cancellationToken);
                if (dbWindow == null || dbElementType == null)
                {
                    return null;
                }
                var entSubElement = new SubElement()
                {
                    Element = subElement.Element,
                    Width = subElement.Width,
                    Height = subElement.Height,
                    ElementType = dbElementType,
                    Window = dbWindow
                };

                dbSubElement = await uow.SubElements.AddAndReturnEntityAsync(entSubElement, cancellationToken);
                await uow.CompleteAsync(cancellationToken);
            }

            return dbSubElement;
        }

        public async Task<bool> DeleteSubElement(int subElementId, CancellationToken cancellationToken)
        {
            bool result;
            using (var uow = _unitOfWorkFactory.MakeUnitOfWork())
            {
                result = await uow.SubElements.DeleteByIdAsync(subElementId, cancellationToken);
                if (result == false)
                {
                    return false;
                }

                await uow.CompleteAsync(cancellationToken);
            }

            return true;
        }

        public async Task<SubElement?> UpdateSubElement(SubElement subElement, CancellationToken cancellationToken)
        {
            SubElement? dbSubElement;
            using (var uow = _unitOfWorkFactory.MakeUnitOfWork())
            {
                dbSubElement = await uow.SubElements.GetByIdAsync(subElement.Id, cancellationToken);
                var dbElementType = await uow.ElementTypes.GetByIdAsync(subElement.ElementType.Id, cancellationToken);

                if (dbSubElement != null)
                {
                    dbSubElement.Element = subElement.Element;
                    dbSubElement.Width = subElement.Width;
                    dbSubElement.Height = subElement.Height;
                    dbSubElement.ElementType = dbElementType;

                    await uow.CompleteAsync(cancellationToken);
                }
            }

            return dbSubElement;
        }
    }
}
