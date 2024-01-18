﻿using DAL.Entities;

namespace IntusWindowsTest.Client.Services.OrderService
{
    public interface IOrderService
    {
        List<Order> Orders { get; set; }

        Task GetOrders();

        Task<Order?> GetOrderById(int id);
    }
}