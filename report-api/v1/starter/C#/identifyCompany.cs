using System;
using System.Net.Http;

// Find a company using a unique identifier (returns exactly 1 or 0 results).

// Tips for finding a company:
// * If you are searching using national identifiers, provide the country (via the country_iso_code)
// * You don't need to include the legal form in the name (e.g. if the company is called PRINT Solutions Ltd, just search for PRINT Solutions).

// more details at https://b2b.cofacecentraleurope.com/web/online/api-docs/bi/doc//operation/identifyCompany


namespace ConsoleProgram
{
    public class Class1
    {
        private const string url = "https://test.cofacecentraleurope.com/api/bi/v1/company?identifier_type=120&identifier_value=6551640402&country_iso_code=PL";

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
