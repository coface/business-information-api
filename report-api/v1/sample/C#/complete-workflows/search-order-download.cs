using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

// In this example we search for a company, place an order for a report, wait for the report to be ready and then download it

namespace ConsoleProgram
{
    public class Class1
    {
        private const string base_rest_url = "https://test.cofacecentraleurope.com/api/bi/v1/";

        private static JArray SearchForCompany(HttpClient httpClient, string queryParams)
        {
            var response = httpClient.GetStringAsync(new Uri(base_rest_url + "companies?" + queryParams)).Result;
            return JArray.Parse(response);
        }

        private static JObject PlaceOrderImmediate(HttpClient httpClient, string product_code, string company_id, string format)
        {
            string payload = "{\"company_id\": \"" + company_id + "\",\"product_details\": {\"product_code\": \"" + product_code + "\",\"language\": \"EN\",\"format\": \"" + format + "\"},\"credit_report_details\": {\"research_instructions\": \"immediate_no_research\"}}";
            HttpContent content = new StringContent(payload, System.Text.Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(new Uri(base_rest_url + "orders/creditreport"), content).Result;
            return JObject.Parse(response.Content.ReadAsStringAsync().Result);
        }

        private static JObject GetOrderDetails(HttpClient httpClient, string order_guid)
        {
            var response = httpClient.GetStringAsync(new Uri(base_rest_url + "order/" + order_guid)).Result;
            return JObject.Parse(response);
        }

        private static JArray ListOrderDocuments(HttpClient httpClient, string order_guid)
        {
            var response = httpClient.GetStringAsync(new Uri(base_rest_url + "order/" + order_guid + "/documents")).Result;
            return JArray.Parse(response);
        }

        private static string GetOrderDocument(HttpClient httpClient, string order_guid, string file_name)
        {
            var response = httpClient.GetStringAsync(new Uri(base_rest_url + "order/" + order_guid + "/document/" + file_name)).Result;
            return response.ToString();
        }

        static void Main(string[] args)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("api_key", "8842ace2-e377-48d9-b129-f952950ea535");
                httpClient.DefaultRequestHeaders.Add("accept", "application/json");

                JArray companies = SearchForCompany(httpClient, "country_iso_code=PL&company_name=Hydrobudowa&limit=5");

                Console.WriteLine("{0} companies found", companies.Count);

                string company_id = companies[0]["company_id"].ToString();
                Console.WriteLine("Found {0} companies with name Hydrobudowa in PL; first one has company_id {1}", companies.Count, company_id);

                Console.WriteLine("Placing an order");

                JObject immediate_order_response = PlaceOrderImmediate(httpClient, "200", company_id, "html");
                var immediate_order_guid = immediate_order_response["id"].ToString();
                Console.WriteLine("Immediate order placed; order ID is " + immediate_order_guid);

                var finished = false;
                while (!finished)
                {
                    Console.WriteLine("Order not finished yet, waiting...");
                    System.Threading.Thread.Sleep(5000);
                    JObject order_details = GetOrderDetails(httpClient, immediate_order_guid);
                    string order_status = order_details["order_status"].ToString();
                    finished = order_status == "finished" || order_status == "cancelled";
                }

                Console.WriteLine("Immediate order finished, listing documents");

                JArray documents = ListOrderDocuments(httpClient, immediate_order_guid);

                foreach (var document in documents.Children())
                {
                    string file_name = document["file_name"].ToString();
                    Console.WriteLine(file_name);
                    string report = GetOrderDocument(httpClient, immediate_order_guid, file_name);
                    Console.WriteLine(report);
                }
            }
        }
    }
}
