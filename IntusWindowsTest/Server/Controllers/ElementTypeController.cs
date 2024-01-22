using DAL.Entities;
using IntusWindowsTest.Server.Services.ElementTypeService;
using Microsoft.AspNetCore.Mvc;

namespace IntusWindowsTest.Server.Controllers
{
    [ApiController]
    [Route("api/element/type")]
    public class ElementTypeController : ControllerBase
    {
        private readonly IElementTypeService _elementTypeService;

        public ElementTypeController(IElementTypeService elementTypeService)
        {
            _elementTypeService = elementTypeService;
        }

        [HttpGet]
        public async Task<List<ElementType>> GetElementTypes()
        {
            return await _elementTypeService.GetElemetTypes();
        }
    }
}
