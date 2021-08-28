using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [Display(Name = "Tiêu đề")]
        [Required(ErrorMessage = "Không được bỏ trống Title")]
        [DataType(DataType.Text),StringLength(255)]
        public string Title { get; set; }

        [DisplayName("Ngày tạo")]
        [DataType(DataType.Date), Required(ErrorMessage = "Không được bỏ trống {0}")]
        public DateTime DateCreated { get; set; }


        [DisplayName("Nội dung")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}
