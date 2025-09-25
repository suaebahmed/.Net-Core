using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp1.Json;
//https://www.newtonsoft.com/json/help/html/SerializationGuide.htm

public class JsonSerializeAndDeserialize
{
    public JsonSerializeAndDeserialize()
    {
        string json = @"{
          'Name': 'Bad Boys',
          'ReleaseDate': '1995-4-7T00:00:00',
          'Genres': [
            'Action',
            'Comedy'
          ]
        }";

        Movie m = JsonConvert.DeserializeObject<Movie>(json)!;
        Console.WriteLine(m.Name);
        Console.WriteLine(m.ReleaseDate);

        Product product = new Product();
        product.Name = "Apple";
        product.ExpiryDate = new DateTime(2008, 12, 28);
        product.Price = 3.99M;
        product.Sizes = new string[] { "Small", "Medium", "Large" };

        string output = JsonConvert.SerializeObject(product);
        Console.WriteLine(output);

        Product deserializedProduct = JsonConvert.DeserializeObject<Product>(output)!;
    }

    private class Movie
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<string> Genres { get; set; }
    }
    private class Product
    {
        public string Name { get; set; }
        public DateTime ExpiryDate { get; set; }
        public decimal Price { get; set; }

        [JsonIgnore]
        public string[] Sizes { get; set; }
    }
}
