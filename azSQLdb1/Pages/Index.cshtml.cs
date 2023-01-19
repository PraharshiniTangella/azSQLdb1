using azSQLdb1.Models;
using azSQLdb1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace azSQLdb1.Pages
{
    public class IndexModel : PageModel
    {
        public List<Person> persons;

        public void OnGet()
        {
            PersonServivce personServivce = new PersonServivce();
            persons=personServivce.GetPersons();

        }
    }
}