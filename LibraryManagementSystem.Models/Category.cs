using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required, MaxLength(25, ErrorMessage = "Charecter must be less than 30")]
        [DisplayName("Category Name")]
        public string Name { get; set; }

        [Range(1, 100, ErrorMessage = "Order limit is 1 and 100")]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
