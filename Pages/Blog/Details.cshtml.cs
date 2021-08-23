﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CRUD_DbContext_RazorApp;
using CRUD_DbContext_RazorApp.models;

namespace CRUD_DbContext_RazorApp.Pages.Blog
{
    public class DetailsModel : PageModel
    {
        private readonly CRUD_DbContext_RazorApp.MyDbContext _context;

        public DetailsModel(CRUD_DbContext_RazorApp.MyDbContext context)
        {
            _context = context;
        }

        public Article Article { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Article = await _context.Articles.FirstOrDefaultAsync(m => m.Id == id);

            if (Article == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
