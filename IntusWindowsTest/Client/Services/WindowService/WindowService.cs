using DAL.Entities;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace IntusWindowsTest.Client.Services.WindowService
{
    public class WindowService : IWindowService
    {
        public List<Window> Windows { get; set; } = new List<Window>();

        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public WindowService(HttpClient http, NavigationManager navigationManger)
        {
            _http = http;
            _navigationManager = navigationManger;
        }

        public async Task GetWindowsByOrderId(int orderId)
        {
            var result = await _http.GetFromJsonAsync<List<Window>>($"api/window/order/{orderId}");
            if (result is not null)
                Windows = result;
        }
    }
}
