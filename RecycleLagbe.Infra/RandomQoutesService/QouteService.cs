using System;
using System.Text;
using System.Xml.Linq;
using Newtonsoft.Json;
using RandomService.DTOs;

namespace RandomService;
public class QouteService
{
    public class MyData
    {
        public string Key1 { get; set; }
        public int Key2 { get; set; }
    }
    public QouteService()
    {

    }

    public static async Task CreatePost(MyData dataToSend)
    {
        using (HttpClient client = new())
        {
            var apiUrl = "https://your-api-endpoint.com/data";

            var jsonContent = JsonConvert.SerializeObject(dataToSend);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await client.PostAsync(apiUrl, httpContent);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response: {responseBody}");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
            }
        }
    }
    
    public static async Task<Qoute?> GetQouteToday()
    {
        using (HttpClient client = new())
        {
            client.BaseAddress = new Uri("https://zenquotes.io/api/"); 

            HttpResponseMessage response = await client.GetAsync("today");

            if (response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();
                Qoute? qoute = JsonConvert.DeserializeObject<Qoute>(jsonContent);
                return qoute;
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
            }

            return null;
        }
    }

    public static async Task<List<Qoute>?> GetRandomQoute()
    {
        using (HttpClient client = new())
        {
            client.BaseAddress = new Uri("https://zenquotes.io/api/");
            HttpResponseMessage response = await client.GetAsync("random");
            if (response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Qoute>>(jsonContent)!;
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
            }
            return null;
        }
    }
}
