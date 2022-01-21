using Abby.DataAccess.Data;
using Abby.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.Categories
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Category Category { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Category = _db.Category.Find(id);
            //Category = _db.Category.FirstOrDefault(c => c.Id == id);
            //Category = _db.Category.SingleOrDefault(c => c.Id == id);
            //Category = _db.Category.Where(c => c.Id == id).FirstOrDefault();
        }
        public async Task<IActionResult> OnPost()
        {
            
            if (ModelState.IsValid)
            {
                _db.Category.Update(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category modified successfully";
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
