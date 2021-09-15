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
    public class InventoryClient
    {
        private readonly HttpClient _client;

        public InventoryClient()
        {
            _client = new HttpClient();
        }

        // API Calls :

        //Get : Inventory (All)

        public async Task<List<Inventory>> GetInventoryAsync()
        {
            
            HttpResponseMessage response = await _client.GetAsync(UriGenerator.GetUri("inventory"));
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                List<Inventory> temp = JsonConvert.DeserializeObject<List<Inventory>>(content);
                return temp;
            }
            return new List<Inventory>();
        }

        //Get : Inventory/id (One Item)
        public async Task<Inventory> GetItemAsync(string id)
        {

            HttpResponseMessage response = await _client.GetAsync(UriGenerator.GetUri("inventory",id));
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Inventory>(content);
            }
            else
            {
                return new Inventory();
            }
        }

        //Put : Inventory/id (One Item)
        public async Task PutItemAsync(string id,Inventory inventory)
        {

            string json = JsonConvert.SerializeObject(inventory);
            StringContent content = new StringContent(json,Encoding.UTF8,"application/json");
            HttpResponseMessage response = await _client.PutAsync(UriGenerator.GetUri("inventory", id),content);
            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(@"\t Item successfully saved.");
            }

        }

        //Post : Inventory/id (One Item)
        public async Task PostItemAsync(Inventory inventory)
        {
            inventory.Id = Guid.NewGuid().ToString();
            string json = JsonConvert.SerializeObject(inventory);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync(UriGenerator.GetUri("inventory"), content);
            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(@"\t Item successfully Created.");
            }
        }

        //Delete : Inventory/id (One Item)
        public async Task DeleteItemAsync(string id)
        {

            HttpResponseMessage response = await _client.DeleteAsync(UriGenerator.GetUri("inventory", id));
            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine(@"\t Item successfully Deleted.");
            }
        }
    }
}
