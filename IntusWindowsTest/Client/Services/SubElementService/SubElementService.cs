using System.Net;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using SubElement = DAL.Entities.SubElement;
using IntusWindowsTest.Client.Services.WindowService;

namespace IntusWindowsTest.Client.Services.SubElementService
{
    public class SubElementService : ISubElementService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        private readonly IWindowService _windowService;

        public SubElementService(HttpClient http, NavigationManager navigationManger, IWindowService windowService)
        {
            _http = http;
            _navigationManager = navigationManger;
            _windowService = windowService;
        }

        public async Task CreateSubElement(SubElement subElement)
        {
            var result = await _http.PostAsJsonAsync("api/subelement", subElement);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                var subElementResponse = await result.Content.ReadFromJsonAsync<SubElement>();
                subElement.Id = subElementResponse.Id;
            }

            _navigationManager.NavigateTo($"orders/{subElement?.Window.Order.Id}/window/{subElement?.Window?.Id}/subelement/{subElement.Id}");
        }

        public async Task DeleteSubElement(int orderId, int windowId, SubElement subElement)
        {
            var result = await _http.DeleteAsync($"api/subelement/{subElement.Id}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                _windowService.Windows.FirstOrDefault(w => w.Id == windowId)?.SubElements.Remove(subElement);
            }
        }

        public async Task<SubElement?> GetSubElementById(int id)
        {
            var result = await _http.GetAsync($"api/subelement/{id}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<SubElement>();
            }
            return null;
        }

        public async Task UpdateSubElement(SubElement subElement)
        {
            await _http.PutAsJsonAsync("api/subelement", subElement);
            _navigationManager.NavigateTo($"orders/{subElement?.Window.Order.Id}/window/{subElement?.Window?.Id}/subelement/{subElement.Id}");
        }
    }
}
