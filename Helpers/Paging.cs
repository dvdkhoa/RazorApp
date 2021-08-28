using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_DbContext_RazorApp.Helpers
{
    public class Paging
    {
        public int currentPage { get; set; }
        public int countPages { get; set; }
        public Func<int?,string> generateUrl { get; set; }
    }
}
