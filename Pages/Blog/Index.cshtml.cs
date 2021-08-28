using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CRUD_DbContext_RazorApp;
using CRUD_DbContext_RazorApp.models;
using CRUD_DbContext_RazorApp.Helpers;

namespace CRUD_DbContext_RazorApp.Pages.Blog
{
    public class IndexModel : PageModel
    {
        private readonly CRUD_DbContext_RazorApp.MyDbContext _context;

        public IndexModel(CRUD_DbContext_RazorApp.MyDbContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get; set; }

        [BindProperty(SupportsGet = true,Name = "content")]
        public string content { get; set; }

        [BindProperty(SupportsGet = true, Name = "p")]
        public int currentPage { get; set; } = 1;

        public int countPages { get; set; }

        public const int ITEM_PER_PAGE = 10;

        public async Task OnGetAsync()
        {
        

            var articles = await (from a in _context.Articles
                            orderby a.DateCreated descending
                            select a).ToListAsync();

            if (!string.IsNullOrEmpty(content))
            {
                articles = (from a in articles
                            where a.Title.Contains(content)
                            select a).ToList();
            }

            int totalArticles = articles.Count;

            this.countPages = (int)Math.Ceiling((double)totalArticles / ITEM_PER_PAGE);

            this.Article = articles.Skip((currentPage - 1)*ITEM_PER_PAGE)
                                    .Take(ITEM_PER_PAGE).ToList();
            
        }
    }
}
