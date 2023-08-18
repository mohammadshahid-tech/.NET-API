using ApiTutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiTutorial.ConsumeApi
{
    public class ConsumeApi
    {
        HttpClient client = new HttpClient();


        public async Task<List<T>> ImplementApiAsync<T>(string Url, string controller)
        {
            try
            {
                client.BaseAddress = new Uri(Url);
                var response = await client.GetAsync(controller);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<T>>();
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions accordingly.
                // For example, log the exception.
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return null;
        }
    }
}