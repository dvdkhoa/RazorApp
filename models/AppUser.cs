using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_DbContext_RazorApp.models
{
    public class AppUser : IdentityUser
    {
        [Column(TypeName = "nvarchar(300)")]
        public string HomeAddress { get; set; }
    }
}
