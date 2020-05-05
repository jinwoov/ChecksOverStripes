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
        public string baseURL = @"https://bobeepapi.azurewebsites.net/api";

        public Task<Inventory> GetInventories()
        {
            string route = "Inventory";

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var streamTask = await client.GetStreamAsync($"{baseURL}/{route}");
            var allactivities = await System.Text.Json.JsonSerializer.DeserializeAsync<List<Activity>>(streamTask);

            // Filters by tags
            List<Activity> taggedActivities = new List<Activity>();
            foreach (var activity in allactivities)
            {
                Activity a = await GetActivitiesByID(activity.ID);
                if (a.Tags.Any(x => tags.Any(t => t == x.Name)))
                    taggedActivities.Add(a);
            }

            // Filters by keyword in the description or the title, case-insensitive, and then sorts by highest to lowest rating
            var response = taggedActivities.Where(a => a.Title.ToLower()
                .Contains(keyword.ToLower()) || a.Description.ToLower().Contains(keyword.ToLower()))
                .OrderByDescending(a => a.Rating);

            return response;
        }
    }
}
