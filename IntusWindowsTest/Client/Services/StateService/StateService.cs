using DAL.Entities;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace IntusWindowsTest.Client.Services.StateService
{
    public class StateService : IStateService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public StateService(HttpClient http, NavigationManager navigationManger)
        {
            _http = http;
            _navigationManager = navigationManger;
        }

        public List<State> States { get; set; } = new List<State>();

        public async Task GetStates()
        {
            var result = await _http.GetFromJsonAsync<List<State>>("api/state");
            if (result is not null)
                States = result;
        }
    }
}
