using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_DbContext_RazorApp.models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text),StringLength(255)]
        public string Title { get; set; }

        [DataType(DataType.Date), Required]
        public DateTime DateCreated { get; set; }

        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}
