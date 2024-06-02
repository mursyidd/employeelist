using Microsoft.AspNetCore.Mvc.RazorPages;
using test.web.Models;
using System.Text.Json;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace test.web.Pages
{
    public class IndexModel : PageModel
    {
        // IHttpClientFactory set using dependency injection 
        private readonly IHttpClientFactory _httpClientFactory;

        public IndexModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // Add the data model and bind the form data to the page model properties
        // Enumerable since an array is expected as a response
        [BindProperty]
        public IEnumerable<EmployeeModel> EmployeeModels { get; set; }

        // Begin GET operation code
        // OnGet() is async since HTTP requests should be performed async
   public async Task OnGet()
   {
       // Create the HTTP client using the EmployeeAPI named factory
       var httpClient = _httpClientFactory.CreateClient("EmployeeAPI");

       // Perform the GET request and store the response. The empty parameter
       // in GetAsync doesn't modify the base address set in the client factory 
       using HttpResponseMessage response = await httpClient.GetAsync("");

       // If the request is successful deserialize the results into the data model
       if (response.IsSuccessStatusCode)
       {
           using var contentStream = await response.Content.ReadAsStreamAsync();
           EmployeeModels = await JsonSerializer.DeserializeAsync<IEnumerable<EmployeeModel>>(contentStream);
       }
   }
        // End GET operation code
    }
}

