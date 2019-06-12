using System;
using System.Net.Http;

namespace ConsoleProgram
{
    public class Class1
    {

        static void Main(string[] args)
        {
            using (var httpClient = new HttpClient())
            {
                string url = "https://test.cofacecentraleurope.com/api/bi/v1/orders/monitoring";
                string payload = @"{
                    ""company_id"": ""102296980"",
                    ""product_details"": {
                        ""product_code"": ""200"",
                        ""language"": ""en"",
                        ""format"": ""pdf""
                    },
                    ""monitoring_details"": {
                        ""start_date"": ""2018-03-09"",
                        ""duration_months"": ""12""
                    }
                }";
                HttpContent content = new StringContent(payload, System.Text.Encoding.UTF8, "application/json");
                httpClient.DefaultRequestHeaders.Add("api_key", "8842ace2-e377-48d9-b129-f952950ea535");
                var response = httpClient.PostAsync(new Uri(url), content).Result;
                Console.WriteLine(response.ToString());
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);

            }
        }
    }
}
