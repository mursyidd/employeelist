using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using test.web.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using System.Text;
using System.Diagnostics;
using test.web.Models;


namespace test.web.Pages
{
    public class AddModel : PageModel
    {
        // IHttpClientFactory set using dependency injection 
        private readonly IHttpClientFactory _httpClientFactory;

        public AddModel(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

        // Add the data model and bind the form data to the page model properties
        [BindProperty]
        public EmployeeModel EmployeeModels { get; set; }

        // Begin POST operation code
        public async Task<IActionResult> OnPost()
        {
            EmployeeModels.is_deleted = 0;
            EmployeeModels.created_date = DateTime.Now;
            // Serialize the information to be added to the database
            var jsonContent = new StringContent(JsonSerializer.Serialize(EmployeeModels),
                Encoding.UTF8,
                "application/json");

            // Create the HTTP client using the EmployeeAPI named factory
            var httpClient = _httpClientFactory.CreateClient("EmployeeAPI");

            // Execute the POST request and store the response. The parameters in PostAsync 
            // direct the POST to use the base address and passes the serialized data to the API
            using HttpResponseMessage response = await httpClient.PostAsync("", jsonContent);

            // Return to the home (Index) page and add a temporary success/failure 
            // message to the page.
            if (response.IsSuccessStatusCode)
            {
                TempData["success"] = "Data was added successfully.";
                return RedirectToPage("Index");
            }
            else
            {
                TempData["failure"] = "Operation was not successful";
                return RedirectToPage("Index");
            }
        }
        // End POST operation code
    }
}

