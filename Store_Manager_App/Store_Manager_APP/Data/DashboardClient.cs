using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Store_Manager_APP.Models;

namespace Store_Manager_APP.Data
{
    public class DashboardClient
    {
        private readonly HttpClient _client;

        public DashboardClient()
        {
            _client = new HttpClient();
        }

        // API Calls :

        // Get : Dashboard (One)
        public async Task<Dashboard> GetDashboardAsync()
        {
            Dashboard dashboardData = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(UriGenerator.GetUri("Dashboard",1));
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    dashboardData = JsonConvert.DeserializeObject<Dashboard>(content);
                    Console.WriteLine(dashboardData);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return dashboardData;
        }
    }
}
