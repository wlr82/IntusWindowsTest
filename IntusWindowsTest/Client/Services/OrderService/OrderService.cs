using DAL.Entities;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;

namespace IntusWindowsTest.Client.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManger;

        public OrderService(HttpClient http, NavigationManager navigationManger)
        {
            _http = http;
            _navigationManger = navigationManger;
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
    }
}
