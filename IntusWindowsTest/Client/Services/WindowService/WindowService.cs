using DAL.Entities;
using Microsoft.AspNetCore.Components;
using System.Net;
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

        public async Task<Window?> GetWindowById(int id)
        {
            var result = await _http.GetAsync($"api/window/{id}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<Window>();
            }
            return null;
        }

        public async Task UpdateWindow(Window window)
        {
            await _http.PutAsJsonAsync("api/window", window);
            _navigationManager.NavigateTo("orders");
        }

        public async Task CreateWindow(Window window)
        {
            await _http.PostAsJsonAsync("api/window", window);
            _navigationManager.NavigateTo("orders");
        }

        public async Task DeleteWindow(int orderId, int windowId)
        {
            var result = await _http.DeleteAsync($"api/window/{windowId}");
            await GetWindowsByOrderId(orderId);
        }
    }
}
