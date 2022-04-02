using System;
using System.Net.Http;

// Retrieve a document (e.g. a report) associated with an order.

// more details at https://b2b.cofacecentraleurope.com/web/online/api-docs/bi/doc#operation/getOrderDocument


namespace ConsoleProgram
{
    public class Class1
    {
        private const string url = "https://test.cofacecentraleurope.com/api/bi/v1/order/cc4b853d-f059-48e0-97cc-ef3785315213/document/report.html";

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
