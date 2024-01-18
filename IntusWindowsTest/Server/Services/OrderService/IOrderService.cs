﻿using DAL.Entities;

namespace IntusWindowsTest.Server.Services.OrderService
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrders();

        Task<Order?> GetOrderById(int orderId);
    }
}