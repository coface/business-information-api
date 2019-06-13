using System;
using System.Net.Http;

// Retrieve the details of an order.

// more details at https://b2b.cofacecentraleurope.com/web/online/api-docs/bi/doc#operation/getOrder


namespace ConsoleProgram
{
    public class Class1
    {
        private const string url = "https://test.cofacecentraleurope.com/api/bi/v1/order/8842ace2-e377-48d9-b129-f952950ea535";

        static void Main(string[] args)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("api_key", "8842ace2-e377-48d9-b129-f952950ea535");
                var response = httpClient.GetStringAsync(new Uri(url)).Result;
                Console.WriteLine(response.ToString());
            }
        }
    }
}
