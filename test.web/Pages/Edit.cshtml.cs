using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using test.web.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using System.Text;
using System.Diagnostics;

namespace test.web.Pages
{
	public class EditModel : PageModel
    {
        // IHttpClientFactory set using dependency injection 
        private readonly IHttpClientFactory _httpClientFactory;

        public EditModel(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

        // Add the data model and bind the form data to the page model properties
        [BindProperty]
        public EmployeeModel EmployeeModels { get; set; }


        // Retrieve the data to populate the form for editing
        public async Task OnGet(int id)
        {
 
            // Create the HTTP client using the EmployeeAPI named factory
            var httpClient = _httpClientFactory.CreateClient("EmployeeAPI");

            // Retrieve record information to populate the form
            using HttpResponseMessage response = await httpClient.GetAsync(id.ToString());

            if (response.IsSuccessStatusCode)
            {
                // Deserialize the response to populate the form
                using var contentStream = await response.Content.ReadAsStreamAsync();
				EmployeeModels = await JsonSerializer.DeserializeAsync<EmployeeModel>(contentStream);
            }
        }


        // Begin PUT operation code
        public async Task<IActionResult> OnPost()
        {
            // Serialize the information to be edited in the database
            var jsonContent = new StringContent(JsonSerializer.Serialize(EmployeeModels),
                Encoding.UTF8,
                "application/json");

            // Create the HTTP client using the EmployeeAPI named factory
            var httpClient = _httpClientFactory.CreateClient("EmployeeAPI");

            // Execute the PUT request and store the response. The parameters in PutAsync 
            // appends the item Id to the base address and passes the serialized data to the API
            using HttpResponseMessage response = await httpClient.PutAsync(EmployeeModels.id.ToString(), jsonContent);

            // Return to the home (Index) page and add a temporary success/failure 
            // message to the page.
            if (response.IsSuccessStatusCode)
            {
                TempData["success"] = "Data was edited successfully.";
                return RedirectToPage("Index");
            }
            else
            {
                TempData["failure"] = "Operation was not successful";
                return RedirectToPage("Index");
            }

        }
        // End PUT operation code

    }
}

