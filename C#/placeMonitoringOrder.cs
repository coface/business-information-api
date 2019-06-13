using System;
using System.Net.Http;

// Monitor a company to receive notifications when updated company data becomes available.

// You will need to specify at least:
// * the company to monitor (company_id)
// * the monitoring product to order (product_details).
//    * product_code: 9002 for the standard CCE Risk monitor (values from code table CC8800).
//    * language: the language of notification (e.g en for english).
//    * format: xml, pdf, html or txt.
// * if you're using the demo API key, you cannot place a new monitoring order (you can check for notitifcations though)

// more details at https://b2b.cofacecentraleurope.com/web/online/api-docs/bi/doc//operation/placeMonitoringOrder



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
