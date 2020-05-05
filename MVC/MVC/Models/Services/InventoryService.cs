using MVC.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace MVC.Models.Services
{
    public class InventoryService : InventoryManager
    {
        private static readonly HttpClient client = new HttpClient();
        public string baseURL = @"https://localhost:44305/api";

        public async Task<IEnumerable<Inventory>> GetInventories()
        {
            string route = "Inventory";

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var streamTask = await client.GetStreamAsync($"{baseURL}/{route}");
            var allactivities = await System.Text.Json.JsonSerializer.DeserializeAsync<List<Inventory>>(streamTask);

            return allactivities;
        }
    }
}
