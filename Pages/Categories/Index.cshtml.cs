using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Soim_Adrian_Lab2.Data;
using Soim_Adrian_Lab2.Models;
using Soim_Adrian_Lab2.Models.ViewModels;

namespace Soim_Adrian_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Soim_Adrian_Lab2.Data.Soim_Adrian_Lab2Context _context;

        public IndexModel(Soim_Adrian_Lab2.Data.Soim_Adrian_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public CategoryIndexData CategoryIndexData { get; set; }
        public BookData BookD { get; set; }
        public int CategoryID { get; set; }
        public int BookID { get; set; }
        public async Task OnGetAsync(int? id,int? bookID)
        {
            BookD = new BookData();
            BookD.Categories = await _context.Category
                .Include(b => b.BookCategories)
                .ThenInclude(b => b.Book)
                .OrderBy(b => b.CategoryName)
                .ToListAsync();
            BookD.BookCategories = await _context.BookCategory
                .Include(b => b.Category)
                .Include(b => b.Book)
                .OrderBy(b => b.Book)
                .ToListAsync();
            if (id != null)
            {
                CategoryID = id.Value;
                BookD.Books = await _context.BookCategory
                .Where(bc => bc.CategoryID == CategoryID)
                .Select(bc => bc.Book)
                .ToListAsync();
            }
        }
    }
}
