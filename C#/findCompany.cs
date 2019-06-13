using System;
using System.Net.Http;

// Search for companies using name or other identifiers.

// Tips for searching:
// * If you have a unique identifier for the company (i.e. you want exactly one result), use identifyCompany instead.
// * You don't need to include the legal form in the name (e.g. if the company is called PRINT Solutions Ltd, just search for PRINT Solutions).
// Allowed combinations:
// * full_text_query
// * full_text_query with country_iso_code
// * company_name and/or zip_code and/or city together with country_iso_code

// more details at https://b2b.cofacecentraleurope.com/web/online/api-docs/bi/doc#operation/findCompany

namespace ConsoleProgram
{
    public class Class1
    {
        private const string url = "https://test.cofacecentraleurope.com/api/bi/v1/companies?company_name=Budowlane&country_iso_code=PL";

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
