using DAL.Entities;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace IntusWindowsTest.Client.Services.ElementTypeService
{
    public class ElementTypeService : IElementTypeService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public ElementTypeService(HttpClient http, NavigationManager navigationManger)
        {
            _http = http;
            _navigationManager = navigationManger;
        }

        public List<ElementType> ElementTypes { get; set; } = new List<ElementType>();

        public async Task GetElementTypes()
        {
            var result = await _http.GetFromJsonAsync<List<ElementType>>("api/elementtype");
            if (result is not null)
                ElementTypes = result;
        }
    }
}
