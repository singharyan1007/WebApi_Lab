using System.Net.Http.Json;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //fetch all the products from api and display



            //Step 1: discover the api address/uri
            string baseUri = "https://localhost:44336";

            //using library class for consuming the api in dotnet program
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseUri);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            //var response = client.GetStringAsync($"{baseUri}/api/products?&$top=1").Result;
            var response = client.GetFromJsonAsync<List<Product>>($"{baseUri}/api/products?&$top=1").Result;
            Console.WriteLine(response[0].productName);
            Console.WriteLine(response[0].price);
        }
    }


    // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
    public class Product
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }
        public string productCategory { get; set; }
        public string brand { get; set; }
        public int price { get; set; }
        public bool isAvailable { get; set; }
        public string country { get; set; }
    }


}
