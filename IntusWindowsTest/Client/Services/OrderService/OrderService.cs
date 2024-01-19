using DAL.Entities;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;

namespace IntusWindowsTest.Client.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public OrderService(HttpClient http, NavigationManager navigationManger)
        {
            _http = http;
            _navigationManager = navigationManger;
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
            await _http.PostAsJsonAsync("api/order", order);
            _navigationManager.NavigateTo("orders");
        }

        public async Task UpdateOrder(int id, Order order)
        {
            await _http.PutAsJsonAsync($"api/order/{id}", order);
            _navigationManager.NavigateTo("orders");
        }
    }
}
