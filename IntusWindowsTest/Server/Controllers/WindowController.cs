﻿using DAL.Entities;
using IntusWindowsTest.Server.Services.WindowsService;
using Microsoft.AspNetCore.Mvc;

namespace IntusWindowsTest.Server.Controllers
{
    [ApiController]
    [Route("api/window/")]
    public class WindowController : ControllerBase
    {
        private readonly IWindowService _windowService;

        public WindowController(IWindowService windowService)
        {
            _windowService = windowService;
        }

        [HttpGet]
        public async Task<List<Window>> GetWindows()
        {
            return await _windowService.GetWindows();
        }

        [HttpGet("order/{orderId}")]
        public async Task<List<Window>> GetWindowsByOrderId(int orderId)
        {
            return await _windowService.GetWindowsByOrderId(orderId);
        }

        [HttpGet("{id}")]
        public async Task<Window?> GetWindowById(int id, CancellationToken cancellationToken)
        {
            return await _windowService.GetWindowById(id, cancellationToken);
        }

        [HttpPut]
        public async Task<Window?> UpdateWindow(Window window, CancellationToken cancellationToken)
        {
            return await _windowService.UpdateWindow(window, cancellationToken);
        }

        [HttpPost]
        public async Task<Window?> CreateWindow(Window window, CancellationToken cancellationToken)
        {
            return await _windowService.CreateWindow(window, cancellationToken);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteWindow(int id, CancellationToken cancellationToken)
        {
            return await _windowService.DeleteWindow(id, cancellationToken);
        }
    }
}
