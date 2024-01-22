using DAL.Entities;
using DAL.Repositories.Contracts;
using IntusWindowsTest.Client.Pages;

namespace IntusWindowsTest.Server.Services.SubElementsService
{
    public class SubElementsService : ISubElementsService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public SubElementsService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
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

                //dbSubElement = await uow.States.AddAndReturnEntityAsync(entWindow, cancellationToken);
                //await uow.CompleteAsync(ct);
            }

            return null;

        }

        public Task<bool> DeleteSubElement(int subElementId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<SubElement?> GetSubElementById(int subElementId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<SubElement>> GetSubElementsByWindowId(int window)
        {
            throw new NotImplementedException();
        }

        public Task<SubElement?> UpdateSubElement(SubElement subElement, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
