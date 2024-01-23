using DAL.Entities;
using IntusWindowsTest.Server.Services.SubElementsService;
using Microsoft.AspNetCore.Mvc;

namespace IntusWindowsTest.Server.Controllers
{
    [ApiController]
    [Route("api/subelement/")]
    public class SubElementController : ControllerBase
    {
        private readonly ISubElementsService _subElementsService;
        public SubElementController (ISubElementsService subElementsService)
        {
            _subElementsService = subElementsService;
        }

        [HttpGet("{id}")]
        public async Task<SubElement?> GetSubElementById(int id, CancellationToken cancellationToken)
        {
            return await _subElementsService.GetSubElementById(id, cancellationToken);
        }

        [HttpPost]
        public async Task<SubElement?> CreateSubElement(SubElement subElement, CancellationToken cancellationToken)
        {
            return await _subElementsService.CreateSubElement(subElement, cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteSubElement(int id, CancellationToken cancellationToken)
        {
            return await _subElementsService.DeleteSubElement(id, cancellationToken);
        }

        [HttpPut]
        public async Task<SubElement?> UpdateSubElement(SubElement subElement, CancellationToken cancellationToken)
        {
            return await _subElementsService.UpdateSubElement(subElement, cancellationToken);
        }
    }
}
