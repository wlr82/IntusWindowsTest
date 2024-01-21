using DAL.Entities;
using IntusWindowsTest.Client.Services.WindowService;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;

namespace IntusWindowsTest.Client.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        private readonly IWindowService _windowService;

        public OrderService(
            HttpClient http, 
            NavigationManager navigationManger,
            IWindowService windowService)
        {
            _http = http;
            _navigationManager = navigationManger;
            _windowService = windowService;
        }

        public List<Order> Orders { get; set; } = new List<Order>();


        public async Task GetOrders()
        {
            var result = await _http.GetFromJsonAsync<List<Order>>("api/order");
            if (result is not null)
                Orders = result;
        }

        public async Task<Order?> GetOrderById(int id)
        {
            var result = await _http.GetAsync($"api/order/{id}");
            if (result.StatusCode == HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<Order>();
            }
            return null;
        }

        public async Task CreateOrder(Order order)
        {
            var result = await _http.PostAsJsonAsync("api/order", order);
            if (result.StatusCode == HttpStatusCode.OK)
            {
                order = await result.Content.ReadFromJsonAsync<Order>();
            }
            _navigationManager.NavigateTo($"orders/{order?.Id}");
        }

        public async Task UpdateOrder(int id, Order order)
        {
            await _http.PutAsJsonAsync($"api/order/{id}", order);
            _navigationManager.NavigateTo($"orders/{id}");
        }

        public async Task DeleteOrder(int id)
        {
            await _http.DeleteAsync($"api/order/{id}");
            await GetOrders();
            _windowService.Windows = new List<Window>();
            _navigationManager.NavigateTo("orders/0");
        }
    }
}
