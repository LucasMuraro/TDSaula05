using Aula005.RazorPages.Data;
using Aula005.RazorPages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Aula005.RazorPages.Pages.Events
{
    public class Index : PageModel
    {
        private readonly AppDbContext _context;
        public List<Curso> EventList { get; set;  } = new();
        
        public Index(AppDbContext context)
        {
          _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var httpClient = new HttpClient();
            var url = "http://localhost:5072/";
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await httpClient.SendAsync(requestMessage);
            // EventList = await response.Content.ReadAsStringAsync();
            var content = await response.Content.ReadAsStringAsync();

//dotnet add package Newtonsoft.Json

            EventList = JsonConvert.DeserializeObject<List<Curso>>(content!);


            // EventList = await _context.Events!.ToListAsync();
            return Page();
        }
    }
}